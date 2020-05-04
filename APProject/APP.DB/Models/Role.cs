using System.Collections.Generic;
using APP.Models.BaseModelsEntities;

namespace APP.DB.Models
{
    /// <summary>
    ///     Ролевая модель.
    /// </summary>
    public class Role : BaseIdNameEntity
    {
        /// <summary>
        ///     Конструктор.
        /// </summary>
        public Role()
        {
            Users = new List<User>();
        }

        /// <summary>
        ///     Список пользователей входящий в роль.
        /// </summary>
        public List<User> Users { get; set; }
    }
}