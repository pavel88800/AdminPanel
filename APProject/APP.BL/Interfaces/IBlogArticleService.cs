using System.Collections.Generic;
using System.Threading.Tasks;
using APP.BL.Dto;
using APP.Models.Results;

namespace APP.BL.Interfaces
{
    /// <summary>
    ///     Интерфейс для работы с <see cref="BlogArticleService" />
    /// </summary>
    public interface IBlogArticleService
    {
        /// <summary>
        ///     Получить все статьи.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetBlogArticleAsync(int offset, int count);

        /// <summary>
        ///     Получить статью по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetBlogArticleById(long id);

        /// <summary>
        ///     Создать статью.
        /// </summary>
        /// <returns></returns>
        Task<Result> AddBlogArticle(BlogArticlesDto blogArticlesDto);

        /// <summary>
        ///     Удалить статьи по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteBlogArticle(List<long> ids);

        /// <summary>
        ///     Обновить статью.
        /// </summary>
        /// <returns></returns>
        Result UpdateBlogArticle(BlogArticlesDto blogArticlesDto);
    }
}