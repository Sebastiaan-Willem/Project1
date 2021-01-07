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
            dier.MaakDierenLijstAan();
            
            do
            {
                Console.Clear();

                Console.WriteLine("Welkom in Dierentuin WoopDeeZoo!");
                Console.WriteLine("Gelieve een optie te selecteren:");
                Console.WriteLine("***********************************************");
                Console.WriteLine("A: Voeg een dier toe aan de database.");
                Console.WriteLine("B: Bekijk de database van dierentuin Ikweetgeennaam.");
                Console.WriteLine("C: Bekijk data van een dier op basis van ID.");
                Console.WriteLine("D: Wijzig Data van een dier.");
                Console.WriteLine("E: Verwijderen van een dier.");
                Console.WriteLine("F: Bekijk lijst overleden dieren.");
                Console.WriteLine("Q: Sluit het menu af");

                //dier.PrintDierenLijst();

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.A:

                            Console.Clear();
                            dier.VoegDierToe();
                        break;

                    case ConsoleKey.B:

                            Console.Clear();
                            dier.PrintDierenLijst(fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST));
                            Console.WriteLine("Duw op Enter om terug te keren naar het menu.");
                            Console.ReadLine();
                        break;
                    case ConsoleKey.C:

                            Console.Clear();
                            Console.WriteLine("Geef het ID van het dier dat u wenst op te vragen.");
                        //dier.PrintDierMetId(fileReaderWriter.ReadDataLineFromFile(Convert.ToInt32(Console.ReadLine())));
                            dier.PrintDierMetId(Convert.ToInt32(Console.ReadLine()));
                            Console.WriteLine("Duw op Enter om terug te keren naar het menu.");
                            Console.ReadLine();
                       
                        break;
                    case ConsoleKey.D:

                            Console.Clear();
                            dier.WijzigData();
                            Console.WriteLine("Duw op Enter om terug te keren naar het menu.");
                            Console.ReadLine();
                        break;

                    case ConsoleKey.E:

                            Console.Clear();

                            dier.VerwijderDier();
                            Console.WriteLine("Duw op Enter om terug te keren naar het menu.");
                            Console.ReadLine();
                            break;
                    case ConsoleKey.F:

                            Console.Clear();
                            dier.PrintDierenLijst(fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_DEAD));
                            Console.WriteLine("Duw op Enter om terug te keren naar het menu.");
                            Console.ReadLine();
                        break;

                    case ConsoleKey.Q:

                            fileReaderWriter.UpdateDataToFile(dier.GetDierenLijst().ToArray());
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
