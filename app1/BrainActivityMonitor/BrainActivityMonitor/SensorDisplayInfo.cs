using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BrainActivityMonitor
{
    class SensorDisplayInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Rectangle { get; set; }
        public Brush Brush { get; set; }

        public SensorDisplayInfo(int x, int y, int width, int height, Brush brush = null)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Rectangle = new Rectangle(X, Y, Width, Height);
            if (brush == null)
            {
                Brush = Brushes.Green;
            }
        }
    }
}
