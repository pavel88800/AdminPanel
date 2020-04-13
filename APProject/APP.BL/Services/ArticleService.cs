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
            return await GetPagesAsync(offset, count);
        }

        /// <inheritdoc />
        public async Task<ArticlesDto> GetArtcileById(long id)
        {
            var result = await GetItemById(id);
            return ArticleDtoArticleMapping.MapArticlesToArticlesDto(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddArticle(ArticlesDto articlesDto)
        {
            var article = ArticleDtoArticleMapping.MapArticlesDtoToArticles(articlesDto);

            await _context.AddAsync(article);
            await _context.SaveChangesAsync();
            return Result.Ok();
        }

        /// <inheritdoc />
        public Result DeleteArticles(List<long> ids)
        {
            DeleteItems(ids);
            return Result.Ok();
        }
    }
}