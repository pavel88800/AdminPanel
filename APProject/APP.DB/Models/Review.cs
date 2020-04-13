using System;
using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    /// Отзывы товара.
    /// </summary>
    public class Review:BaseIdEntity
    {
        /// <summary>
        ///     Автор отзыва.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Статья блога.
        /// </summary>
        public Product Product { get; set; }

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