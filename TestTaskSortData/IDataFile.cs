using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskSortData
{
    interface IDataFile
    {
       // public List<Record> Data { get; set; }

        public void ReadFile(string path);

        public void SaveFile();

    }
}
