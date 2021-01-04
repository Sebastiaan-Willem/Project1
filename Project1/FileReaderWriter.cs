﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1
{
    class FileReaderWriter
    {
        string dateTime = Convert.ToString(System.DateTime.Now);

                
        public void WriteDataToFile(string textToWriteToFile, string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(textToWriteToFile);

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