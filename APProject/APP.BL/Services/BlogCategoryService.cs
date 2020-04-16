namespace APP.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APP.DB;
    using APP.DB.Models;
    using APP.Models.Results;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Сервис по работе с категориями блога.
    /// </summary>
    public class BlogCategoryService : AbstractGetService<BlogCategory>, IBlogCategoryService
    {
        /// <summary>
        ///     Контекст БД.
        /// </summary>
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public BlogCategoryService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetCategoriesAsync(int offset, int count)
        {
            var result = await GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetCategoryById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddCategory(BlogCategoryDto blogCategoryDto)
        {
            await using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var picture = await GetFile(blogCategoryDto.Picture);
                    var parentBlogCategory = _context.BlogCategory.Find(blogCategoryDto.BlogCategoryId);

                    var blogCategory = GetBlogCategory(blogCategoryDto, picture);
                    _context.Add(blogCategory);

                    SaveInformationBlogCategory2BlogCategory(parentBlogCategory, blogCategory);

                    await transaction.CommitAsync();
                    return Result.Ok();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new ApplicationException(e.InnerException.Message ?? e.Message);
                }
            }
        }

        /// <inheritdoc />
        public Result DeleteCategory(List<long> ids)
        {
            try
            {
                DeleteItems(ids);
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <inheritdoc />
        public Result UpdateCategory(BlogCategoryDto blogCategoryDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var category = _context.BlogCategory.Include(x => x.Picture)
                    .FirstOrDefault(x => x.Id == blogCategoryDto.Id);

                var file = GetFile(blogCategoryDto.Picture).Result;

                var parentCategory = _context.BlogCategory.Find(blogCategoryDto.BlogCategoryId);

                if (category != null)
                {
                    category.Picture = file;
                    category.Description = blogCategoryDto.Description;
                    category.HtmlH1 = blogCategoryDto.HtmlH1;
                    category.MetaDescription = blogCategoryDto.MetaDescription;
                    category.MetaKeywords = blogCategoryDto.MetaKeywords;
                    category.MetaTitle = blogCategoryDto.MetaTitle;
                    category.Name = blogCategoryDto.Name;
                    category.Sort = blogCategoryDto.Sort;
                    category.Status = blogCategoryDto.Status;

                    _context.Update(category);

                    if (parentCategory != null)
                    {
                        var blogCategory =
                             _context.BlogCategory2BlogCategories.FirstOrDefault(x =>
                                x.BlogCategory1.Id == category.Id);
                        if (blogCategory != null)
                        {
                            _context.Remove(blogCategory);
                        }

                        var newBlogCategory = new BlogCategory2BlogCategory
                        {
                            BlogCategory1 = category,
                            BlogCategory1Id = category.Id,
                            BlogCategory2Id = parentCategory.Id,
                            BlogCategory2 = parentCategory
                        };

                        _context.Add(newBlogCategory);
                        _context.SaveChanges();
                    }

                    transaction.Commit();

                    return Result.Ok();
                }

                return Result.Fail("Обновление категории не произошло.");
            }
            catch (Exception e)
            {
                transaction.RollbackAsync();
                throw new ApplicationException(e.InnerException.Message ?? e.Message);
            }
        }

        /// <summary>
        ///     Получить объект BlogCategory
        /// </summary>
        /// <param name="blogCategoryDto">ДТО для работы с категориями блога.</param>
        /// <returns>
        ///     <see cref="BlogCategory" />
        /// </returns>
        private BlogCategory GetBlogCategory(BlogCategoryDto blogCategoryDto, Picture picture)
        {
            return new BlogCategory
            {
                Description = blogCategoryDto.Description,
                HtmlH1 = blogCategoryDto.HtmlH1,
                MetaDescription = blogCategoryDto.MetaDescription,
                MetaKeywords = blogCategoryDto.MetaKeywords,
                MetaTitle = blogCategoryDto.MetaTitle,
                Name = blogCategoryDto.Name,
                Sort = blogCategoryDto.Sort,
                Status = blogCategoryDto.Status,
                Picture = picture
            };
        }

        /// <summary>
        ///     Сохранить информацию в таблицу BlogCategory2BlogCategory.
        /// </summary>
        /// <param name="parentBlogCategory">Родительская категория.</param>
        /// <param name="blogCategory">Объект BlogCategory.</param>
        private void SaveInformationBlogCategory2BlogCategory(BlogCategory parentBlogCategory,
            BlogCategory blogCategory)
        {
            if (parentBlogCategory != null)
            {
                var blog2BlogCategory = new BlogCategory2BlogCategory
                {
                    BlogCategory1 = blogCategory,
                    BlogCategory1Id = blogCategory.Id,
                    BlogCategory2 = parentBlogCategory,
                    BlogCategory2Id = parentBlogCategory.Id
                };
                _context.Add(blog2BlogCategory);
                _context.SaveChanges();
            }
        }
    }
}