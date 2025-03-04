using Microsoft.EntityFrameworkCore;
using RegisterOfInstalLerAndDevice.Data;
using RegisterOfInstalLerAndDevice.Entities;
using RegisterOfInstalLerAndDevice.InputMethods;
namespace RegisterOfInstallerAndDevice;

internal class Program()
{
    private static void Main(string[] args)
    {
        Console.SetCursorPosition(30, 0);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("WITAMY W PROGRAME REJESTRACJI INSTALATORÓW I URZĄDZEŃ \n ");
        Thread.Sleep(1000);
        var dataInput = new InstallerInput();
        var deviceInput = new DeviceInput();
        var fileMethod = new FileMethods();
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("MENU WYBORU \n" +
                "Wybierz 1 , 2 lub -x-  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - Baza Instalatorów\n" +
                "2 - Wprowadzanie urządzeń\n" +
                "x - WYJSCIE Z PROGRAMU\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    dataInput.InstallerOperation();
                    break;
                case "2":
                    deviceInput.GetDevice();
                    break;
                case "x":
                    Close = false;
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("DZIĘKUJEMY ZA SKOŻYSTANIE Z PROGRAMU \n" +
            "\n" +
            "");
    }
}