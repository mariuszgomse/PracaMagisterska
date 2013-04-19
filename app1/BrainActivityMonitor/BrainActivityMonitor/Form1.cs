using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emotiv;

namespace BrainActivityMonitor
{
    public partial class Form1 : Form
    {
        SettingsForm settingsForm;
        EmoEngine engine;
        SensorsManager sm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = EmoEngine.Instance;
            engine.EmoEngineConnected += engine_EmoEngineConnected;
            engine.EmoEngineDisconnected += engine_EmoEngineDisconnected;
            engine.UserAdded += engine_UserAdded;
            engine.UserRemoved += engine_UserRemoved;
            connectToEmoEngine();

            settingsForm = new SettingsForm();

            sm = new SensorsManager();
            sm.initializeSensors();
        }

        private void connectToEmoEngine()
        {
            try
            {
                engine.Connect();
            }
            catch (EmoEngineException eeException)
            {
                this.statusValueLabel.Text = eeException.Message;
            }
            catch (Exception exception)
            {
                this.statusValueLabel.Text = exception.Message;
            }
        }

        void engine_UserRemoved(object sender, EmoEngineEventArgs e)
        {
            throw new NotImplementedException();
        }

        void engine_UserAdded(object sender, EmoEngineEventArgs e)
        {
            throw new NotImplementedException();
        }

        void engine_EmoEngineDisconnected(object sender, EmoEngineEventArgs e)
        {
            this.statusValueLabel.Text = "Disconnected";
        }

        void engine_EmoEngineConnected(object sender, EmoEngineEventArgs e)
        {
            this.statusValueLabel.Text = "Connected";
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void toEmoEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectToEmoEngine();
        }

        private void toEmoComposerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                engine.RemoteConnect(settingsForm.GetRemoteHost(), settingsForm.GetRemotePort());
            }
            catch (EmoEngineException eeException)
            {
                this.statusValueLabel.Text = eeException.Message;
            }
            catch (Exception exception)
            {
                this.statusValueLabel.Text = exception.Message;
            }
        }
    }
}
