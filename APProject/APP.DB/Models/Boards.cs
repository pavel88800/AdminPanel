namespace APP.DB.Models
{
    using APP.Models.BaseModelsEntities;

    /// <summary>
    ///     Доска.
    /// </summary>
    public class Boards : BaseIdNameEntity
    {
        /// <summary>
        ///     Цвет фона.
        /// </summary>
        public string BackgroundColor { get; set; }
    }
}