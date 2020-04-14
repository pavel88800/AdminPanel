namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    public interface IProductService
    {
        /// <summary>
        ///     Получить все товары.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetProductAsync(int offset, int count);

        /// <summary>
        ///     Получить товар по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetProductById(long id);

        /// <summary>
        ///     Создать товар.
        /// </summary>
        /// <returns></returns>
        Task<Result> AddProduct(ProductDto productDto);

        /// <summary>
        ///     Удалить товары по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteProduct(List<long> ids);
    }
}