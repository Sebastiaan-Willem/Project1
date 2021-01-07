using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project1
{
    internal class FileReaderWriter
    {
        private string pATH_LIST = $"C:\\Users\\{Environment.UserName}\\source\\repos\\Project1\\Project1\\lijstDieren.txt";
        private string pATH_DEAD = $"C:\\Users\\{Environment.UserName}\\source\\repos\\Project1\\Project1\\overledenDieren.txt";

        public string PATH_LIST
        {
            get { return pATH_LIST; }
        }

        public string PATH_DEAD
        {
            get { return pATH_DEAD; }
        }

        //waarom werkt filemanager object niet om hier nieuwe files te maken?

        private string dateTime = Convert.ToString(System.DateTime.Now);
        public void WriteDataToFile(string textToWriteToFile, string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(textToWriteToFile);
        }
        public void WriteDataToFile(string[] lines)
        {
            WriteDataToFile(lines, pATH_LIST);
        }

        public void WriteDataToFile(string[] lines, string path)
        {
            using StreamWriter writer = new StreamWriter(path, true); //true om nieuwe tekst toe te voegen ipv overschrijven.
            writer.WriteLine();
            foreach (string line in lines)
            {
                writer.Write($"{line} ");
            }
        }

        public void UpdateDataToFile(Dier[] lines)
        {
            using StreamWriter writer = new StreamWriter(PATH_LIST); //true om nieuwe tekst toe te voegen ipv overschrijven.
            foreach (Dier dier in lines)
            {
                writer.WriteLine($"{dier.ID} {dier.Soort} {dier.Naam} {dier.Geslacht} {dier.Geboortedatum.ToString("dd/MM/yyyy")} {dier.Leeftijd} {dier.Habitat} [{dier.Dieet}] ");
            }
        }

        public void EditData(int id, string oldValue, string newValue)
        {
            var lines = ReadDataFromFile(PATH_LIST);
            string lineToReplace = lines[id - 1];
            lineToReplace = lineToReplace.Replace(oldValue, newValue);
            lines[id - 1] = lineToReplace;
            WriteDataToFile(lines.ToArray());
        }

        public List<string> ReadDataFromFile(string path)
        {
            using StreamReader reader = new StreamReader(path);
            string line = string.Empty;

            List<string> lines = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        public string ReadDataLineFromFile(int id)
        {
            using StreamReader reader = new StreamReader(PATH_LIST);

            string line = string.Empty;
            if (ReadDataFromFile(PATH_LIST).Count < id)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er komt geen dier overeen met dat ID nummer in deze lijst.");
                System.Threading.Thread.Sleep(3000);
                Console.ResetColor();
            }
            else
            {
                line = File.ReadLines(pATH_LIST).Skip(id - 1).Take(1).First();                
            }
            reader.Close();
            return line;
        }

        public void WriteDataToDeadFile(string dier)
        {
            string deadData = dier;
            deadData += dateTime;
            WriteDataToFile(deadData, PATH_DEAD);
        }

    }
}