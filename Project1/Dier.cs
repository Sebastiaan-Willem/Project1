﻿using System;
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

        

        public void VoegDierToe()
        {
            Dier dier = new Dier();
            List<string> newDier = new List<string>();

            dier.ID = fileReaderWriter.ReadDataFromFile(fileReaderWriter.PATH_LIST).Count + 1;
            newDier.Add(dier.ID.ToString());

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

            Console.WriteLine("Geef de geboortedatum in: DD/MM/YYYY");
            dier.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            newDier.Add(dier.DateOfBirth.ToString("dd/MM/yyyy"));

            dier.Leeftijd = BerekenLeeftijd(dier.DateOfBirth);
            newDier.Add(dier.Leeftijd.ToString());

            Console.WriteLine("Wordt het dier ondergebracht in ons aquarium (1), het safaripark(2), het vogelparadijs(3) of de kinderboerderij(4)?");
            dier.Habitat = Habitats.Aquarium.ToString();
            newDier.Add(dier.Habitat);

            //hier moet nog input gefixt worden en gelinkt aan enum waarde

            Console.WriteLine("Geef aan wat het dier dagelijks wenst te eten:");
            dier.Diet = Console.ReadLine();
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

        public int BerekenLeeftijd(DateTime geboorteDatum)
        {
            DateTime today = DateTime.Today;
            DateTime birthdate = geboorteDatum;
            int age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
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
