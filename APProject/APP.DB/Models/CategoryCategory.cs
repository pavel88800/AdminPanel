namespace APP.DB.Models
{
    using APP.Models.BaseModelsEntities;

    public class CategoryCategory
    {
        /// <summary>
        ///     Категория 1
        /// </summary>
        public Category Category1 { get; set; }

        /// <summary>
        ///     Идентификатор категории 1
        /// </summary>
        public long Category1Id { get; set; }

        /// <summary>
        ///     Категория 2
        /// </summary>
        public Category Category2 { get; set; }

        /// <summary>
        ///     Идентификатор категории 2
        /// </summary>
        public long Category2Id { get; set; }
    }
}