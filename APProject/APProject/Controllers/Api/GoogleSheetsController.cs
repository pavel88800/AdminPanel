using APP.DocsModule.GoogleSheets.Services;
using APProject.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace APProject.Controllers.Api
{
    public class GoogleSheetsController : BaseApiController
    {
        private readonly GoogleSheetsService _googleSheets;

        public GoogleSheetsController(GoogleSheetsService googleSheets)
        {
            _googleSheets = googleSheets;
        }

        [HttpPost]
        public void CreateSheet()
        {
            _googleSheets.CreateEntry();
        }
    }
}