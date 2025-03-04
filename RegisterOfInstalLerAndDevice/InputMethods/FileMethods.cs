using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Data;
using RegisterOfInstalLerAndDevice.Entities;
using RegisterOfInstalLerAndDevice.Repositories;
namespace RegisterOfInstalLerAndDevice.InputMethods;

public class FileMethods : Installer
{
    public const string filename = "InstallersList.txt";
    //public List<string> installer = 
    public FileMethods()
    {
    }
    public void SaveToFile2(List<string> txt, string fileName)
    {
        foreach (var t in txt)
        {

            string[] pol = t.Split(',');
            {
                string p1 = pol[0];
                string p2 = pol[1];
                string p3 = pol[2];
                string p4 = pol[3];
                string p5 = pol[4];
                string p6 = pol[5];
            }
            using (var writer = File.AppendText(fileName))
            {
                if (t != null)
                {
                    writer.WriteLine($"{pol[0]},{pol[1]},{pol[2]},{pol[3]},{pol[4]},{pol[5]}");
                }
            }
        }
    }
    public void SaveToFile3(List<string> txt, string fileName)
    {
        foreach (var t in txt)
        {

            string[] pol = t.Split(',');
            {
                string p1 = pol[0];
                string p2 = pol[1];
                string p3 = pol[2];
                string p4 = pol[3];
                string p5 = pol[4];

            }
            using (var writer = File.AppendText(fileName))
            {
                if (t != null)
                {
                    writer.WriteLine($"{pol[0]},{pol[1]},{pol[2]},{pol[3]},{pol[4]}");
                }
            }
        }
    }

    public List<string> ReadFile()
    {
        var list = new List<string>();
        if (File.Exists(filename))
        {
            using (var reader = File.OpenText(filename))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] l = line.Split(",");
                    string l1 = l[0];
                    string l2 = l[1];
                    string l3 = l[2];
                    string l4 = l[3];
                    string l5 = l[4];
                    string l6 = l[5];
                    list.Add(line);
                    line = reader.ReadLine();
                }
            }
        }
        else { Console.WriteLine("Plik Nie istnieje"); }
        return list;
    }


    public void WriteFileToConsole()
    {
        var lista = new Installer();
        List<string> list = ReadFile();
        Console.WriteLine(list.Count);
        foreach (var inst in list)
        {
            Console.WriteLine(inst);
        }
        Console.ReadLine();
    }
}