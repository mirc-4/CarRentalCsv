using CarRentalCsv.Services;


namespace CarRentalCsv.Models;

public sealed class Auto : ICsvWriteable
{
    public int Id { get; set; }
    public string Marke { get; set; } = string.Empty;
    public string Modell { get; set; } = string.Empty;
    public int Baujahr { get; set; }
    public int Kilometerstand { get; set; }

    public string[] GetCsvHeader() => new[] { "Id", "Marke", "Modell", "Baujahr", "Kilometerstand" };

    public string ToCsv()
        => string.Join(',',
            CsvUtil.E(Id.ToString()),
            CsvUtil.E(Marke),
            CsvUtil.E(Modell),
            CsvUtil.E(Baujahr.ToString()),
            CsvUtil.E(Kilometerstand.ToString()));
}
