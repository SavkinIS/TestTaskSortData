using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestTaskSortData
{
    class DataFile : IDataFile, IRecordCollection
    {
        public DataFile(string path)
        {
            ReadFile(path);
            fileType = path.Split('.').Last();
        }

        public List<Record> Records { get; set; }
        public string Head { get; set; }
        
        public string fileType { get; set; }
        public void ReadFile(string path)
        {
            Records = new List<Record>();
            using var sr = new StreamReader(path);
            var line = sr.ReadLine();
            if (line == null) return;
            if (line.StartsWith("Symbol")) Head = line;
            while ((line = sr.ReadLine()) != null) Records.Add(new Record(line));

            sr.Close();


            Console.WriteLine("Чтение файла завершенно");
            Console.WriteLine();
        }

        public void SaveFile()
        {
            throw new NotImplementedException();
        }
    }
}
