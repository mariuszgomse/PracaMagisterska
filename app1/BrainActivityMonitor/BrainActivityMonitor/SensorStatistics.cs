using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrainActivityMonitor
{
    class SensorStatistics
    {
        readonly List<double> _values = new List<double>();
        public double Average { get; set; }
        public bool isAverageCalculated {get; set;}
        public bool isAverageForDataCalculated = false;
        readonly List<double[]> _data = new List<double[]>();
        public double dataAverage = 0;

        public SensorStatistics()
        {
            isAverageCalculated = false;
        }

        public void AddValue(double value)
        {
            _values.Add(value);
        }

        public void CalculateAverage()
        {
            isAverageCalculated = true;
            if (_values.Count > 0)
            {
                Average = _values.Average();
            }
            else
            {
                Average = 0;
            }
        }

        internal void addValues(double[] p)
        {
                _data.Add(p);
        }

        public void CalculateAverageForData() //TODO: zastanowic sie, czy nie powinienem jednak obliczac sredniej dla wszystkich liczb (a nie dla buforowych)
        {
            isAverageForDataCalculated = true;
            if (_data.Count > 0)
            {
                List<double> tmp = new List<double>();
                foreach (double[] doublese in _data)
                {
                    foreach (var d in doublese)
                    {
                        tmp.Add(Math.Abs(d));
                    }
                }

                dataAverage = tmp.Average();
            }
            else
            {
                dataAverage = 0;
            }
            
        }
    }
}
