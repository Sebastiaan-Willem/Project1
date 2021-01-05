using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{

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
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        //public enum Gender { Male = 1, Female, Other }
        public string[] Diet { get; set; }
        public enum Habitat { aquarium = 1, safaripark, vogelparadijs, kinderboerderij }

        List<Dier> dierenLijst = new List<Dier>();



        public void VoegDierToe(Dier dier)
        {

            ID++;
            //eventueel eerst dier aanmaken via constructor met ingegeven parameters en dan hele dier object meegeven om te printen in readerWriter

            //opdracht: foutmeldingen rest

            Console.Clear();
            List<string> newDier = new List<string>();

            newDier.Add(ID.ToString());
            Console.WriteLine("Om welk dier gaat het?");
            newDier.Add(Console.ReadLine());
            Console.WriteLine("Geef het dier een naam:");
            newDier.Add(Console.ReadLine());

            char temp;
            do
            {
                Console.WriteLine("Wat is het geslacht? (M/V/X)");
                temp = Convert.ToChar(Console.ReadLine());
                if ((temp == 'M') || (temp == 'V') || (temp == 'X'))
                {
                    newDier.Add(temp.ToString());
                }
                else
                {
                    Console.WriteLine("De gegeven input is incorrect, probeer opnieuw:");
                }

            } while (!(temp == 'M' || temp == 'V' || temp == 'X'));

            //string formatting voor data bekijken?
            Console.WriteLine("Geef de geboortedatum in: DD/MM/YYYY");
            newDier.Add(Console.ReadLine());



            Console.WriteLine("Wordt het dier ondergebracht in ons aquarium (A), het safaripark(S), het vogelparadijs(V) of de kinderboerderij(K)?");
            newDier.Add(Console.ReadLine());
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

        public void BerekenLeeftijd()
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

            //   constructor: DateTime justDate = new DateTime(2002, 10, 18);

            DateTime today = DateTime.Today;
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
