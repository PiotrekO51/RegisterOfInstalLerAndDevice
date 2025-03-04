

using System.Text;

namespace RegisterOfInstalLerAndDevice.Entities;

public class Installer : EntityBase
{
    
    public string Name { get; set; }
    public string SurName { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Premisions { get; set; }

    public override string ToString() => $"ID: {Id}.Nazwa firmy: {CompanyName}. Imie: {Name}. Nazwisko: {SurName}. Miasto: {City}. Kod Pocztowy: {ZipCode}. NR Uprawnień: {Premisions}.";
    public string ToString2() => $"{CompanyName},{Name},{SurName},{City},{ZipCode},{Premisions}";

    public string ToString3()
    {
        StringBuilder sb = new StringBuilder(1024);
        
        sb.AppendLine($"Id: {Id}.   Firma : {CompanyName}");

        return sb.ToString();
    }
    public string ToString4()
    {
        StringBuilder sb = new StringBuilder(1024);
        sb.AppendLine($"            Imię  : {Name}.      Nazwisko: {SurName}.  NR uprawnień: {Premisions}");
        sb.AppendLine($"            Miasto: {City}.     Kod poczt: {ZipCode}");

        return sb.ToString();
    }
}
