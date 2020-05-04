namespace APP.BL.Dto
{
    using System.Collections.Generic;
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     ДТО для работы с ролями.
    /// </summary>
    public class RoleDto : BaseIdNameEntity
    {
        /// <summary>
        ///     Список пользователей входящий в роль.
        /// </summary>
        public List<long> UsersId { get; set; }
    }
}