using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TestTaskSortData
{
   static class WorkWithData
    {
        static List<Day> days;
        static List<Hour> hours;
        static string header = "Symbol,Description,Date,Time,Open,High,Low,Close,TotalVolume";

        /// <summary>
        /// Максимум и минимум цены за каждый день
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileType"></param>
        public static void SaveDaysData(IRecordCollection data, string fileType)
        {
            days = new List<Day>();
            SplitData(data, SplitType.Day);

            string path = Directory.GetCurrentDirectory() + @"\HightLowByDay." + fileType;
            using var sw = new StreamWriter(path);
            sw.WriteLine("Date,Hight,Low");


            foreach (var d in days)
            {
                sw.WriteLine(d.PrintMaxMin());
            }
            sw.Close();

            Console.WriteLine("Максимум и минимум цены за каждый день сохранены по пути:");
            Console.WriteLine(path);
            Console.WriteLine();


            
        }

        /// <summary>
        /// Сохранение Файла  данными разбитыми по часам
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileType"></param>
        public static void SaveByHours(IRecordCollection data, string fileType)
        {
            hours = new List<Hour>();
            
            var dayHours = SplitData(data,SplitType.Hour);
            
            string path = Directory.GetCurrentDirectory() + @"\DataByHours." + fileType;
            using var sw = new StreamWriter(path);
            sw.WriteLine(header);


            foreach (var h in hours)
            {
                sw.WriteLine(h.Print());
            }
            sw.Close();

            Console.WriteLine("Файл с данными разбитыми по часам сохранены по пути:");
            Console.WriteLine(path);
            Console.WriteLine();

        }


        public static List<IRecordCollection> SplitData(IRecordCollection data, SplitType sp)
        {
            List<IRecordCollection> dates = new List<IRecordCollection>();

            RecordCollection splitDate = new RecordCollection(data.Records[0]);
            
            for (int i = 1; i < data.Records.Count; i++)
            {


                if ((data.Records[i].Date.ToString("HH") == splitDate.firstHour && sp == SplitType.Hour)
                    ||(sp==SplitType.Day && data.Records[i].Date.ToShortDateString()==splitDate.currentDay))
                {
                    splitDate.Records.Add(data.Records[i]);
                }
                else
                {
                    if (sp == SplitType.Day)
                    {
                        days.Add(new Day() {Records = splitDate.Records, currentDay = splitDate.currentDay, firstHour = splitDate.firstHour });
                    }
                    else if (sp == SplitType.Hour) hours.Add(new Hour() { Records = splitDate.Records, firstHour = splitDate.firstHour, currentDay = splitDate.currentDay });
                    dates.Add(splitDate);
                    splitDate = new RecordCollection(data.Records[i]);
                }
            }

            return dates;
        }

        /// <summary>
        /// Сверяет даные с двух коллекций и сохраняет в данные в новые файлы "Новые строки",  "Потерянные строки", "Уникальные строки"
        /// </summary>
        /// <param name="data"></param>
        /// <param name="data2"></param>
        public static void CompareDates(string path,string path2)
        {
            var file1 = File.ReadLines(path);
            var file2 = File.ReadLines(path2);
            var firstRecords =  file2.Except(file1).ToList();
            var secondRecords =  file1.Except(file2).ToList();

          
            SaveToFile(firstRecords, "Новые строки." + path.Split('.').Last());
            SaveToFile(secondRecords, "Потерянные строки." + path.Split('.').Last());
            firstRecords.AddRange(secondRecords);
            List<Record> thirdRecords = new List<Record>();
            foreach (var item in firstRecords)
            {
                thirdRecords.Add(new Record(item));
            }
            thirdRecords = thirdRecords.OrderBy(r=>r.Date).ToList();
            string thirdPath = Directory.GetCurrentDirectory() + @"\Уникальные строки." + path.Split('.').Last();
            using var sw = new StreamWriter(thirdPath);
            sw.WriteLine(header);

            foreach (var record in thirdRecords)
            {
                sw.WriteLine(record.Print());
            }
            sw.Close();

            try
            {
                Process.Start(Directory.GetCurrentDirectory());
            }
            catch { Console.WriteLine("Файлы с данными сохранены по пути: \n" + Directory.GetCurrentDirectory()); }


        }


      public enum SplitType
        {
            Hour, Day
        }

       static void SaveToFile(IEnumerable<string> records, string nameFile)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + nameFile;
            using var sw = new StreamWriter(path);
            sw.WriteLine(header);

            foreach (var record in records)
            {
                sw.WriteLine(record);
            }
            sw.Close();

        }




    }
}
