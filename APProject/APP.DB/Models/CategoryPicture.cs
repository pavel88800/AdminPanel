using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Сущность реализующая связь Category - Picture
    /// </summary>
    public class CategoryPicture
    {
        /// <summary>
        ///     Категория.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        ///     Идентификатор категории.
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>
        ///     Изображение.
        /// </summary>
        public Picture Picture { get; set; }

        /// <summary>
        ///     Идентификатор изображения.
        /// </summary>
        public long PictureId { get; set; }
    }
}