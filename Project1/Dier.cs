using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public enum Habitats { aquarium = 1, safaripark, vogelparadijs, kinderboerderij }

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
            set { id = fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST).Count; }
        }
        public string Soort { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        //public enum Gender { Male = 1, Female, Other }
        public string[] Diet { get; set; }
        
        public string Habitat { get; set; }

        List<Dier> dierenLijst = new List<Dier>();

        

        public void VoegDierToe()
        {
            Dier dier = new Dier();
            List<string> newDier = new List<string>();
            
            //opdracht: foutmeldingen rest

            Console.Clear();

            dier.ID++;
            newDier.Add(ID.ToString());

            Console.WriteLine("Om welk dier gaat het?");
            dier.Soort = Console.ReadLine();
            newDier.Add(dier.Soort);

            Console.WriteLine("Geef het dier een naam:");
            dier.Name = Console.ReadLine();
            newDier.Add(dier.Name);


            char temp;
            do
            {
                Console.WriteLine("Wat is het geslacht? (M/V/X)");
                temp = Convert.ToChar(Console.ReadLine());
                if ((temp == 'M') || (temp == 'V') || (temp == 'X'))
                {
                    dier.Gender = temp;
                    newDier.Add(dier.Gender.ToString());
                }
                else
                {
                    Console.WriteLine("De gegeven input is incorrect, probeer opnieuw:");
                }

            } while (!(temp == 'M' || temp == 'V' || temp == 'X'));

            //string formatting voor data bekijken?
            Console.WriteLine("Geef de geboortedatum in: DD/MM/YYYY");
            dier.Age = BerekenLeeftijd(Console.ReadLine());
            newDier.Add(dier.Age.ToString());

            Console.WriteLine("Wordt het dier ondergebracht in ons aquarium (1), het safaripark(2), het vogelparadijs(3) of de kinderboerderij(4)?");
            dier.Habitat = Habitats.aquarium.ToString();
            newDier.Add(dier.Habitat);

            Console.WriteLine("Geef aan wat het dier dagelijks wenst te eten:");
            newDier.Add("[" + Console.ReadLine() + "]");



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
            if (!(dier == ""))
            {
                Console.WriteLine(dier);
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er is geen dier gevonden met dit ID nummer");
                System.Threading.Thread.Sleep(3000);
                Console.ResetColor();
            }

        }

        public int BerekenLeeftijd(string geboorteDatum)
        {
            //(EndDate.Date - StartDate.Date).Days
                //EndDate is dan huidige dag met:
                //gevonden: DateTime.Now.ToString("MM/dd/yyyy")
                //proberen met: DateTime.Now.ToString("dd/MM/yyyy")
                //StartDate gelijkstellen aan geboortedatum

            //while (MyReader.Read())
            //{
            //    TextBox1.Text = Convert.ToDateTime(MyReader["DateField"]).ToString("dd/MM/yyyy");
            //}

            //string today = Convert.DateTime.Today;
            //int age = today.Year - birthdate.Year;
            //if (birthdate.date > today.AddYears(-age)) age--;

        }

        



    //------------------------------------------------------------
    //EXTRA
    //------------------------------------------------------------


        public double Kosten { get; set; }
        public string FamilyTree { get; set; }
        public double Gewicht { get; set; }
        public double Lengte { get; set; }
        public DateTime InschrijvingsDatum { get; set; }

        public void WijzigData(string oldData, string newData)
        {
            //TODO
            fileReaderWriter.EditData(oldData, newData);
        }

        public void VerwijderDier(Dier dier)
        {
            dierenLijst.Remove(dier);
        }
    }
}
