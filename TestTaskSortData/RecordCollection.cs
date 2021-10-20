using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskSortData
{
    /// <summary>
    /// Родительский классдиапазонных коллекций
    /// </summary>
     class RecordCollection : IRecordCollection
    {
        public RecordCollection(Record record)
        {
            Records = new List<Record>();
            Records.Add(record);
            currentDay = record.Date.ToShortDateString();
            firstHour = record.Date.ToString("HH");
        }

        public RecordCollection()
        {
        }

        public string currentDay;
        public string firstHour;

        public List<Record> Records { get; set; }
    }
}
