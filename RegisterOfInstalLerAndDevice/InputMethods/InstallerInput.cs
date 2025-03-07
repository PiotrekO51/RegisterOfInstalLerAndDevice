using RegisterOfInstalLerAndDevice.Data;
using RegisterOfInstalLerAndDevice.Entities;
using RegisterOfInstalLerAndDevice.Repositories;
using System.Security;

namespace RegisterOfInstalLerAndDevice.InputMethods;

public class InstallerInput
{
    public const string filename = "InstallersList.txt";
    public InstallerInput()
    {

    }
    //List<string> installerList = new();
    //void AddInstaler(string lista)
    //{
    //    installerList.Add(lista);
    //}

    bool Close = true;
    public void InstallerOperation()
    {
        var itemAdded = new ItemAdded<Installer>(EmployeeAdded);
        var installerInput = new SqlRepositories<Installer>(new RegisterDbContext(), itemAdded);
        //var lista = new FileMethods();

        void EmployeeAdded(object item)
        {
            var itemAdded = (Installer)item;
            Console.Clear();
            Console.WriteLine($"Dodano nowego instalatora {itemAdded.CompanyName}");
            Thread.Sleep(10);
        }
        int cont = installerInput.GetAll().Count();

        if ( cont == 0 )
        {
            if (File.Exists(filename))
            {
                //Console.WriteLine("Wprowadznie listy instalatorów");
                //Thread.Sleep(1000);
                using (var reader = File.OpenText(filename))
                {
                    string l = reader.ReadLine();
                    while (l != null)
                    {
                        string[] li = l.Split(",");
                        string l1 = li[0];
                        string l2 = li[1];
                        string l3 = li[2];
                        string l4 = li[3];
                        string l5 = li[4];
                        string l6 = li[5];
                        installerInput.Add(new Installer { CompanyName = l1, Name = l2, SurName = l3, City = l4, ZipCode = l5, Premisions = l6 });
                        installerInput.Save();
                        l = reader.ReadLine();
                    }
                }
            }
            Console.Clear();
            Console.SetCursorPosition(10,0);
            Console.WriteLine("Wprowadznie listy instalatorów");
            Thread.Sleep(1000);
        }

        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            //Console.SetCursorPosition(5, 1);
            Console.WriteLine("Menu INSTALATORA \n" +
                "Wybierz nr ID aby wybrać czynność \n" +
                "\n" +
                "1 - Wprowadzanie instalatorów\n" +
                "2 - Lista Instalatorów\n" +
                "x - Powrót do MENU głównegp\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddingInstallers();
                    break;
                case "2":
                    ListInstallers1();
                    break;
                case "x":
                    Close = false;
                    break;
            }  
        }

        void AddingInstallers()
        {
            List<string> installerList = new();
           
            while (true)
            {
                Console.WriteLine("Postępuj zgodnie z pytaniami lub wciśnij x w celu wyjscia \n" +
                    "");
                Thread.Sleep(1500);
                Console.Clear();
                string companyName = InputD("Podaj nazwę firmy lub x w celu wyjscia");
                if (companyName == "X")
                { break; }
                string name = InputD("Podaj imię");
                string surName = InputD("Podaj nazwisko");
                string city = InputD("Podaj miasto");
                string zip = InputD("Podaj kod maiasta  xx-xxx  ");
                string premision = InputD("Podaj nr. uprawnień F-Gaz");
                Console.ForegroundColor = ConsoleColor.White;
                installerInput.Add(new Installer { CompanyName = companyName, Name = name, SurName = surName, City = city, ZipCode = zip, Premisions = premision });
                installerInput.Save();
                AddInstaler($"{companyName},{name},{surName},{city},{zip},{premision}");
                Console.Clear();
            }
            Console.Clear();
            void AddInstaler(string lista)
            {
                installerList.Add(lista);
            }
            Console.Clear();
            var instal = new FileMethods();
            instal.SaveToFile2(installerList, filename);
        }
        void ListInstallers1()
        {
            Console.Clear();
            Console.WriteLine("LISTA INSTALATORÓW\n" +
                "");
            foreach (var inst in installerInput.GetAll())
            {
                if (installerInput.GetAll().Count() == 0)
                {
                    Console.WriteLine("Brak instalatorów w bazie");
                    break;
                }
              
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine($"{inst.ToString3()}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{inst.ToString4()}");
            }
            Console.ReadLine();
        }
    }
        
    public void InputDeviceData()
    {
        Console.ReadLine();
        //Console.Clear();
        Console.WriteLine("Narazie jestem tutaj");
        Console.ReadLine();
        Console.Clear();
    }
    public string InputD(string txt)
    {
        string val2 = null;
        Console.WriteLine(txt);
        string val = Console.ReadLine();
        if (txt == "Podaj nazwę firmy lub x w celu wyjscia" || txt == "Podaj miasto" || txt == "Podaj nr. uprawnień F-Gaz")
        {
            val2 = val.ToUpper();
        }
        else { string val3 = char.ToUpper(val[0]) + val.Substring(1); val2 = val3; }
        return val2;
    }
}
