using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainActivityMonitor
{
    class SensorView
    {
        Color color;
        Rectangle rectangle;


        public SensorView(int x, int y, int width, int height)
        {
            this.rectangle = new Rectangle(x, y, width, height);
            this.color = System.Drawing.Color.Black;
        }

        public void Draw(System.Windows.Forms.Form form)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(this.color);
            System.Drawing.Graphics formGraphics;
            formGraphics = form.CreateGraphics();
            formGraphics.FillEllipse(myBrush, this.rectangle);
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}
