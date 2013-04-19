using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotiv;
using System.Windows.Forms;

namespace BrainActivityMonitor
{
    class Sensor
    {
        EdkDll.EE_InputChannels_t name;
        double value;
        SensorView view;

        public Sensor(EdkDll.EE_InputChannels_t name, double value = 0.0, SensorView view = null)
        {
            this.name = name;
            this.value = value;
            this.view = view;
        }

        public Sensor(String name, double value = 0.0, SensorView view = null)
        {
            EdkDll.EE_InputChannels_t convertedName = this.parse(name);
            this.name = convertedName;
            this.value = value;
            this.view = view;
        }

        private EdkDll.EE_InputChannels_t parse(string name)
        {
            switch (name)
            {
                case "AF3":
                    return EdkDll.EE_InputChannels_t.EE_CHAN_AF3;
                case "AF4":
                    return EdkDll.EE_InputChannels_t.EE_CHAN_AF4;
                default:
                    throw new Exception("Wrong name");
            }
        }

        public bool Draw(System.Windows.Forms.Form form)
        {
            if (view != null)
            {
                view.Draw(form);
                return true;
            }

            return false;
        }
    }
}
