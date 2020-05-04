namespace APP.DocsModule.GoogleSheets.Interfaces
{
    using System.Collections.Generic;
    using APP.Models.Results;

    /// <summary>
    ///     Интерфейс по работе с сервисами таблиц гугла.
    /// </summary>
    public interface IGoogleSheetsService
    {
        /// <summary>
        ///     Считать данные с гугл таблицы.
        /// </summary>
        /// <returns></returns>
        IList<IList<object>> ReadEntries();

        /// <summary>
        ///     Метод записи в гугл таблицу
        /// </summary>
        /// <remarks>Пока запись велется только для товаров. т.к. я хз как сделать динамически.</remarks>
        void CreateEntry();

        /// <summary>
        ///     Очистить таблицу.
        /// </summary>
        /// <returns></returns>
        Result DeleteEntry();
    }
}