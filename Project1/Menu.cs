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
                Console.WriteLine("F1: Voeg een dier toe aan de database.");
                Console.WriteLine("F2: Bekijk de database van dierentuin Ikweetgeennaam");
                Console.WriteLine("F3: Sluit het menu af");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.F1:
                        dier.VoegDierToe(dier);
                        break;

                    case ConsoleKey.F2:
                        dier.PrintDierenLijst(fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST));
                        Console.ReadLine();
                        break;

                    case ConsoleKey.F3:

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
