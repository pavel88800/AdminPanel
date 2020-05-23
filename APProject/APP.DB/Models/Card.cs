namespace APP.DB.Models
{
    using System;
    using System.Collections.Generic;
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Карточка доски.
    /// </summary>
    public class Card : BaseIdNameEntity
    {
        /// <summary>
        ///     Связанные пользователи.
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        ///     CheckList.
        /// </summary>
        public List<Task> CheckList { get; set; }

        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        ///     Срок.
        /// </summary>
        public DateTime Limitation { get; set; }

        /// <summary>
        ///     Прикрепляемые файлы.
        /// </summary>
        public byte[] Attachment { get; set; }

        /// <summary>
        ///     Дата создания.
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        ///     Колонка.
        /// </summary>
        public Column Column { get; set; }
    }
}