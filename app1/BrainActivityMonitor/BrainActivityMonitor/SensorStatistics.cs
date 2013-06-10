using System;
using System.Collections.Generic;
using System.Linq;

namespace BrainActivityMonitor
{
    class SensorStatistics
    {
        readonly List<double> _values = new List<double>();
        public double Average { get; set; }
        public bool IsAverageCalculated {get; set;}
        public bool IsAverageForDataCalculated = false;
        readonly List<double[]> _data = new List<double[]>();
        public double DataAverage = 0;

        public SensorStatistics()
        {
            IsAverageCalculated = false;
        }

        public void AddValue(double value)
        {
            _values.Add(value);
        }

        public void CalculateAverage()
        {
            IsAverageCalculated = true;
            Average = _values.Count > 0 ? _values.Average() : 0;
        }

        internal void AddValues(double[] p)
        {
                _data.Add(p);
        }

        public void CalculateAverageForData()
        {
            IsAverageForDataCalculated = true;
            if (_data.Count > 0)
            {
                var tmp = (from doublese in _data from d in doublese select Math.Abs(d)).ToList();

                DataAverage = tmp.Average();
            }
            else
            {
                DataAverage = 0;
            }
            
        }
    }
}
