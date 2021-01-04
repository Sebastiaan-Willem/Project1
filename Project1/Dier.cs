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

        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public enum Gender { Female = 1, Male, Hermaphrodite, Asexual }
        public string[] Diet { get; set; }
        public string Habitat { get; set; }

        List<Dier> dierenLijst = new List<Dier>();

        
        public void VoegDierToe(Dier dier)
        {
            Console.Clear();

            List<string> newDier = new List<string>();
            Console.WriteLine("Om welk dier gaat het?");
            newDier.Add(Console.ReadLine());
            Console.WriteLine("Geef het dier een naam:");
            newDier.Add(Console.ReadLine());
            Console.WriteLine("Wat is het geslacht? (M/V/X)");
            newDier.Add(Console.ReadLine());
            Console.WriteLine("Geef de geboortedatum in: DD/MM/YYYY");
            newDier.Add(Console.ReadLine());
            Console.WriteLine("Geef aan wat het dier dagelijks wenst te eten:");
            newDier.Add("[" + Console.ReadLine() + "]");
            Console.WriteLine("Wordt het dier ondergebracht in ons aquarium, het safaripark, het vogelparadijs of de kinderboerderij?");

            fileReaderWriter.WriteDataToFile(newDier.ToArray());

            dierenLijst.Add(dier);
        }

        public void PrintDierenLijst(List<string> dieren)
        {
            foreach (string dier in dieren)
            {
                Console.WriteLine(dier);
            }
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
            //TODO
        }

        public void VerwijderDier(Dier dier)
        {
            dierenLijst.Remove(dier);
        }
    }
}
