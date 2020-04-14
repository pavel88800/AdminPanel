namespace APP.BL.Interfaces
{
    using APP.Models.Results;

    /// <summary>
    ///     Интерфейс для работы с мета-данными
    /// </summary>
    public interface IMetaService
    {
        /// <summary>
        ///     Получить мета-данные меню
        /// </summary>
        /// <returns></returns>
        Result GetMetaMenu();

        /// <summary>
        /// Получить метаданные информатиции
        /// </summary>
        /// <returns></returns>
        Result GetMetaInformation();
    }
}