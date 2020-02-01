using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation.Helper
{
    public static class GenericCsv<T>
    {
        public static string GenerateCsv(IEnumerable<T> enumerable)
        {
            using (var mem = new MemoryStream())
            {
                using (var writer = new StreamWriter(mem))
                {
                    using (var csvWriter = new CsvWriter(writer))
                    {
                        csvWriter.Configuration.Delimiter = ";";
                        csvWriter.Configuration.HasHeaderRecord = true;

                        csvWriter.WriteHeader<T>();

                        csvWriter.NextRecord();

                        csvWriter.WriteRecords(enumerable);

                        writer.Flush();
                        var result = Encoding.UTF8.GetString(mem.ToArray());

                        return result;
                    }
                }
            }
        }

    }
}
