namespace APP.BL.Dto
{
    using System;
    using APP.Models.BaseModelsEntities;

    public class ReviewDto : BaseIdEntity
    {
        /// <summary>
        ///     Автор отзыва.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Идентификатор продукта.
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        ///     Текст отзываю.
        /// </summary>
        public string TextReview { get; set; }

        /// <summary>
        ///     Рейтинг.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        ///     Дата создания.
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        ///     Статус.
        /// </summary>
        public bool Status { get; set; }
    }
}