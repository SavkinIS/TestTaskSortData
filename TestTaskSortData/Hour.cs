using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTaskSortData
{
    /// <summary>
    /// Записи за час
    /// </summary>
    class Hour: RecordCollection
    {
        public Hour(Record record) : base(record){ }
        public Hour(){}

        double Open => Records[0].Open;
        double Close => Records[^1].Close;
        double Hight => Records.OrderBy(r => r.High).Last().High;
        double Low => Records.OrderBy(r => r.Low).First().Low;
        double TotalVolume => Records.Sum(r => r.TotalVolume);



        public string CurrentHour => firstHour;

        public string Print()
        {

            return $"{Records[0].Symbol}," +
                $"{Records[0].Description}," +
                $"{Records[0].Date.ToShortDateString()}," +
                $"{Records[0].Date.ToLongTimeString()}," +
                $"{Open}," +
                $"{Close}," +
                $"{Hight}," +
                $"{Low}," +
                $"{TotalVolume}";

        }
    }
}
