using CsvHelper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.DbTypes;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class CsvService : ICsv
    {
        private readonly IService _dbService;

        public CsvService(IService dbService)
        {
            _dbService = dbService;
        }

        public HttpResponseMessage GetCsv()
        {
            var data = _dbService.GetUsers();

            using (var mem = new MemoryStream())
            {
                using (var writer = new StreamWriter(mem))
                {
                    using (var csvWriter = new CsvWriter(writer))
                    {
                        csvWriter.Configuration.Delimiter = ";";
                        csvWriter.Configuration.HasHeaderRecord = true;

                        csvWriter.WriteHeader<Users>();

                        csvWriter.NextRecord();

                        csvWriter.WriteRecords(data.Users);

                        writer.Flush();
                        var result = Encoding.UTF8.GetString(mem.ToArray());

                        var response = SetResponseMessage(result);
                        return response;
                    }
                }
            }            
        }

        //private string GenerateCsv(IEnumerable<T> enumerable)
        //{
        //    using (var mem = new MemoryStream())
        //    {
        //        using (var writer = new StreamWriter(mem))
        //        {
        //            using (var csvWriter = new CsvWriter(writer))
        //            {
        //                csvWriter.Configuration.Delimiter = ";";
        //                csvWriter.Configuration.HasHeaderRecord = true;

        //                csvWriter.WriteHeader<Users>();

        //                csvWriter.NextRecord();

        //                csvWriter.WriteRecords(data.Users);

        //                writer.Flush();
        //                var result = Encoding.UTF8.GetString(mem.ToArray());

        //                var response = SetResponseMessage(result);
        //                return response;
        //            }
        //        }
        //    }
        //}

        private HttpResponseMessage SetResponseMessage(string result)
        {
            HttpResponseMessage csvFile = new HttpResponseMessage(HttpStatusCode.OK);
            csvFile.Content = new StringContent(result);
            csvFile.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            csvFile.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
            return csvFile;
        }
    }
}
