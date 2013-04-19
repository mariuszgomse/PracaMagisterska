using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainActivityMonitor
{
    public partial class SettingsForm : Form
    {
        Settings settings;
        String rememberedHost;
        ushort rememberedPort;

        public SettingsForm()
        {
            InitializeComponent();
            settings = new Settings();
            textBoxRemoteHost.DataBindings.Add(new Binding("Text", settings, Settings.RemoteHostConst));
            textBoxRemotePort.DataBindings.Add(new Binding("Text", settings, Settings.RemotePortConst));
        }

        public String GetRemoteHost()
        {
            return settings.RemoteHost;
        }

        public ushort GetRemotePort()
        {
            return settings.RemotePort;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            rememberedHost = settings.RemoteHost;
            rememberedPort = settings.RemotePort;
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonCancelSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings.RemoteHost = rememberedHost;
            settings.RemotePort = rememberedPort;
        }

    }
}
