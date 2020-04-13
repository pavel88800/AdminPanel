using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Сущность оперирующая категориями.
    /// </summary>
    public class Category : BaseMetaInformation
    {
        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Родительская категория.
        /// </summary>
        public Category ParentCategory { get; set; }

        /// <summary>
        ///     Изображние категории.
        /// </summary>
        public Picture Pictures { get; set; }
        
    }
}