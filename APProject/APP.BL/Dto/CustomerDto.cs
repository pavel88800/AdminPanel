namespace APP.BL.Dto
{
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Дто по работе покупателями.
    /// </summary>
    public class CustomerDto : BaseIdNameEntity
    {
        /// <summary>
        ///     Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     E-mail.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Телефон.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     Факс.
        /// </summary>
        public string Faxs { get; set; }

        /// <summary>
        ///     Компания.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        ///     Адрес.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Город.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Страна.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Регион.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        ///     Почтовый индекс.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        ///     Ip - адрес.
        /// </summary>
        public string Ip { get; set; }
    }
}