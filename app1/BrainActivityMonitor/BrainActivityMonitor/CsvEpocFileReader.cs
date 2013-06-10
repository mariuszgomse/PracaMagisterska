using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Emotiv;

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

        public EdkDll.EE_DataChannel_t GetChannel(int key)
        {
            EdkDll.EE_DataChannel_t channel;
            key++;
            Enum.TryParse(key.ToString(CultureInfo.InvariantCulture), out channel);
            return channel;
        }
    }
}
