using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntroToLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
                ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(file => file.Length)
                        .Take(5);
            foreach (var file in query)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }
        

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for (var i = 0;i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
            }
        }
    }
    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}

