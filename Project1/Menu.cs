using System;
using WMPLib;

namespace Project1
{
    internal class Menu
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private Dier dier = new Dier();
        private FileReaderWriter fileReaderWriter = new FileReaderWriter();
        private readonly string path = $"C:\\Users\\{Environment.UserName}\\source\\repos\\Project1\\Project1\\sounds\\";

        public void PrintMenu()
        {
            dier.MaakDierenLijstAan();
            SpeelJungleGeluid();
            do
            {
                Console.Clear();

                PrintBanner();
                PrintMenuSelectie();
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
                        Console.WriteLine("Zoek en hoop dat werkt zonder errors:");
                        dier.ZoekOpInput();
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

                        Console.WriteLine("\n\n             -- Gelieve een geldige keuze te maken! --");
                        System.Threading.Thread.Sleep(2000);
                        Console.ResetColor();
                        break;
                }
            } while (true);
        }
        public void PrintTrein()
        {
            SpeelTreinGeluid();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int j = 0; j < 15; j++)
            {
                Console.Clear();

                // steam
                Console.WriteLine("   ...Welkom, druk op ENTER wanneer u aangekomen bent in...");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("                  WOOPDEEZ ");

                for (int s = 0; s < j / 2; s++)
                {
                    Console.Write("O ");
                }

                Console.WriteLine();

                var margin = "".PadLeft(j);
                Console.WriteLine(margin + "                _____      o");
                Console.WriteLine(margin + "       ____====  ]OO|_n_n__][.");
                Console.WriteLine(margin + "      [________]_|__|________)< ");
                Console.WriteLine(margin + "      [________]_|__|________)< ");
                Console.WriteLine(margin + "       oo\\_  oo  'oo OOOO-| oo\\_");
                Console.WriteLine("   +--+--+--+--+--+--+--+--+--+--+--+--+--+--+████████████████████████████");

                System.Threading.Thread.Sleep(500);

                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            Console.ResetColor();
            Console.ReadLine();
        }

        public void SpeelTreinGeluid()
        {
            string trein = "Train_Horn.mp3";
            player.settings.volume = 50;
            player.URL = path + trein;
        }

        public void SpeelJungleGeluid()
        {
            string trein = "rainforest_ambience.mp3";
            player.settings.volume = 50;
            player.URL = path + trein;
        }
        public void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string banner2 = @"
         __        _____   ___  ____  ____  _____ _____ ________   ___
         \ \      / / _ \ / _ \|  _ \|  _ \| ____| ____|__  / _ \ / _ \
          \ \ /\ / / | | | | | | |_) | | | |  _| |  _|   / / | | | | | |
           \ V  V /| |_| | |_| |  __/| |_| | |___| |___ / /| |_| | |_| |
            \_/\_/  \___/ \___/|_|   |____/|_____|_____/____\___/ \___/ 
";

            Console.WriteLine(banner2);
            Console.ResetColor();
        }

        public void PrintMenuSelectie()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string menu = @"
            
            ╔══════════════════════════════════════════════════╗
            ║         Welkom in Dierentuin WoopDeeZoo!         ║
            ╠══════════════════════════════════════════════════╣
            ║ Gelieve een optie te selecteren:                 ║
            ║ ************************************************ ║
            ║ A: Voeg een dier toe aan de database.            ║
            ║ B: Bekijk de database van dierentuin WoopDeeZoo. ║
            ║ C: Zoeken.                                       ║
            ║ D: Wijzig Data van een dier.                     ║
            ║ E: Verwijderen van een dier.                     ║
            ║ F: Bekijk de database van overleden dieren.      ║
            ║ ------------------------------------------------ ║
            ║ Q: Sluit het programma af.                       ║
            ╚══════════════════════════════════════════════════╝
        ";
            Console.WriteLine(menu);
            Console.ResetColor();
        }
    }
}