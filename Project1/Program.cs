namespace Project1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            FileReaderWriter readerWriter = new FileReaderWriter();

            fileManager.CreateFile(readerWriter.PATH_LIST);
            fileManager.CreateFile(readerWriter.PATH_DEAD);

            Menu menu = new Menu();
            menu.PrintMenu();
        }
    }
}