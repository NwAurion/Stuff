using System;
using System.IO;

namespace RenameTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter directory of the files to rename");
            string dir = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(dir);
            foreach (System.IO.FileInfo file in di.GetFiles("*.*"))
            {
                if (file.Extension.Equals(".part"))
                {
                    string oldFileName = file.Name.Substring(0, file.Name.IndexOf("."));
                    int number = Convert.ToInt16(file.Name.Substring(oldFileName.Length + 1, file.Name.IndexOf(".zip") - oldFileName.Length - 1));
                    number++;
                    string numberAsString = number.ToString("000");
                    string newFileName = oldFileName + "." + numberAsString;
                    file.MoveTo(di.FullName + "/" + newFileName);
                }
            }
        }
    }
}
