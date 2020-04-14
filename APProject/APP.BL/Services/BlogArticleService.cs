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
            throw new Exception();
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetBlogArticleById(long id)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public async Task<Result> AddBlogArticle(BlogArticlesDto articlesDto)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public Result DeleteBlogArticle(List<long> ids)
        {
            throw new Exception();
        }
    }
}