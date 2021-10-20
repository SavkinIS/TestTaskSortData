using System;
using System.Collections.Generic;
using System.IO;

namespace TestTaskSortData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь файла");
            string path = Console.ReadLine();

            DataFile firstDF = new DataFile(path);


            WorkWithData.SaveDaysData(firstDF, firstDF.fileType);
            
            WorkWithData.SaveByHours(firstDF, firstDF.fileType);


            Console.WriteLine("Введите путь файла2 для сравнения");
            string path2 = Console.ReadLine();
            DataFile firstDF2 = new DataFile(path2);

            WorkWithData.CompareDates(path, path2);


        }
    }
}
