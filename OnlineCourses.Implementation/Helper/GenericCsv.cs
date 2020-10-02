using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
