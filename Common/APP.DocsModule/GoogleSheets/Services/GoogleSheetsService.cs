using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using APP.DB;
using APP.DB.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.EntityFrameworkCore;

namespace APP.DocsModule.GoogleSheets.Services
{
    public class GoogleSheetsService
    {
        private static readonly string[] Scopes = {SheetsService.Scope.Spreadsheets};
        private static readonly string ApplicationName = "Current Legislators";
        private static readonly string SpreadsheetId = "1e6sal15RxdXA12pcyYL0RafIgsql5IVJ3u-epv1FXpo";
        private static readonly string sheet = "Test";
        private static readonly SheetsService service = CreateServiceSheets();
        private static readonly string RANGE = $"{sheet}!A:F";
        private readonly PanelContext _context;

        /// <summary>
        ///     Множество.
        /// </summary>
        private readonly DbSet<object> _set;

        public GoogleSheetsService(PanelContext context)
        {
            _context = context;
        }

        public void ReadEntries()
        {
            var request =
                service.Spreadsheets.Values.Get(SpreadsheetId, RANGE);

            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
                foreach (var row in values)
                    // Print columns A to F, which correspond to indices 0 and 4.
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", row[0], row[1], row[2], row[3], row[4],
                        row[5]);
            else
                Console.WriteLine("No data found.");
        }

        /// <summary>
        ///     Метод записи в гугл таблицу
        /// </summary>
        /// <remarks>Пока запись велется только для товаров. т.к. я хз как сделать динамически.</remarks>
        public void CreateEntry()
        {
            var products = _context.Products.ToList();

            SetCell(products, true);
            SetCell(products);
        }

        /// <summary>
        ///     Метод записи в ячейку.
        /// </summary>
        /// <param name="products"> Список продуктов. </param>
        /// <param name="isHead">Запись заголовока. DEFAULT - FALSE</param>
        private void SetCell(List<Product> products, bool isHead = false)
        {
            var listObjectHead = new List<object>();
            var listObject = new List<object>();

            foreach (var p in products)
            {
                var fields = p.GetType().GetProperties(BindingFlags.Public |
                                                       BindingFlags.NonPublic |
                                                       BindingFlags.Instance);

                foreach (var field in fields)
                {
                    if (field.Name == "Manufacturer" ||
                        field.Name == "Categories" ||
                        field.Name == "Picture" ||
                        field.Name == "RecomendedProducts" ||
                        field.Name == "Pictures" ||
                        field.Name == "VideoProduct" ||
                        field.Name == "Characteristics")
                        continue;

                    var value = field.GetValue(p);

                    if (value == null)
                        continue;

                    listObjectHead.Add(field.Name);
                    listObject.Add(value);
                }

                var valueRange = new ValueRange();
                valueRange.Values = new List<IList<object>> {isHead ? listObjectHead : listObject};
                var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, RANGE);
                appendRequest.ValueInputOption =
                    SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                appendRequest.Execute();

                if (isHead)
                    break;

                listObject = new List<object>();
            }
        }

        public void UpdateEntry()
        {
            var valueRange = new ValueRange();

            var oblist = new List<object> {"updated"};
            valueRange.Values = new List<IList<object>> {oblist};

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, RANGE);
            updateRequest.ValueInputOption =
                SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = updateRequest.Execute();
        }

        public void DeleteEntry()
        {
            var requestBody = new ClearValuesRequest();

            var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, SpreadsheetId, RANGE);
            var deleteReponse = deleteRequest.Execute();
        }

        private static SheetsService CreateServiceSheets()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("MyWeb2-01d154cc1f9a.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            return new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }
    }
}