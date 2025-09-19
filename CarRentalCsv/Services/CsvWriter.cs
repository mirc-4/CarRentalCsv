using CarRentalCsv.Models;
using System.Text;

namespace CarRentalCsv.Services
{
    /// <summary>
    /// Schreibt Listen von ICsvWriteable als CSV in wwwroot/exports und gibt die Web-URL zurück.
    /// </summary>
    public sealed class CsvWriter
    {
        private readonly IWebHostEnvironment _env;

        public CsvWriter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string Write<T>(IEnumerable<T> items, string fileName) where T : ICsvWriteable
        {
            var webroot = _env.WebRootPath ?? Path.Combine(AppContext.BaseDirectory, "wwwroot");
            var exportDir = Path.Combine(webroot, "exports");
            Directory.CreateDirectory(exportDir);

            var path = Path.Combine(exportDir, fileName);

            using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);
            using var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true)); // UTF-8 mit BOM

            if (items != null && items.Any())
            {
                var header = string.Join(',', items.First().GetCsvHeader().Select(CsvUtil.E));
                writer.WriteLine(header);

                foreach (var item in items)
                {
                    writer.WriteLine(item.ToCsv());
                }
            }

            // relative URL zum Abruf im Browser
            return $"/exports/{fileName}";
        }
    }

    /// <summary>
    /// CSV-Helfer: korrektes Escaping für Felder mit Anführungszeichen, Kommas oder Zeilenumbrüchen.
    /// </summary>
    public static class CsvUtil
    {
        public static string E(string? value)
        {
            value ??= string.Empty;
            var needsQuotes = value.Contains('"') || value.Contains(',') || value.Contains('\n') || value.Contains('\r');
            if (value.Contains('"'))
            {
                value = value.Replace("\"", "\"\"");
            }
            return needsQuotes ? $"\"{value}\"" : value;
        }
    }
}
