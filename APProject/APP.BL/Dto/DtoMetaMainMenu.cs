using System.Collections.Generic;

namespace APP.BL.Dto
{
    /// <summary>
    ///     Dto для выдачи метаданных меню.
    /// </summary>
    public class DtoMetaMainMenu
    {
        /// <summary>
        ///     Список Главного меню
        /// </summary>
        public IEnumerable<string> CatalogMenu { get; set; }

        /// <summary>
        ///     Меню блога
        /// </summary>
        public IEnumerable<string> BlogMenu { get; set; }
    }
}