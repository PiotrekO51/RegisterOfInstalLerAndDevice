using RegisterOfInstalLerAndDevice.Data;
using RegisterOfInstalLerAndDevice.Entities;
using RegisterOfInstalLerAndDevice.Repositories;
using System;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace RegisterOfInstalLerAndDevice.InputMethods;

public class DeviceInput
{
    public const string filenameInstaller = "InstallersList.txt";
    public const string filenameDevice = "DeviceList.txt";
    List<string> deviceList = new();
    public DeviceInput()
    { }

    void AddDeviceList(string device)
    {
        deviceList.Add(device);
    }

    public void GetDevice()
    {
        var device = new SqlRepositories<Device>(new RegisterDbContext());

        int deviceCount = device.GetAll().Count();
        if (deviceCount == 0)
        {
            if (File.Exists(filenameDevice))
            {
                using (var reader = File.OpenText(filenameDevice))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] pole = line.Split(',');
                        string p1 = pole[0];
                        string p2 = pole[1];
                        string p3 = pole[2];
                        string p4 = pole[3];
                        string p5 = pole[4];
                        device.Add(new Device { Product = p1, SN = p2, CurrentDate = p3, LunchDate = p4, CompanyName = p5, } );
                        device.Save();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    

        bool Down = true;
        while (Down)
        {
            Console.Clear();
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("MENU DODAWANIA URZĄDZEŃ\n" +
                "");
            Console.WriteLine("Wybierz nr ID czynności lub wciśnij x w celu wyjścia\n" +
                "1: Rejestracja uruchomionego produktu\n" +
                "2: Lista zarejestrowanych urządzeń\n" +
                "X: Wyjście z funkcji rejestracji\n" +
                " ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddedDevice();
                    break;
                case "2":
                    DeviceList();
                    break;
                case "x":
                case "X":
                    Down = false;
                    break;
            }
           
        }
        void AddedDevice()
        {
            while (true)
            {
                string id = ProductTypList("Podaj ID wyboru produktu lub x w celu wyjścia ");
                if (id == "x")
                { break; }
                else
                {
                    int.TryParse(id, out int id2);
                    Console.WriteLine((ProductType)id2 - 1);
                    string sn = RegisterSn("Podaj numer seryjny SN;");
                    string dateTime = DateTime.Now.ToString();
                    string registrationDate = RegisterDate("Podaj datę uruchomienia YYYY,MM,DD");
                    string companyName = CompanyNameAdded("Wybierz ID: firmy uruchamiającej");
                    string productType = ((ProductType)id2 - 1).ToString();
                    device.Add(new Device { Product = ((ProductType)id2 - 1).ToString(), SN = sn, CurrentDate = dateTime, LunchDate = registrationDate, CompanyName = companyName, });
                    device.Save();
                    AddDeviceList($"{productType},{sn},{dateTime},{registrationDate},{companyName}");
                    Console.ReadLine();
                }
            }

            Console.Clear();
        }

        void DeviceList()
        {
            Console.Clear();
            Console.WriteLine("Lista zarejestrowanych urządzeń \n");
            foreach (var dev in device.GetAll())
            {
                if (device.GetAll().Count() == 0)
                {
                    Console.WriteLine("Brak urządzeń w bazie");
                    break;
                }
     
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(dev.ToString2());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(dev.ToString3());
            }
            Console.ReadLine();
        }

        string ProductTypList(string txt)
        {
            int id = 0;
            int count = 0;
            foreach (var product in Enum.GetValues(typeof(ProductType)))
            {
                count++;
                Console.WriteLine($"ID: {count} {product}");
            }
            Console.WriteLine("  ");
            Console.WriteLine($"{txt}\n" +
                $"");
            string idString = Console.ReadLine();
            if (int.TryParse(idString, out int id1))
            { id = id1; }
            return idString;
        }

        string RegisterSn(string txt)
        {
            while (true)
            {

                Console.WriteLine(txt);
                string stringS = Console.ReadLine();
                if (stringS != "" && txt == "Podaj numer seryjny SN;")
                {
                    return stringS;
                    break;
                }
                else { Console.WriteLine("Brak wpisu"); }
            }
        }

        string RegisterDate(string txt)
        {
            while (true)
            {
                Console.WriteLine(txt);
                string stringS = Console.ReadLine();
                if (DateOnly.TryParse(stringS, out DateOnly date))
                {
                    return date.ToString();
                    break;
                }
                else { Console.WriteLine("zły format RRRR.MM.DD"); }
            }
        }
        string CompanyNameAdded(string txt)
        {
            Console.Clear();
            string companyName = null;
            List<string> list = new();
            if (File.Exists(filenameInstaller))
            {
                using (var reader = File.OpenText(filenameInstaller))
                {
                    int count = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        count++;
                        string[] pole = line.Split(',');
                        list.Add(pole[0]);
                        Console.WriteLine($"ID: {count} Nazwa firmy: {pole[0]}");
                        line = reader.ReadLine();
                    }
                }
            }
            Console.WriteLine("\n" +
                "");
            Console.WriteLine(txt);
            string idName = Console.ReadLine();
            if (int.TryParse(idName, out int id))
                { int id2 = id; }

            companyName = list[id - 1];
            return companyName;
        }

        SaveToFile();
    }

    public void SaveToFile()
    {
        Console.Clear();
        var instal = new FileMethods();
        instal.SaveToFile3(deviceList, filenameDevice);
    }

    void EntryDeviceData()
    {

    }

    void WritingDeviceDataFile()
    {


    }
}
