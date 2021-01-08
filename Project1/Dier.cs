using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    public enum Habitats { Aquarium = 1, Safaripark, Vogelparadijs, Kinderboerderij }

    internal class Dier
    {
        //------------------------------------------------------------
        //MVP
        //------------------------------------------------------------

        private FileReaderWriter fileReaderWriter = new FileReaderWriter();
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Soort { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public int Leeftijd { get; set; }
        public char Geslacht { get; set; }
        public string Dieet { get; set; }

        public string Habitat { get; set; }

        private List<Dier> dierenLijst = new List<Dier>();

        public Dier()
        {
        }

        public Dier(int id, string soort, string naam, char geslacht, DateTime geboortedatum, int leeftijd, string habitat, string dieet)
        {
            this.id = id;
            Soort = soort;
            Naam = naam;
            Geslacht = geslacht;
            Geboortedatum = geboortedatum;
            Leeftijd = leeftijd;
            Habitat = habitat;
            Dieet = dieet;
        }

        public void VoegDierToe()
        {
            Dier dier = new Dier();
            List<string> newDier = new List<string>();

            dier.ID = GetUniekeID();
            newDier.Add(dier.ID.ToString());

            dier.Soort = BepaalDiersoort();
            newDier.Add(dier.Soort);

            dier.Naam = BepaalEigennaam();
            newDier.Add(dier.Naam);

            dier.Geslacht = BepaalGeslacht();
            newDier.Add(dier.Geslacht.ToString());

            dier.Geboortedatum = BepaalGeboortedatum();
            newDier.Add(dier.Geboortedatum.ToString("dd/MM/yyyy"));

            dier.Leeftijd = BerekenLeeftijd(dier.Geboortedatum);
            newDier.Add(dier.Leeftijd.ToString());

            dier.Habitat = BepaalHabitat();
            newDier.Add(dier.Habitat);

            dier.Dieet = BepaalDieet();
            newDier.Add("[" + dier.Dieet + "]");

            fileReaderWriter.WriteDataToFile(newDier.ToArray());

            dierenLijst.Add(dier);
        }

        public int GetUniekeID()
        {
            int uniekeID = 0;

            foreach (Dier dier in dierenLijst)
            {
                if (dier.ID > uniekeID)
                {
                    uniekeID = dier.ID;
                }
            }
            return uniekeID + 1;
        }

        public List<Dier> GetDierenLijst()
        {
            return dierenLijst;
        }

        public void PrintDierenLijst(List<string> dieren)
        {
            if (!(dieren.Count == 0))
            {
                foreach (string dier in dieren)
                {
                    Console.WriteLine(dier);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er zitten momenteel geen dieren in deze lijst.");
                System.Threading.Thread.Sleep(3000);
                Console.ResetColor();
            }
        }

        public void PrintDierenLijst(List<Dier> lijst)
        {
            if (!(lijst.Count == 0))
            {
                Console.WriteLine($"{"ID",3} {"Naam",14} {"Soort",10} {"Geboortedatum",12} {"Leeftijd",8} {"Geslacht",8} {"Habitat",18} {"Dieet",24}\n");

                foreach (Dier dier in lijst)
                {
                    Console.WriteLine($"{dier.ID,3} {dier.Naam,14} {dier.Soort,10} {dier.Geboortedatum,12:dd/MM/yyyy} {dier.Leeftijd,8} {dier.Geslacht,8} {dier.Habitat,18} {dier.Dieet,25}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er zitten momenteel geen dieren in deze lijst.");
                System.Threading.Thread.Sleep(3000);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        public void PrintDierMetId(int id)
        {
            Console.WriteLine($"{"ID",3} {"Naam",14} {"Soort",10} {"Geboortedatum",12} {"Leeftijd",8} {"Geslacht",8} {"Habitat",18} {"Dieet",24}\n");

            foreach (Dier dier in dierenLijst)
            {
                if (dier.ID == id)
                {
                    Console.WriteLine($"{dier.ID,3} {dier.Naam,14} {dier.Soort,10} {dier.Geboortedatum,12:dd/MM/yyyy} {dier.Leeftijd,8} {dier.Geslacht,8} {dier.Habitat,18} {dier.Dieet,25}");
                }
            }

            Console.WriteLine();
        }

        public string DierToString(Dier dier)
        {
            string dierAlsString = $"{dier.ID} {dier.Soort} {dier.Naam} {dier.Geslacht} {dier.Geboortedatum.ToString("dd/MM/yyyy")} {dier.Leeftijd} {dier.Habitat} [{dier.Dieet}] ";

            return dierAlsString;
        }

        public string BepaalDiersoort()
        {
            Console.WriteLine("Om welk dier gaat het?");
            return Console.ReadLine().ToUpper();
        }

        public string BepaalEigennaam()
        {
            Console.WriteLine("Geef het dier een eigennaam:");
            return Console.ReadLine();
        }

        public DateTime BepaalGeboortedatum()
        {
            Console.WriteLine("Geef de geboortedatum in: DD/MM/YYYY");
            return Convert.ToDateTime(Console.ReadLine());
        }

        public int BerekenLeeftijd(DateTime geboorteDatum)
        {
            DateTime today = DateTime.Today;
            DateTime birthdate = geboorteDatum;
            int age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }

        public char BepaalGeslacht()
        {
            char temp;
            do
            {
                Console.WriteLine("Wat is het geslacht? (M/V/X)");
                temp = Convert.ToChar(Console.ReadLine().ToUpper());
                if ((temp == 'M') || (temp == 'V') || (temp == 'X'))
                {
                    return temp;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--De gegeven input is incorrect, probeer opnieuw:--");
                    Console.ResetColor();
                }
            } while (!(temp == 'M' || temp == 'V' || temp == 'X'));

            return temp;
        }

        public string BepaalHabitat()
        {
            Console.WriteLine("Wordt het dier ondergebracht in ons Aquarium (1), het Safaripark(2), het Vogelparadijs(3) of de Kinderboerderij(4)?");
            bool test = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out int HabitatNum))
                {
                    if (Enum.IsDefined(typeof(Habitats), HabitatNum))
                    {
                        Habitats myHabitat = (Habitats)HabitatNum;
                        return myHabitat.ToString();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--Dit is geen cijfer die overeenstemt met een habitat, probeer opnieuw.--");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--Gelieve een cijfer in te geven.--");
                    Console.ResetColor();
                }
            } while (test == false);

            string helphoebenikhierditiszinloos = string.Empty;
            return helphoebenikhierditiszinloos;
        }

        public string BepaalDieet()
        {
            Console.WriteLine("Geef aan wat het dier dagelijks wenst te eten:");
            return Console.ReadLine();
        }

        //------------------------------------------------------------
        //EXTRA
        //------------------------------------------------------------

        public void WijzigData()
        {
            //NEW
            Console.WriteLine("Geef het ID van het dier dat u wenst aan te passen.");
            bool test = int.TryParse(Console.ReadLine(), out int tempID);

            if (test)
            {
                PrintDierMetId(tempID);
                bool parsable;
                Console.WriteLine("Wat wenst u aan te passen? (maak een keuze op basis van volgende opties)");
                Console.WriteLine("1 = Soort | 2 = Naam | 3 = Geslacht | 4 = Geboortedatum | 5 = Habitat | 6 = Dieet");

                foreach (Dier dier in dierenLijst)
                {
                    if (dier.ID == tempID)
                    {
                        do
                        {
                            parsable = int.TryParse(Console.ReadLine(), out int userChoice);

                            switch (userChoice)
                            {
                                case 1:
                                    dier.Soort = BepaalDiersoort();
                                    break;

                                case 2:
                                    dier.Naam = BepaalEigennaam();
                                    break;

                                case 3:
                                    dier.Geslacht = BepaalGeslacht();
                                    break;

                                case 4:
                                    dier.Geboortedatum = BepaalGeboortedatum();
                                    dier.Leeftijd = BerekenLeeftijd(dier.Geboortedatum);
                                    break;

                                case 5:
                                    dier.Habitat = BepaalHabitat();
                                    break;

                                case 6:
                                    dier.Dieet = BepaalDieet();
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Gelieve een geldige optie te selecteren uit het menu.");
                                    Console.ResetColor();
                                    break;
                            }
                        }
                        while (parsable == false);
                    }
                }

                fileReaderWriter.UpdateDataToFile(dierenLijst.ToArray());
                Console.WriteLine("De data werd succesvol geupdate!");
                PrintDierMetId(tempID);
            }
            //OLD

            //Console.WriteLine("Geef het ID van het dier dat u wenst aan te passen.");
            //int tempID = Convert.ToInt32(Console.ReadLine());
            //PrintDierMetId(fileReaderWriter.ReadDataLineFromFile(tempID));

            //Console.WriteLine("Wat wenst u aan te passen?");
            //string oldData = Console.ReadLine();

            //Console.WriteLine("Waardoor wenst u dit te vervangen?");
            //string newData = Console.ReadLine();
            //System.Threading.Thread.Sleep(500);
            //fileReaderWriter.EditData(tempID, oldData, newData);
            //PrintDierMetId(fileReaderWriter.ReadDataLineFromFile(tempID));
        }

        public void VerwijderDier()
        {
            Console.WriteLine("Geef het ID van het dier dat u wenst te verwijderen.");
            bool test = int.TryParse(Console.ReadLine(), out int tempID);
            if (test)
            {
                foreach (Dier dier in dierenLijst.ToList()) //ToList() toegevoegd wegens "Exception: Collection was modified; enumeration operation may not execute."
                {
                    if (dier.ID == tempID)
                    {
                        fileReaderWriter.WriteDataToDeadFile(DierToString(dier));
                        string tempName = dier.Naam;
                        dierenLijst.Remove(dier);
                        Console.WriteLine($"{tempName} will be missed.. :( ");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--De gegeven input is incorrect--");
                Console.ResetColor();
            }

            fileReaderWriter.UpdateDataToFile(dierenLijst.ToArray());
        }

        public void MaakDierenLijstAan()
        {
            List<string> dierenLijstTwee = fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST);
            dierenLijstTwee.RemoveAll(dier => dier.Length == 0);

            foreach (string dier in dierenLijstTwee)
            {
                string[] dierenInfoArray = dier.Split(" ");

                int id = Convert.ToInt32(dierenInfoArray[0]);
                string soort = dierenInfoArray[1];
                string naam = dierenInfoArray[2];
                char geslacht = Convert.ToChar(dierenInfoArray[3]);
                DateTime geboortedatum = Convert.ToDateTime(dierenInfoArray[4]);
                int leeftijd = Convert.ToInt32(dierenInfoArray[5]);
                string habitat = dierenInfoArray[6];

                int openSquare = dier.IndexOf('[');
                string dieet = dier.Substring(openSquare + 1, dier.Length - (openSquare + 3));

                Dier dierobject = new Dier(id, soort, naam, geslacht, geboortedatum, leeftijd, habitat, dieet);

                dierenLijst.Add(dierobject);
            }

            dierenLijst = dierenLijst.OrderBy(dier => dier.ID).ToList();
        }

        public void ZoekOpInput()
        {
            string gezochtgegeven = Console.ReadLine();
            List<Dier> gefilterdeLijst = new List<Dier>();

            foreach (Dier dier in dierenLijst)
            {
                if (gezochtgegeven == dier.ID.ToString())
                {
                    gefilterdeLijst.Add(dier);
                }
                else if (gezochtgegeven.ToUpper() == dier.Soort)
                {
                    gefilterdeLijst.Add(dier);
                }
                else if (gezochtgegeven == dier.Naam)
                {
                    gefilterdeLijst.Add(dier);
                }
                else if (gezochtgegeven == dier.Geboortedatum.ToString())
                {
                    gefilterdeLijst.Add(dier);
                }
                else if (gezochtgegeven == dier.Leeftijd.ToString())
                {
                    gefilterdeLijst.Add(dier);
                }
                else if (gezochtgegeven.ToUpper() == dier.Geslacht.ToString())
                {
                    gefilterdeLijst.Add(dier);
                }
                else if (dier.Dieet.ToUpper().Contains(gezochtgegeven.ToUpper()))
                {
                    gefilterdeLijst.Add(dier);
                }
                else if (gezochtgegeven.ToUpper() == dier.Habitat.ToUpper())
                {
                    gefilterdeLijst.Add(dier);
                }
            }

            Console.WriteLine($"Er zijn {gefilterdeLijst.Count} resultaten voor uw zoekopdracht:");
            Console.WriteLine();
            PrintDierenLijst(gefilterdeLijst);
        }
    }
}