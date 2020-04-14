namespace APP.DB.Models
{
    using System;
    using System.Collections.Generic;
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Сущность по работе с заказами
    /// </summary>
    public class Order : BaseIdEntity
    {
        /// <summary>
        ///     Покупатель.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        ///     Сумма итоговая.
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        ///     Время добавления.
        /// </summary>
        public DateTime TimeAdd { get; set; }

        /// <summary>
        ///     Время обновления.
        /// </summary>
        public DateTime TimeUpdate { get; set; }

        /// <summary>
        ///     Товары.
        /// </summary>
        public IList<Product> Products { get; set; }
    }
}