using System;
using Emotiv;

namespace BrainActivityMonitor
{
    class Sensor
    {
        public EdkDll.EE_InputChannels_t Name { get; set; }
        public double Value { get; set; }

        public Sensor(EdkDll.EE_InputChannels_t name, double value = 0.0)
        {
            Name = name;
            Value = value;
        }

        public Sensor(String name, double value = 0.0)
        {
            var convertedName = (EdkDll.EE_InputChannels_t)Enum.Parse(typeof(EdkDll.EE_InputChannels_t), name);
            Name = convertedName;
            Value = value;
        }

        public SensorStatistics Statistics { get; set; }
    }
}
