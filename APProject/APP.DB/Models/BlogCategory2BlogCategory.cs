namespace APP.DB.Models
{
    /// <summary>
    ///     Сущность для связи M2M для BlogCategory-BlogCategory.
    /// </summary>
    public class BlogCategory2BlogCategory
    {
        /// <summary>
        ///     Категория блога1.
        /// </summary>
        public BlogCategory BlogCategory1 { get; set; }

        /// <summary>
        ///     Идентификатор категории блога 1.
        /// </summary>
        public long BlogCategory1Id { get; set; }

        /// <summary>
        ///     Категория блога 2.
        /// </summary>
        public BlogCategory BlogCategory2 { get; set; }

        /// <summary>
        ///     Идентификатор категории блога2.
        /// </summary>
        public long BlogCategory2Id { get; set; }
    }
}