using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskSortData
{
    /// <summary>
    /// Записи за день
    /// </summary>
    class Day : RecordCollection
    {

        public Day(Record record) : base(record) { }

        public Day(){}

        public string CurrentDay => currentDay;

        public double Max { get; set; }
        public double Min { get; set; }

     

        public string PrintMaxMin()
        {
            GetMax();
            GetMin();
            return $"{Max}, {Min}";
        }


        void GetMax()
        {
            List<double> high = new List<double>();
            foreach (var item in Records)
            {
                high.Add(item.High);
            }
            high.Sort();
            Max =  high[high.Count - 1];
        }

        void GetMin()
        {
            List<double> high = new List<double>();
            foreach (var item in Records)
            {
                high.Add(item.Low);
            }
            high.Sort();
            Min = high[0];
        }

       



    }
}
