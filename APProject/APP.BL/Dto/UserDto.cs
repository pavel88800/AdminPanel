namespace APP.BL.Dto
{
    using APP.Models.BaseModelsEntities;

    public class UserDto : BaseIdNameEntity
    {
        /// <summary>
        ///     Пароль.
        /// </summary>
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
        public long RoleId { get; set; }
    }
}