using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrainActivityMonitor.Properties;
using Emotiv;

namespace BrainActivityMonitor
{
    public partial class Form1 : Form
    {
        SettingsForm _settingsForm;
        EmoEngine _engine;
        SensorsManager _sm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            _engine = EmoEngine.Instance;
            _engine.EmoEngineConnected += EngineEmoEngineConnected;
            _engine.EmoEngineDisconnected += EngineEmoEngineDisconnected;
            _engine.UserAdded += engine_UserAdded;
            _engine.UserRemoved += engine_UserRemoved;
            _engine.EmoStateUpdated += EngineEmoStateUpdated;
            ConnectToEmoEngine();

            _settingsForm = new SettingsForm();

            _sm = new SensorsManager(pictureBox1);
        }

        void EngineEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            var eegData = _engine.GetData(e.userId);
            if (eegData == null)
            {
                return;
            }
            foreach (var sensor in _sm.Sensors.Keys)
            {
                var name = sensor.Name.ToString();
                name = name.Replace(Resources.SensorPrefix, "");
                try
                {
                    var channel = (EdkDll.EE_DataChannel_t) Enum.Parse(typeof (EdkDll.EE_DataChannel_t), name);
                    var data = eegData[channel];
                    sensor.Value = data[data.Length-1];
                    _sm.DrawSensor();
                } catch(Exception exc)
                {
                    
                }
            }
        }

        private double[] HighPassFilter(double[] input)
        {
            double fCut = 0.16F;
            const double W = 2.0F * 128;

            fCut *= 6.28318530717959F; // 2.0F * Math.Pi 
            double norm = 1.0F / (fCut + W);
            double a0 = W * norm;
            double a1 = -a0;
            double b1 = (W - fCut) * norm;

            double[] output = new double[input.Length];

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (i - 1 > 0)
                    output[i] = input[i] * a0 + input[i - 1] * a1 + output[i - 1] * b1;
            }

            return output;
        }

        private void ConnectToEmoEngine()
        {
            try
            {
                _engine.Connect();
            }
            catch (EmoEngineException eeException)
            {
                statusValueLabel.Text = eeException.Message;
            }
            catch (Exception exception)
            {
                statusValueLabel.Text = exception.Message;
            }
        }

        void engine_UserRemoved(object sender, EmoEngineEventArgs e)
        {
            throw new NotImplementedException();
        }

        void engine_UserAdded(object sender, EmoEngineEventArgs e)
        {
            _engine.DataAcquisitionEnable(e.userId, true);
        }

        void EngineEmoEngineDisconnected(object sender, EmoEngineEventArgs e)
        {
            statusValueLabel.Text = Resources.Form1_EngineEmoEngineDisconnected_Disconnected;
        }

        void EngineEmoEngineConnected(object sender, EmoEngineEventArgs e)
        {
            statusValueLabel.Text = Resources.Form1_engine_EmoEngineConnected_Connected;
        }

        private void PropertiesToolStripMenuItemClick(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }

        private void ToEmoEngineToolStripMenuItemClick(object sender, EventArgs e)
        {
            ConnectToEmoEngine();
        }

        private void ToEmoComposerToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                _engine.RemoteConnect(_settingsForm.GetRemoteHost(), _settingsForm.GetRemotePort());
            }
            catch (EmoEngineException eeException)
            {
                statusValueLabel.Text = eeException.Message;
            }
            catch (Exception exception)
            {
                statusValueLabel.Text = exception.Message;
            }
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            _engine.ProcessEvents();
        }

        private void neutralPositionSetManuallyButton_Click(object sender, EventArgs e)
        {
            /**
             * 1. Get data from sensors
             * 2. Add this data to sensorStatistics
             * 3. Do 1 and 2 for a some specific time
             * 4. At the end change sensorIsSetLabel and set some boolean value to true. Moreover calculate mean value from sensor.
             */
        }
    }
}
