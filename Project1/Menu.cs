using System;
using WMPLib;

namespace Project1
{
    class Menu
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        Dier dier = new Dier();
        FileReaderWriter fileReaderWriter = new FileReaderWriter();
        private readonly string path = $"C:\\Users\\{Environment.UserName}\\source\\repos\\Project1\\Project1\\sounds\\";

        public void PrintMenu()
        {
            dier.MaakDierenLijstAan();
            //PlayJungleSound();
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

                        //nieuwe methode zoekfuncties, op basis van ID, naam en habitat

                            Console.Clear();
                            Console.WriteLine("Geef het ID van het dier dat u wenst op te vragen.");
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

        public void PrintTrein()
        {
            PlayTrainSound();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int j = 0; j < 15; j++)
            {

                Console.Clear();

                // steam
                Console.WriteLine("   ...Welcome, press ENTER when you've arrived at...");
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

        public void PlayTrainSound()
        {
            string train = "Train_Horn.mp3";
            player.settings.volume = 50;
            player.URL = path + train;
        }
        public void PlayJungleSound()
        {
            string train = "rainforest_ambience.mp3";
            player.settings.volume = 50;
            player.URL = path + train;
        }

        public void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string banner = @"
                
        .--.      .--.    ,-----.        ,-----.    .-------.  ______         .-''-.      .-''-.    ____..--'    ,-----.        ,-----.     
        |  |_     |  |  .'  .-,  '.    .'  .-,  '.  \  _(`)_ \|    _ `''.   .'_ _   \   .'_ _   \  |        |  .'  .-,  '.    .'  .-,  '.   
        | _( )_   |  | / ,-.|  \ _ \  / ,-.|  \ _ \ | (_ o._)|| _ | ) _  \ / ( ` )   ' / ( ` )   ' |   .-'  ' / ,-.|  \ _ \  / ,-.|  \ _ \  
        |(_ o _)  |  |;  \  '_ /  | :;  \  '_ /  | :|  (_,_) /|( ''_'  ) |. (_ o _)  |. (_ o _)  | |.-'.'   /;  \  '_ /  | :;  \  '_ /  | : 
        | (_,_) \ |  ||  _`,/ \ _/  ||  _`,/ \ _/  ||   '-.-' | . (_) `. ||  (_,_)___||  (_,_)___|    /   _/ |  _`,/ \ _/  ||  _`,/ \ _/  | 
        |  |/    \|  |: (  '\_/ \   ;: (  '\_/ \   ;|   |     |(_    ._) ''  \   .---.'  \   .---.  .'._( )_ : (  '\_/ \   ;: (  '\_/ \   ; 
        |  '  /\  `  | \ `'/  \  ) /  \ `'/  \  ) / |   |     |  (_.\.' /  \  `-'    / \  `-'    /.'  (_'o._) \ `'/  \  ) /  \ `'/  \  ) /  
        |    /  \    |  '. \_/``'.'    '. \_/``'.'  /   )     |       .'    \       /   \       / |    (_,_)|  '. \_/``'.'    '. \_/``'.'   
        `---'    `---`    '-----'        '-----'    `---'     '-----'`       `'-..-'     `'-..-'  |_________|    '-----'        '-----'     
                                                                                                                                    

                ";

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
            Console.WriteLine("Welkom in Dierentuin WoopDeeZoo!");
            Console.WriteLine("Gelieve een optie te selecteren:");
            Console.WriteLine("***********************************************");
            Console.WriteLine("A: Voeg een dier toe aan de database.");
            Console.WriteLine("B: Bekijk de database van dierentuin Ikweetgeennaam.");
            Console.WriteLine("C: Zoekfuncties");
            Console.WriteLine("D: Wijzig Data van een dier.");
            Console.WriteLine("E: Verwijderen van een dier.");
            Console.WriteLine("F: Bekijk lijst overleden dieren.");
            Console.WriteLine("Q: Sluit het programma af.");
        }

    }
    
}
