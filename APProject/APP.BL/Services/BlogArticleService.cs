using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.BL.Interfaces;
using APP.BL.Mapping;
using APP.DB;
using APP.DB.Models;
using APP.Models.Results;

namespace APP.BL.Services
{
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
        public async Task<OffsetEntitiesDto> GetBlogArticleById(long id)
        {
            var result = await GetItemById(id);
            return new OffsetEntitiesDto{Entities = result};
        }

        /// <inheritdoc />
        public async Task<Result> AddBlogArticle(BlogArticlesDto articlesDto)
        {
            try
            {
                var article = BlogArticlesDtoBlogArticlesMapping.TransformBlogArticlesDtoToBlogArticles(articlesDto);
                await _context.AddAsync(article);
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}