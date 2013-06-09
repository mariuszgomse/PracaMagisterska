using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BrainActivityMonitor
{
    class CsvEpocFileReader : StreamReader
    {
        public Dictionary<int, List<double>> SensorValues = new Dictionary<int, List<double>>(); 

        public CsvEpocFileReader(string filename)
            : base(filename)
        {
            for (int i = 2; i < 16; i++)
            {
                SensorValues.Add(i, new List<double>());
            }
        }

        public int readData()
        {
            String line = ReadLine(); //labels line

            line = ReadLine();
            while (line != null)
            {
                string[] values = line.Split(',');
                for (int i = 2; i < 16; i++)
                {
                    SensorValues[i].Add(Double.Parse(values[i].Replace('.',',').Trim()));
                }
                line = ReadLine();
            }

            List<double> tmp;
            SensorValues.TryGetValue(2, out tmp);
            return tmp.Count;
        }
    }
}
