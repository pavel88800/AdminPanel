namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    /// <summary>
    /// Интерфейс по работе с отзывами блога
    /// </summary>
    internal interface IBlogRewiewService
    {
        /// <summary>
        ///     Получить все отзывы блога.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetBlogRewiewAsync(int offset, int count);

        /// <summary>
        ///     Получить отзыв блога по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetBlogRewiewById(long id);

        /// <summary>
        ///     Создать отзыв блога.
        /// </summary>
        /// <returns></returns>
        Task<Result> AddBlogRewiew();

        /// <summary>
        ///     Удалить отзывы блога по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteBlogRewiew(List<long> ids);
    }
}