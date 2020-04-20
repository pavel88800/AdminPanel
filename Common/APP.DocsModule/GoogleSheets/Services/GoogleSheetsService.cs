namespace APP.DocsModule.GoogleSheets.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using APP.DB;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Sheets.v4;
    using Google.Apis.Sheets.v4.Data;

    public class GoogleSheetsService
    {
        private static readonly string[] Scopes = {SheetsService.Scope.Spreadsheets};
        private static readonly string ApplicationName = "Current Legislators";
        private static readonly string SpreadsheetId = "1e6sal15RxdXA12pcyYL0RafIgsql5IVJ3u-epv1FXpo";
        private static readonly string sheet = "Test";
        private static readonly SheetsService service = CreateServiceSheets();
        private readonly PanelContext _context;

        public GoogleSheetsService(PanelContext context)
        {
            _context = context;
        }

        public void ReadEntries()
        {
            var range = $"{sheet}!A:F";
            var request =
                service.Spreadsheets.Values.Get(SpreadsheetId, range);

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

        public void CreateEntry()
        {
            var range = $"{sheet}!A:Z";
            var valueRange = new ValueRange();

            var oblist = new List<object> {"Hello!", "This", "was", "insertd", "via", "C#"};

            valueRange.Values = new List<IList<object>> {oblist};

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption =
                SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        public void UpdateEntry()
        {
            var range = $"{sheet}!D543";
            var valueRange = new ValueRange();

            var oblist = new List<object> {"updated"};
            valueRange.Values = new List<IList<object>> {oblist};

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
            updateRequest.ValueInputOption =
                SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = updateRequest.Execute();
        }

        public void DeleteEntry()
        {
            var range = $"{sheet}!A543:F";
            var requestBody = new ClearValuesRequest();

            var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, SpreadsheetId, range);
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