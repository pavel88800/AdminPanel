namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    public interface IManufacturerService
    {
        /// <summary>
        ///     Получить все производителей.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetManufacturerAsync(int offset, int count);

        /// <summary>
        ///     Получить производителя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetManufacturerById(long id);

        /// <summary>
        ///     Создать производителя .
        /// </summary>
        /// <returns></returns>
        Task<Result> AddManufacturer(ManufacturerDto manufacturerDto);

        /// <summary>
        ///     Удалить производителя по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteManufacturer(List<long> ids);

        /// <summary>
        ///     Обновление производителя.
        /// </summary>
        /// <param name="manufacturerDto">ДТО производителя.</param>
        /// <returns></returns>
        Result UpdateManufucturer(ManufacturerDto manufacturerDto);
    }
}