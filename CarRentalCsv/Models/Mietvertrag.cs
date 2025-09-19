using CarRentalCsv.Services;


namespace CarRentalCsv.Models;

public sealed class Mietvertrag : ICsvWriteable
{
    public int Id { get; set; }
    public Benutzer Benutzer { get; set; } = new();
    public Auto Auto { get; set; } = new();
    public DateTime StartDatum { get; set; }
    public DateTime EndDatum { get; set; }
    public decimal PreisProTag { get; set; }

    public string[] GetCsvHeader() => new[]
    {
        "Id", "BenutzerId", "BenutzerName", "AutoId", "AutoBezeichnung", "StartDatum", "EndDatum", "PreisProTag"
    };

    public string ToCsv()
        => string.Join(',',
            CsvUtil.E(Id.ToString()),
            CsvUtil.E(Benutzer.Id.ToString()),
            CsvUtil.E(Benutzer.Name),
            CsvUtil.E(Auto.Id.ToString()),
            CsvUtil.E($"{Auto.Marke} {Auto.Modell}"),
            CsvUtil.E(StartDatum.ToString("yyyy-MM-dd")),
            CsvUtil.E(EndDatum.ToString("yyyy-MM-dd")),
            CsvUtil.E(PreisProTag.ToString(System.Globalization.CultureInfo.InvariantCulture)));
}
