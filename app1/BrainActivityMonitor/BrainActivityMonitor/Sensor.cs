using System;
using System.Diagnostics;
using BrainActivityMonitor.Properties;
using Emotiv;

namespace BrainActivityMonitor
{
    class Sensor
    {
        public EdkDll.EE_InputChannels_t Name { get; set; }
        public double Value { get; set; }
        public double[] Values;

        public Sensor(EdkDll.EE_InputChannels_t name, double value = 0.0)
        {
            Name = name;
            Value = value;
            Statistics = new SensorStatistics();
        }

        public Sensor(String name, double value = 0.0)
        {
            var convertedName = (EdkDll.EE_InputChannels_t)Enum.Parse(typeof(EdkDll.EE_InputChannels_t), name);
            Name = convertedName;
            Value = value;
            Statistics = new SensorStatistics();
        }

        public SensorStatistics Statistics { get; set; }
        public Boolean IsReference { get; set; }

        public String GetConvertedName()
        {
            var sensorName = Enum.GetName(typeof (EdkDll.EE_InputChannels_t), Name);
            Debug.Assert(sensorName != null, "sensorName != null");
            return sensorName.Replace(Resources.SensorPrefix, "");
        }
    }
}
