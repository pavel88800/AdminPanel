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
    ///     Сервис по работе со статьями.
    /// </summary>
    public class ArticleService : AbstractGetService<Articles>, IArticleService
    {
        /// <summary>
        ///     Контект БД.
        /// </summary>
        private readonly PanelContext _context;

        /// <summary>
        ///     Контроллер.
        /// </summary>
        /// <param name="context">Контект БД.</param>
        public ArticleService(PanelContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<OffsetEntitiesDto> GetArticlesAsync(int offset, int count)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public async Task<ArticlesDto> GetArtcileById(long id)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public async Task<Result> AddArticle(ArticlesDto articlesDto)
        {
            throw new Exception();
        }

        /// <inheritdoc />
        public Result DeleteArticles(List<long> ids)
        {
            throw new Exception();
        }
    }
}