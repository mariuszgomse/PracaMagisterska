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

        public void CalculateAverageForData()
        {
            isAverageForDataCalculated = true;
            if (_data.Count > 0)
            {
                List<double> averages = new List<double>();
                foreach (double[] doublese in _data)
                {
                    averages.Add(doublese.Average());
                }

                dataAverage = averages.Average();
            }
            else
            {
                dataAverage = 0;
            }
            
        }
    }
}
