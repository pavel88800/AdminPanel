namespace APP.DB.Models
{
    public class OrderProduct
    {
        /// <summary>
        ///     Заказ.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        ///     Идентификатор заказа
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        ///     Товар.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        ///     Идентификатор товара.
        /// </summary>
        public long ProductId { get; set; }
    }
}