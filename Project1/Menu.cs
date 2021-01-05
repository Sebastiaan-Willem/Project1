using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class Menu
    {

        Dier dier = new Dier();
        FileReaderWriter fileReaderWriter = new FileReaderWriter();
        
        public void PrintMenu()
        {
            
            do
            {
                Console.Clear();

                Console.WriteLine("Welkom in Dierentuin Ikweetgeennaam!");
                Console.WriteLine("Gelieve een optie te selecteren:");
                Console.WriteLine("***********************************************");
                Console.WriteLine("A: Voeg een dier toe aan de database.");
                Console.WriteLine("B: Bekijk de database van dierentuin Ikweetgeennaam.");
                Console.WriteLine("C: Bekijk data van een dier op basis van ID.");
                Console.WriteLine("D: Wijzig Data van een Dier.");
                Console.WriteLine("Q: Sluit het menu af");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.A:
                        dier.VoegDierToe();
                        break;

                    case ConsoleKey.B:
                        dier.PrintDierenLijst(fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST));
                        Console.ReadLine();
                        break;
                    case ConsoleKey.C:
                        Console.WriteLine("Geef het ID van het dier dat u wenst op te vragen.");
                        dier.PrintDierMetId(fileReaderWriter.ReadDataLineFromFile(Convert.ToInt32(Console.ReadLine())));
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D:
                        dier.PrintDierenLijst(fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST));
                        Console.ReadLine();
                        break;

                    case ConsoleKey.Q:

                        Environment.Exit(0);
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n\n-- You entered a wrong key! --");
                        System.Threading.Thread.Sleep(2000);
                        Console.ResetColor();
                        break;
                }

            } while (true);
         
            
        }

    }
}
