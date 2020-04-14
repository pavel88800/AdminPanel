using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.Models.Results;

namespace APP.BL.Interfaces
{
    /// <summary>
    ///     Интерфейс по работе со статьями.
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        ///     Получить все статьи.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetArticlesAsync(int offset, int count);

        /// <summary>
        ///     Получить статью по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetArtcileById(long id);

        /// <summary>
        ///     Создать статью.
        /// </summary>
        /// <returns></returns>
        Task<Result> AddArticle(ArticlesDto articlesDto);

        /// <summary>
        ///     Удалить статьи по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteArticles(List<long> ids);
    }
}