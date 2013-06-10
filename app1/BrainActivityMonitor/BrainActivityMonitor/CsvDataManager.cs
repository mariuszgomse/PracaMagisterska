using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emotiv;

namespace BrainActivityMonitor
{
    class CsvDataManager
    {
        private CsvEpocFileReader _reader;
        const int BufferSize = 256;
        private int start = 0;
        private bool end = false;

        public CsvDataManager(CsvEpocFileReader reader)
        {
            _reader = reader;
        }

        public Dictionary<EdkDll.EE_DataChannel_t, double[]> getData()
        {
            if (end)
            {
                return null;
            }

            var data = new Dictionary<EdkDll.EE_DataChannel_t, double[]>();
            foreach (var key in _reader.SensorValues.Keys)
            {
                double[] sensorData = _reader.SensorValues[key].ToArray();
                var returnSensorData = new double[BufferSize];
                int counter = 0;
                for (int i = start; i < start + BufferSize && i < sensorData.Length && counter < BufferSize; i++)
                {
                    returnSensorData[counter++] = sensorData[i];
                    if (i+1 == sensorData.Length)
                    {
                        end = true;
                    }
                }
                data.Add(_reader.GetChannel(key), returnSensorData);
            }

            if (!end)
            {
                start = start + BufferSize;
            } else
            {
                start = -1;
            }

            return data;
        }
    }
}
