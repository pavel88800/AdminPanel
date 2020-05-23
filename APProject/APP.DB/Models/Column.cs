namespace APP.DB.Models
{
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Колонка
    /// </summary>
    public class Column : BaseIdEntity
    {
        /// <summary>
        ///     Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Цвет фона
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        ///     Доска
        /// </summary>
        public Boards Board { get; set; }

        /// <summary>
        ///     Позиция
        /// </summary>
        public int Position { get; set; }
    }
}