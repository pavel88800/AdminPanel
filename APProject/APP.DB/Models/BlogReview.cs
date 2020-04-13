using System;
using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Отзывы блога.
    /// </summary>
    public class BlogReview : BaseIdEntity
    {
        /// <summary>
        ///     Автор отзыва.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Статья блога.
        /// </summary>
        public BlogArticle BlogArticle { get; set; }

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