namespace APP.Models.BaseModelsEntities
{
    /// <summary>
    ///     Базовая сущность для работы с метаданными.
    /// </summary>
    public class BaseMetaInformation : BaseIdNameEntity
    {
        /// <summary>
        ///     Отображение в заголовка H1.
        /// </summary>
        public string HtmlH1 { get; set; }

        /// <summary>
        ///     Мета Заголовок.
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        ///     Мета описание.
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///     Мета Ключевые слова.
        /// </summary>
        public string MetaKeywords { get; set; }
    }
}