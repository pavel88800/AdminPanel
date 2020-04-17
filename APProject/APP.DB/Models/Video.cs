namespace APP.DB.Models
{
    using System.Collections.Generic;
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Видео.
    /// </summary>
    public class Video : BaseIdEntity
    {
        /// <summary>
        ///     Конструктор.
        /// </summary>
        public Video()
        {
            VideoProduct = new List<VideoProduct>();
        }

        /// <summary>
        ///     Наименование.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Ссылка.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        ///     Идентификатор категории в которой находится видео на Ютубе.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        ///     Идентификатор плейлиста в котором находится видер на Ютубе.
        /// </summary>
        public string PlaylistId { get; set; }

        /// <summary>
        ///     Ссылка на товары.
        /// </summary>
        public List<VideoProduct> VideoProduct { get; set; }
    }
}