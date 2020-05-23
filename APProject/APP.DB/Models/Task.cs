namespace APP.DB.Models
{
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Задачи.
    /// </summary>
    public class Task : BaseIdEntity
    {
        /// <summary>
        ///     Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Статус
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///     Карточка.
        /// </summary>
        public Card Card { get; set; }
    }
}