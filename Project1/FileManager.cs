using System.IO;

namespace Project1
{
    internal class FileManager
    {
        public void CreateFile(string file)
        {
            if (!File.Exists(file))
            {
                FileStream fileStream = File.Create(file);
                fileStream.Close();
            }
        }

        //***********************************************
        //niet gebruikt:

        //public void DeleteFile(string file)
        //{
        //    if (File.Exists(file))
        //    {
        //        File.Delete(file);
        //    }

        //}
    }
}