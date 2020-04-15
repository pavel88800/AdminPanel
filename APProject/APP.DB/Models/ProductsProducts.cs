namespace APP.DB.Models
{
    /// <summary>
    ///     Сущность для связывания продукта и продукта.
    /// </summary>
    public class ProductsProducts
    {
        /// <summary>
        ///     Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Идентификатор родительского продукта
        /// </summary>
        public long Product1Id { get; set; }

        /// <summary>
        ///     Родительская сущность.
        /// </summary>
        public Product Product1 { get; set; }

        /// <summary>
        ///     Идентификатор дочернего продукта
        /// </summary>
        public long Product2Id { get; set; }

        /// <summary>
        ///     Дочерняя сущность
        /// </summary>
        public Product Product2 { get; set; }
    }
}