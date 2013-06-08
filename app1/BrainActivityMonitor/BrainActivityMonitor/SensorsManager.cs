using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using BrainActivityMonitor.Properties;
using Emotiv;

namespace BrainActivityMonitor
{
    class SensorsManager
    {
        public Dictionary<Sensor, SensorDisplayInfo> Sensors { get; set; }
        private readonly PictureBox _pictureBox;
        private readonly Font _font;

        public SensorsManager(PictureBox pictureBox)
        {
            Sensors = new Dictionary<Sensor, SensorDisplayInfo>();
            InitializeSensors();
            _pictureBox = pictureBox;
            _pictureBox.Paint += PictureBoxPaint;
            _font = new Font("Arial", 10, FontStyle.Bold);
        }

        void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            foreach(var sensor in Sensors.Keys)
            {
                var sensorName = Enum.GetName(typeof (EdkDll.EE_InputChannels_t), sensor.Name);
                Debug.Assert(sensorName != null, "sensorName != null");
                
                SensorDisplayInfo sensorDisplayInfo = Sensors[sensor];
                int sensorX = sensorDisplayInfo.X;
                int sensorY = sensorDisplayInfo.Y;
                
                sensorName = sensorName.Replace(Resources.SensorPrefix, "");
                e.Graphics.DrawString(sensorName, _font, Brushes.DimGray, sensorX + 3, sensorY + 33);
                
                var valueString = sensor.Value.ToString(CultureInfo.InvariantCulture);
                //sensorDisplayInfo.Brush = GetBrush(sensor.Value, sensor.Statistics);
                e.Graphics.FillEllipse(sensorDisplayInfo.Brush, sensorDisplayInfo.Rectangle);
                try
                {
                    valueString = valueString.Remove(6);
                } catch(Exception exc)
                {
                    
                }
                e.Graphics.DrawString(valueString, _font, Brushes.Black, sensorX + 8, sensorY + 10);
            }
        }

        private void InitializeSensors()
        {
            var doc = new XmlDocument();
            doc.Load(
                @"C:\Users\mariusz\Documents\GitHub\PracaMagisterska\app1\BrainActivityMonitor\BrainActivityMonitor\SensorsData.xml");

            if (doc.DocumentElement == null)
            {
                throw new Exception("Nie można odczytać danych wejściowych o sensorach!");
            }
            else
            {
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    // ReSharper disable PossibleNullReferenceException
                    int x = Int32.Parse(node.SelectSingleNode("x").InnerText);
                    int y = Int32.Parse(node.SelectSingleNode("y").InnerText);
                    int width = Int32.Parse(node.SelectSingleNode("width").InnerText);
                    int height = Int32.Parse(node.SelectSingleNode("height").InnerText);
                    var sensorDisplayInfo = new SensorDisplayInfo(x, y, width, height);
                    var name = Resources.SensorPrefix + node.SelectSingleNode("name").InnerText;
                    var sensor = new Sensor(name);
                    Sensors.Add(sensor, sensorDisplayInfo);
                    // ReSharper restore PossibleNullReferenceException
                }
            }
        }

        public void DrawSensor()
        {
            _pictureBox.Invalidate();
        }
    }
}
