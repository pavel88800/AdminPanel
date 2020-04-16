namespace APP.DB.Models
{
    using System.Collections.Generic;
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Категории блога.
    /// </summary>
    public class BlogCategory : BaseMetaInformation
    {
        public BlogCategory()
        {
            BlogCategories = new List<BlogCategory2BlogCategory>();
        }

        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Родительская категория.
        /// </summary>
        public List<BlogCategory2BlogCategory> BlogCategories { get; set; }

        /// <summary>
        ///     Изображение.
        /// </summary>
        public Picture Picture { get; set; }
    }
}