using APP.BL.Dto;

namespace APP.BL.Interfaces
{
    using System.Collections.Generic;
    using APP.Models.Results;

    /// <summary>
    /// Интерфейс по работе с ролями.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        ///     Создать роль.
        /// </summary>
        /// <returns></returns>
        Result CreateRole(RoleDto dto);

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
        List<RoleDto> GetRoles(int offset, int count);

        /// <summary>
        ///     Получить роль по идентификатору.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        RoleDto GetRole(long id);

        /// <summary>
        ///     Удалить роль.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        RoleDto DeleteRole(long id);
    }
}