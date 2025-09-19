using CarRentalCsv.Services;


namespace CarRentalCsv.Models;

public sealed class Benutzer : ICsvWriteable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;

    public string[] GetCsvHeader() => new[] { "Id", "Name", "Adresse" };

    public string ToCsv()
        => string.Join(',', CsvUtil.E(Id.ToString()), CsvUtil.E(Name), CsvUtil.E(Adresse));
}
