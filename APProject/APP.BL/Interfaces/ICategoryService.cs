namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    internal interface ICategoryService
    {
        /// <summary>
        ///     Получить все категории.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetCategoriesAsync(int offset, int count);

        /// <summary>
        ///     Получить категорию по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<OffsetEntitiesDto> GetCategoryById(long id);

        /// <summary>
        ///     Создать категорию .
        /// </summary>
        /// <returns></returns>
        Task<Result> AddCategory();

        /// <summary>
        ///     Удалить категории по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteCategory(List<long> ids);
    }
}