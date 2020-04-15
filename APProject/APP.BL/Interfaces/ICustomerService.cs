namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    /// <summary>
    ///     Интерфейс по работе с покупателями.
    /// </summary>
    internal interface ICustomerService
    {
        /// <summary>
        ///     Получить все категории.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetCustomerAsync(int offset, int count);

        /// <summary>
        ///     Получить категорию по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetCustomerById(long id);

        /// <summary>
        ///     Создать категорию .
        /// </summary>
        /// <returns></returns>
        Task<Result> AddCustomer();

        /// <summary>
        ///     Удалить категории по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteCustomer(List<long> ids);
    }
}