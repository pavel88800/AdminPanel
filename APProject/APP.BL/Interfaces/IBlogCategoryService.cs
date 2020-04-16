namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.Models.Results;

    /// <summary>
    ///     Интерфейс по работе категориями.
    /// </summary>
    public interface IBlogCategoryService
    {
        /// <summary>
        ///     Получить все категории блога.
        /// </summary>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetCategoriesAsync(int offset, int count);

        /// <summary>
        ///     Получить категорию блога по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Статья</returns>
        Task<Result> GetCategoryById(long id);

        /// <summary>
        ///     Создать категорию блога.
        /// </summary>
        /// <returns></returns>
        Task<Result> AddCategory(BlogCategoryDto blogCategoryDto);

        /// <summary>
        ///     Удалить категории блога по идентификаторам.
        /// </summary>
        /// <param name="ids">Массив идентификаторов.</param>
        /// <returns></returns>
        Result DeleteCategory(List<long> ids);

        /// <summary>
        ///     Отредактировать категорию блога
        /// </summary>
        /// <param name="blogCategoryDto">DTO категории блога.</param>
        /// <returns></returns>
        Result UpdateCategory(BlogCategoryDto blogCategoryDto);
    }
}