using CarRentalCsv.Services;


namespace CarRentalCsv.Models;

public interface ICsvWriteable
{
    string ToCsv();
    string[] GetCsvHeader();
}
