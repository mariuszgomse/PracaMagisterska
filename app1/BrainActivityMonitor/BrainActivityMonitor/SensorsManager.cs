using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BrainActivityMonitor
{
    class SensorsManager
    {
        List<Sensor> sensors;

        public SensorsManager()
        {
            sensors = new List<Sensor>();
        }

        public void initializeSensors()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\mariusz\Documents\GitHub\PracaMagisterska\app1\BrainActivityMonitor\BrainActivityMonitor\SensorsData.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                int x = Int32.Parse(node.SelectSingleNode("x").InnerText);
                int y = Int32.Parse(node.SelectSingleNode("y").InnerText);
                int width = Int32.Parse(node.SelectSingleNode("width").InnerText);
                int height = Int32.Parse(node.SelectSingleNode("height").InnerText);
                SensorView sv = new SensorView(x, y, width, height);
                Sensor s = new Sensor(node.SelectSingleNode("name").InnerText, 0, sv);
                sensors.Add(s);
            }
        }
    }
}
