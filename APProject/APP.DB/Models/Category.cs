using System.Collections.Generic;
using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Сущность оперирующая категориями.
    /// </summary>
    public class Category : BaseMetaInformation
    {
        public Category()
        {
            ParentCategory = new List<CategoryCategory>();
            Pictures = new List<CategoryPicture>();
        }
        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Родительская категория.
        /// </summary>
        public List<CategoryCategory> ParentCategory { get; set; }

        /// <summary>
        ///     Изображние категории.
        /// </summary>
        public List<CategoryPicture> Pictures { get; set; }
        
    }
}