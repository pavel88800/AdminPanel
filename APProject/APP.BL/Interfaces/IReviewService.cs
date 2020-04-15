namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    public interface IReviewService
    {
        /// <summary>
        ///     Получить все отзывы.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetReviewAsync(int offset, int count);

        /// <summary>
        ///     Получить отзыв по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetReviewById(long id);

        /// <summary>
        ///     Создать отзыв.
        /// </summary>
        /// <returns></returns>
        Task<Result> AddReview(ReviewDto reviewDto);

        /// <summary>
        ///     Удалить отзывы по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteReview(List<long> ids);

        /// <summary>
        ///     Редактировать отзыв.
        /// </summary>
        /// <param name="id">Идентификатор отзыва.</param>
        /// <returns></returns>
        Result UpdateReview(ReviewDto reviewDto);
    }
}