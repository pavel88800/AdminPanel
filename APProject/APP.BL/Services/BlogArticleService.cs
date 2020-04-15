namespace APP.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APP.DB;
    using APP.DB.Models;
    using APP.Models.Results;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Сервис для работы с <see cref="BlogArticle" />
    /// </summary>
    public class BlogArticleService : AbstractGetService<BlogArticle>, IBlogArticleService
    {
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public BlogArticleService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<OffsetEntitiesDto> GetBlogArticleAsync(int offset, int count)
        {
            var result = GetPagesAsync(offset, count);
            return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetBlogArticleById(long id)
        {
            var result = GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddBlogArticle(BlogArticlesDto blogArticlesDto)
        {
            try
            {
                var file = await GetFile(blogArticlesDto.Picture);

                var recomendedProducts = await _context.Products
                    .Where(x => blogArticlesDto.RecomendedProductsId.Contains(x.Id)).ToListAsync();

                var blogArticles = await _context.BlogArticles
                    .Where(x => blogArticlesDto.BlogArticlesId.Contains(x.Id)).ToListAsync();

                var blogCategory = _context.BlogCategory.Find(blogArticlesDto.BlogCategoryId);


                var blogArticle = new BlogArticle
                {
                    Description = blogArticlesDto.Description,
                    HtmlH1 = blogArticlesDto.HtmlH1,
                    MetaDescription = blogArticlesDto.MetaDescription,
                    MetaTitle = blogArticlesDto.MetaTitle,
                    Name = blogArticlesDto.Name,
                    MetaKeywords = blogArticlesDto.MetaKeywords,
                    Sort = blogArticlesDto.Sort,
                    Status = blogArticlesDto.Status,
                    RecomendedProducts = recomendedProducts,
                    BlogArticles = blogArticles,
                    BlogCategory = blogCategory,
                    Picture = file
                };
                _context.Add(blogArticle);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        /// <inheritdoc />
        public Result DeleteBlogArticle(List<long> ids)
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
    }
}