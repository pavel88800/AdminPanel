using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Категории блога.
    /// </summary>
    public class BlogCategory : BaseMetaInformation
    {
        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Родительская категория.
        /// </summary>
        public BlogCategory BlogCategories { get; set; }

        /// <summary>
        ///     Изображение.
        /// </summary>
        public Picture Picture { get; set; }
    }
}