using System;
using System.IO;

namespace OrganizaFotos
{
    class Program
    {

        static void Main(string[] args)
        {
            string dir = (@"C:\Users\Carlos-sdf1\Desktop\ORDENAR\");
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            FileInfo[] Archivos = dirInfo.GetFiles("*.*");

            foreach (var item in Archivos)
            {
                if (!Directory.Exists(dirInfo.ToString() + item.CreationTime.Date.ToString("d")))
                {
                    Directory.CreateDirectory(dirInfo.ToString() + item.CreationTime.Date.ToString("d"));
                    Console.WriteLine(dirInfo.ToString() + item.CreationTime.Date.ToString("d"));
                }            
            }

            Console.WriteLine();
            DirectoryInfo[] Carpetas = dirInfo.GetDirectories();

            foreach (var item in Archivos)
            {
                foreach (var f in Carpetas)
                {
                    if (item.CreationTime.Date.ToString("d")==f.Name)
                    {
                        File.Copy(item.FullName,f.FullName+"/"+item.Name);
                    }
                }
                Console.WriteLine(item.FullName);
            }

            foreach (var item in Archivos)
            {
                item.Delete();
            }
             	
            string res = Console.ReadLine();
        }
    }
}
