﻿using System;
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
            set { id = value; }
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public enum Gender { Male = 1, Female, Other }
        public string[] Diet { get; set; }
        public string Habitat { get; set; }

        List<Dier> dierenLijst = new List<Dier>();

        

        public void VoegDierToe(Dier dier)
        {
            
            ID++;
            //OPM: ID werkt nog niet met optellen als programma afgesloten is, evt lezen van bestand

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


            //eventueel enum voor habitat
            Console.WriteLine("Wordt het dier ondergebracht in ons aquarium, het safaripark, het vogelparadijs of de kinderboerderij?");
            newDier.Add(Console.ReadLine());
            Console.WriteLine("Geef aan wat het dier dagelijks wenst te eten:");
            newDier.Add("[" + Console.ReadLine() + "]");
            


            fileReaderWriter.WriteDataToFile(newDier.ToArray());

            dierenLijst.Add(dier);
        }

        public void PrintDierenLijst(List<string> dieren)
        {
            if(!(dieren.Count == 0))
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
