namespace APP.BL.Interfaces
{
    using System.Threading.Tasks;
    using APP.BL.Dto;
    using APP.DB.Models;
    using APP.Models.Results;

    /// <summary>
    ///     Интерфейс по работе с ролями.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        ///     Создать роль.
        /// </summary>
        /// <returns></returns>
        Task<Result> CreateRole(RoleDto dto);

        /// <summary>
        ///     Редактировать роль.
        /// </summary>
        /// <returns></returns>
        Result UpdateRole(RoleDto dto);

        /// <summary>
        ///     Получить роли.
        /// </summary>
        /// <param name="offset">отступ.</param>
        /// <param name="count">кол-во.</param>
        /// <returns></returns>
        Task<OffsetEntitiesDto> GetRoles(int offset, int count);

        /// <summary>
        ///     Получить роль по идентификатору.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        Task<Role> GetRole(long id);

        /// <summary>
        ///     Удалить роль.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        Result DeleteRole(long[] id);
    }
}