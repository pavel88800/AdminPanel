namespace APP.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.BL.Interfaces;
    using APP.DB;
    using APP.DB.Models;
    using APP.Models.Results;

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
           var result = await GetPagesAsync(offset, count);
           return result;
        }

        /// <inheritdoc />
        public async Task<Result> GetArtcileById(long id)
        {
            var result = await GetItemById(id);
            return Result.Ok(result);
        }

        /// <inheritdoc />
        public async Task<Result> AddArticle(ArticlesDto articlesDto)
        {
            var article = new Articles
            {
                Id = articlesDto.Id,
                Description = articlesDto.Description,
                HtmlH1 = articlesDto.HtmlH1,
                MetaDescription = articlesDto.MetaDescription,
                MetaKeywords = articlesDto.MetaKeywords,
                MetaTitle = articlesDto.MetaTitle,
                Name = articlesDto.Name,
                Sort = articlesDto.Sort,
                Status = articlesDto.Status
            };
            try
            {
                _context.Add(article);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <inheritdoc />
        public Result DeleteArticles(List<long> ids)
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