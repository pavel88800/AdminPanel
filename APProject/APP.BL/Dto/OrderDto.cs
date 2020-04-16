using System;
using System.Collections.Generic;
using APP.Models.BaseModelsEntities;

namespace APP.BL.Dto
{
    public class OrderDto : BaseIdEntity
    {
        /// <summary>
        ///     Покупатель.
        /// </summary>
        public long CustomerId { get; set; }

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
        public long[] ProductsId { get; set; }
    }
}