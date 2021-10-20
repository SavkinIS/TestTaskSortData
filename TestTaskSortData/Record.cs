using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskSortData
{
    class Record
    {
        public Record(string dataLine)
        {

            string[] splitData = dataLine.Split(',');

            if (splitData.Length == 9)
            {
                Symbol = splitData[0];
                Description = splitData[1];
                Date = Convert.ToDateTime(splitData[2]+ " "+ splitData[3]);
                Open = Convert.ToDouble(splitData[4].Replace('.', ','));
                High = Convert.ToDouble(splitData[5].Replace('.', ','));
                Low = Convert.ToDouble(splitData[6].Replace('.', ','));
                Close = Convert.ToDouble(splitData[7].Replace('.', ','));
                TotalVolume = Convert.ToDouble(splitData[8].Replace('.', ','));
            }
            
        }

        public string Symbol { get; set; }
       public string Description { get; set; }
       public DateTime Date { get; set; }
       public double Open { get; set; }
       public double High { get; set; }
       public double Low { get; set; }
       public double Close { get; set; }
       public double TotalVolume { get; set; }


       public string Print()
        {
            return $"{Symbol}," +
                $"{Description}," +
                $"{Date.ToShortDateString()}," +
                $"{Date.ToLongTimeString()}," +
                $"{Open}," +
                $"{High}," +
                $"{Low}," +
                $"{Close}" +
                $"{TotalVolume}";
        }
    }
}
