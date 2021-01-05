using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public enum Habitats { Aquarium = 1, Safaripark, Vogelparadijs, Kinderboerderij }

    class Dier
    {
        //------------------------------------------------------------
        //MVP
        //------------------------------------------------------------

        FileReaderWriter fileReaderWriter = new FileReaderWriter();
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Soort { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Leeftijd { get; set; }
        public char Gender { get; set; }
        public string Diet { get; set; }

        public string Habitat { get; set; }

        List<Dier> dierenLijst = new List<Dier>();
        
        public Dier()
        {

        }
        public Dier(string naam, string soort, int age)
        {
            Name = naam;
            Soort = soort;
            Leeftijd = age;
        }
        public void test()
        {
            //Voorbeeld/test ivm objecten van Data maken
            Dier koe = new Dier("Bessie", "Koe", 13);
            Dier paard = new Dier();
            Dier zeemeeuw = new Dier();
            dierenLijst.Add(koe);
            dierenLijst.Add(paard);
            dierenLijst.Add(zeemeeuw);

            

            foreach (Dier dier in dierenLijst)
            {
                Console.WriteLine($"{dier.Name} is een {dier.Soort} en is {dier.Leeftijd} jaar oud.");
            }
        }


        public void VoegDierToe()
        {
            Dier dier = new Dier();
            List<string> newDier = new List<string>();

            dier.ID = fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST).Count + 1;
            newDier.Add(dier.ID.ToString());

            dier.Soort = BepaalDiersoort();
            newDier.Add(dier.Soort);

            dier.Name = BepaalEigennaam();
            newDier.Add(dier.Name);

            dier.Gender = BepaalGeslacht();
            newDier.Add(dier.Gender.ToString());

            dier.DateOfBirth = BepaalGeboortedatum();
            newDier.Add(dier.DateOfBirth.ToString("dd/MM/yyyy"));

            dier.Leeftijd = BerekenLeeftijd(dier.DateOfBirth);
            newDier.Add(dier.Leeftijd.ToString());

            dier.Habitat = BepaalHabitat();
            newDier.Add(dier.Habitat);

            dier.Diet = BepaalDieet();
            newDier.Add("[" + dier.Diet + "]");

            fileReaderWriter.WriteDataToFile(newDier.ToArray());

            dierenLijst.Add(dier);
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

        public void PrintDierMetId(string dier)
        {
            Console.WriteLine(dier);
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


        public double Kosten { get; set; }
        public string FamilyTree { get; set; }
        public double Gewicht { get; set; }
        public double Lengte { get; set; } 
        public DateTime InschrijvingsDatum { get; set; }

        public void WijzigData()
        {
            Console.WriteLine("Geef het ID van het dier dat u wenst aan te passen.");
            int tempID = Convert.ToInt32(Console.ReadLine());
            PrintDierMetId(fileReaderWriter.ReadDataLineFromFile(tempID));

            Console.WriteLine("Wat wenst u aan te passen?");
            string oldData = Console.ReadLine();

            Console.WriteLine("Waardoor wenst u dit te vervangen?");
            string newData = Console.ReadLine();
            System.Threading.Thread.Sleep(500);
            fileReaderWriter.EditData(tempID, oldData, newData);
            PrintDierMetId(fileReaderWriter.ReadDataLineFromFile(tempID));
        }

        public void VerwijderDier()
        {
            Console.WriteLine("Geef het ID van het dier dat u wenst te verwijderen.");
            fileReaderWriter.MoveDataFromFile(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("ByeBye :(");
        }
    }
}
