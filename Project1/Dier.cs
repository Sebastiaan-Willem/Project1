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


        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //public enum Gender { get; set; }
        public string[] Diet { get; set; }
        public string Habitat { get; set; }

        List<Dier> dierenLijst = new List<Dier>();

        
        public void VoegDierToe(Dier dier)
        {
            dierenLijst.Add(dier);
        }

        public void PrintDierenLijst()
        {
            foreach (Dier dier in dierenLijst)
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
