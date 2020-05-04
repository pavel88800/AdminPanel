namespace APP.DocsModule.GoogleSheets.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using APP.DB;
    using APP.DB.Models;
    using APP.DocsModule.GoogleSheets.Interfaces;
    using APP.Models.Results;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Sheets.v4;
    using Google.Apis.Sheets.v4.Data;

    /// <summary>
    ///     Сервис по работе с
    /// </summary>
    public class GoogleSheetsService : IGoogleSheetsService
    {
        private static readonly string[] Scopes = {SheetsService.Scope.Spreadsheets};
        private static readonly string ApplicationName = "Current Legislators";
        private static readonly string SpreadsheetId = "1e6sal15RxdXA12pcyYL0RafIgsql5IVJ3u-epv1FXpo";
        private static readonly string sheet = "Test";
        private static readonly SheetsService service = CreateServiceSheets();
        private static readonly string RANGE = $"{sheet}!A:Z";
        private readonly PanelContext _context;

        /// Ссылка на документ.
        /*https://docs.google.com/spreadsheets/d/1e6sal15RxdXA12pcyYL0RafIgsql5IVJ3u-epv1FXpo/edit?usp=sharing*/

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="context"></param>
        public GoogleSheetsService(PanelContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IList<IList<object>> ReadEntries()
        {
            var request =
                service.Spreadsheets.Values.Get(SpreadsheetId, RANGE);

            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
                return values;

            return null;
        }

        /// <inheritdoc />
        public void CreateEntry()
        {
            var products = _context.Products.ToList();

            SetCell(products, true);
            SetCell(products);
        }

        /// <inheritdoc />
        public Result DeleteEntry()
        {
            var requestBody = new ClearValuesRequest();

            var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, SpreadsheetId, RANGE);
            deleteRequest.Execute();

            return Result.Ok();
        }

        /// <summary>
        ///     Получаем список отображаемых полей для записи
        /// </summary>
        /// <param name="product">Товар</param>
        /// <param name="fields">Все поля товара.</param>
        /// <param name="listObjectHead">Возвращаемые имена полей.</param>
        /// <param name="listObject">Возвращаемые значения полей.</param>
        private void GetField(Product product, PropertyInfo[] fields, ref List<object> listObjectHead,
            ref List<object> listObject)
        {
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

                var value = field.GetValue(product);

                if (value == null)
                    continue;

                listObjectHead.Add(field.Name);
                listObject.Add(value);
            }
        }

        /// <summary>
        ///     Создать сервис для работы с гугл таблицами.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        ///     Метод записи в ячейку.
        /// </summary>
        /// <param name="products"> Список продуктов. </param>
        /// <param name="isHead">Запись заголовока. DEFAULT - FALSE</param>
        private void SetCell(List<Product> products, bool isHead = false)
        {
            var listObjectHead = new List<object>();
            var listObject = new List<object>();

            foreach (var product in products)
            {
                var fields = product.GetType().GetProperties(BindingFlags.Public |
                                                             BindingFlags.NonPublic |
                                                             BindingFlags.Instance);

                GetField(product, fields, ref listObjectHead, ref listObject);

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
    }
}