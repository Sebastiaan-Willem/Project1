using System;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.PrintMenu();

            string PATH_LIST = $"C:\\Users\\{Environment.UserName}\\source\\repos\\Project1\\Project1\\lijstDieren.txt";
            FileManager fileManager = new FileManager();
            fileManager.CreateFile(PATH_LIST);


            Console.WriteLine("Welkom in onze Dierentuin.");

        }
    }
}
