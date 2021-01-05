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
            using StreamWriter writer = new StreamWriter(pATH_LIST, true); //true om nieuwe tekst toe te voegen ipv overschrijven.
            writer.WriteLine();
            foreach (string line in lines)
            {
                writer.Write($"{line} ");
            }
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

        public void EditData(int id, string old, string replace)
        {
            StreamReader reader = new StreamReader(PATH_LIST);
            //eventueel editen op een specifieke regel op basis van ID?
            string input = ReadDataLineFromFile(id);

            using (StreamWriter writer = new StreamWriter(PATH_LIST, true))
            {
                {
                    string output = input.Replace(old, replace);
                    writer.Write(output);
                }
                writer.Close();
            }
            reader.Close();

            //var target = File
            //                   .ReadLines(@"C:\MyFile.txt")
            //                   .Select(line => line) //TODO: put your actual edit here
            //                   .ToList(); // In order to prevent access problems

            //File.WriteAllLines(@"C:\MyFile.txt", target);
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

                //System.Threading.Thread.Sleep(500);
                //line = reader.ReadLine().Skip(id - 1).Take(1).ToString();
                //Console.WriteLine(reader.ReadLine().Skip(id - 1).Take(1));
            }
            reader.Close();
            return line;
        }

        public List<String> SearchDataInDocument(string data)
        {
            //TODO

            List<string> lines = new List<string>();

            return lines;
        }

        public void DeleteDataFromFile()
        {
            using StreamWriter writer = new StreamWriter(pATH_LIST, true);
        }

        public void MoveDataFromFile(int id)
        {
            string copyData = ReadDataLineFromFile(id);
            copyData += dateTime;
            WriteDataToFile(copyData, PATH_DEAD);
        }

        public void WriteSeparator(string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("---------------------------------------------------------------------");
        }

        public void WriteHeader(string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("---------------------------------------------------------------------");
            writer.WriteLine("------------------------<<< DIEREN LIJST >>>-------------------------");
            writer.WriteLine("---------------------------------------------------------------------");
        }
    }
}