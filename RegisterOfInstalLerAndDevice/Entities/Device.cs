
using System.Text;

namespace RegisterOfInstalLerAndDevice.Entities;

public class Device : EntityBase
{
    public string Product { get; set; }
    public string SN { get; set; }
    public string CurrentDate { get; set; }
    public string LunchDate { get; set; }
    public override string ToString() => $"{Product},{SN},{CurrentDate},{LunchDate},{CompanyName}";
    public string ToString2()
    {
        StringBuilder sB = new StringBuilder(1024);
        sB.AppendLine($"ID: {Id}.             TYP: {Product}");
        sB.AppendLine($"                       SN: {SN}.          Data Wprowadzenia:{CurrentDate}");
        sB.AppendLine($"        Data uruchomienia: {LunchDate}. Firma uruchamiająca: {CompanyName}");

        return sB.ToString();
    }
}