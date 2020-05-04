namespace APProject.Controllers.Api
{
    using APP.DocsModule.GoogleSheets.Interfaces;
    using APP.DocsModule.GoogleSheets.Services;
    using APProject.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    public class GoogleSheetsController : BaseApiAuthController
    {
        private readonly IGoogleSheetsService _googleSheets;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="googleSheets"></param>
        public GoogleSheetsController(IGoogleSheetsService googleSheets)
        {
            _googleSheets = googleSheets;
        }

        /// <summary>
        ///     Записать в таблицу данные из БД.
        /// </summary>
        [HttpPost]
        public void CreateSheet()
        {
            _googleSheets.CreateEntry();
        }

        /// <summary>
        ///     Получить информацию  из таблицы.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetInformationSheet()
        {
            var result = _googleSheets.ReadEntries();
            return Ok(result);
        }

        /// <summary>
        ///     Отчистить таблицу.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult ClearTable()
        {
            return Ok(_googleSheets.DeleteEntry());
        }
    }
}