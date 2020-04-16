namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    public interface IOrderService
    {
        /// <summary>
        ///     Получить все заказы.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetOrderAsync(int offset, int count);

        /// <summary>
        ///     Получить заказ по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetOrderById(long id);

        /// <summary>
        ///     Создать заказ .
        /// </summary>
        /// <returns></returns>
        Task<Result> AddOrder(OrderDto orderDto);

        /// <summary>
        ///     Удалить заказы по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteOrder(List<long> ids);

        /// <summary>
        ///     Обновить заказ.
        /// </summary>
        /// <param name="orderDto">.</param>
        /// <returns></returns>
        Result UpdateOrder(OrderDto orderDto);
    }
}