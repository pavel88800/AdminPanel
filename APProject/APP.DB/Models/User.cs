using System.ComponentModel.DataAnnotations;
using System.Data;

namespace APP.DB.Models
{
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Пользователи.
    /// </summary>
    public class User : BaseIdNameEntity
    {
        /// <summary>
        ///     Пароль.
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        ///     Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///     Почта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Город.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Роль.
        /// </summary>
        public Role Role { get; set; }
    }
}