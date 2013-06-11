using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrainActivityMonitor.Properties;
using Emotiv;

namespace BrainActivityMonitor
{
    class CsvManager
    {
        private readonly OpenFileDialog _openCsvFileDialog;
        private CsvEpocFileReader _reader;
        public const int BufferSize = 256;
        public int Start { get; set; }
        public bool End { get; set; }

        public CsvManager()
        {
            _openCsvFileDialog = new OpenFileDialog {Filter = Resources.OpenFileDialog_Filter_CSV};
        }

        public int LoadFile(string fileName = null)
        {
            if (fileName == null)
            {
                DialogResult result = _openCsvFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = _openCsvFileDialog.FileName;
                }
                else
                {
                    throw new Exception("DialogResult is not OK");
                }
            }

            _reader = new CsvEpocFileReader(fileName);
            var rowsRead = _reader.ReadData();
            
            Start = 0;
            End = false;

            return rowsRead;
        }

        public bool IsFileLoaded()
        {
            if (_reader == null)
            {
                return false;
            }

            return _reader.IsRead;
        }

        internal string GetLoadedFileName()
        {
            if (IsFileLoaded())
            {
                return _reader.Name;
            } 

            throw new Exception("File is not loaded");
        }

        public Dictionary<EdkDll.EE_DataChannel_t, double[]> GetData()
        {
            if (End)
            {
                return null;
            }

            var data = new Dictionary<EdkDll.EE_DataChannel_t, double[]>();
            foreach (var key in _reader.SensorValues.Keys)
            {
                double[] sensorData = _reader.SensorValues[key].ToArray();
                var returnSensorData = new double[BufferSize];
                int counter = 0;
                for (int i = Start; i < Start + BufferSize && i < sensorData.Length && counter < BufferSize; i++)
                {
                    returnSensorData[counter++] = sensorData[i];
                    if (i+1 == sensorData.Length)
                    {
                        End = true;
                    }
                }
                data.Add(_reader.GetChannel(key), returnSensorData);
            }

            if (!End)
            {
                Start = Start + BufferSize;
            } else
            {
                Start = -1;
            }

            return data;
        }

        public void Reset()
        {
            Start = 0;
            End = false;
        }
    }
}
