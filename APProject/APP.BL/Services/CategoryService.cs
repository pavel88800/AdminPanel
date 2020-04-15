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

namespace APP.BL.Services
{
    /// <summary>
    ///     Сервис по работе с категориями.
    /// </summary>
    public class CategoryService : AbstractGetService<Category>, ICategoryService
    {
        /// <summary>
        ///     Контекст БД.
        /// </summary>
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public CategoryService(PanelContext context) : base(context)
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
        public async Task<Result> AddCategory(CategoryDto categoryDto)
        {
            try
            {
                var picture = await GetFile(categoryDto.Pictures);
                var parentCategory = _context.Categories.Find(categoryDto.ParentCategoryId);

                var category = new Category
                {
                    Description = categoryDto.Description,
                    HtmlH1 = categoryDto.HtmlH1,
                    MetaDescription = categoryDto.MetaDescription,
                    MetaKeywords = categoryDto.MetaKeywords,
                    MetaTitle = categoryDto.MetaTitle,
                    Name = categoryDto.Name,
                    Sort = categoryDto.Sort,
                    Status = categoryDto.Status
                };

                _context.Add(category);
                _context.SaveChanges();

                if (parentCategory != null && parentCategory.Id != category.Id)
                {
                    var categoryToCategory = new CategoryCategory
                    {
                        Category1 = category,
                        Category1Id = category.Id,
                        Category2 = parentCategory,
                        Category2Id = parentCategory.Id
                    };

                    _context.Add(categoryToCategory);
                    _context.SaveChanges();
                }

                var categoryToPicture = new CategoryPicture
                {
                    Category = category,
                    CategoryId = category.Id,
                    Picture = picture
                };

                _context.Add(categoryToPicture);
                _context.SaveChanges();

                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
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
                throw new ApplicationException(e.Message);
            }
        }

        /// <inheritdoc />
        public Result UpdateCategory(CategoryDto categoryDto)
        {
            var category = _context.Categories.Find(categoryDto.Id);
            var parentCategory = _context.Categories.Find(categoryDto.ParentCategoryId);
            var picture = GetFile(categoryDto.Pictures).Result;

            category.Description = categoryDto.Description;
            category.HtmlH1 = categoryDto.HtmlH1;
            category.MetaDescription = categoryDto.MetaDescription;
            category.MetaKeywords = categoryDto.MetaKeywords;
            category.MetaTitle = categoryDto.MetaTitle;
            category.Name = categoryDto.Name;
            category.Sort = categoryDto.Sort;
            category.Status = categoryDto.Status;

            _context.Update(category);
            _context.SaveChanges();

            if (parentCategory != null && parentCategory.Id != category.Id)
            {
                var categoryParent = _context.CategoryCategory.FirstOrDefault(x => x.Category1.Id == category.Id);
                if (categoryParent != null)
                {
                    _context.Remove(categoryParent);
                    _context.SaveChanges();
                }

                var categoryToCategory = new CategoryCategory
                {
                    Category1 = category,
                    Category1Id = category.Id,
                    Category2 = parentCategory,
                    Category2Id = parentCategory.Id
                };

                _context.Add(categoryToCategory);
                _context.SaveChanges();
            }

            var pictureDelete = _context.CategoryPicture.FirstOrDefault(x => x.CategoryId == category.Id);
            var pictureRemove = _context.Pictures.FirstOrDefault(x => x.Id == pictureDelete.PictureId);
            _context.Remove(pictureDelete ?? throw new ApplicationException());
            _context.Remove(pictureRemove ?? throw new ApplicationException());
            _context.SaveChanges();

            var categoryToPicture = new CategoryPicture
            {
                Category = category,
                CategoryId = category.Id,
                Picture = picture
            };

            _context.Add(categoryToPicture);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}