﻿using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BrainActivityMonitor.Properties;
using Emotiv;

namespace BrainActivityMonitor
{
    public partial class BrainActivityMonitorForm : Form
    {
        SettingsForm _settingsForm;
        EmoEngine _engine;
        SensorsManager _sm;
        private bool _neutralPositionReading;
        private bool _isDataFromCsv;
        private CsvManager _csvManager;

        public BrainActivityMonitorForm()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            _engine = EmoEngine.Instance;
            _engine.EmoEngineConnected += EngineEmoEngineConnected;
            _engine.EmoEngineDisconnected += EngineEmoEngineDisconnected;
            _engine.UserAdded += EngineUserAdded;
            _engine.UserRemoved += engine_UserRemoved;
            _engine.EmoStateUpdated += EngineEmoStateUpdated;
            ConnectToEmoEngine();

            _settingsForm = new SettingsForm();

            _sm = new SensorsManager(pictureBox1);
            DrawNeutralSensorGroupBox();
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
                var name = sensor.GetConvertedName();
                try
                {
                    var channel = (EdkDll.EE_DataChannel_t) Enum.Parse(typeof (EdkDll.EE_DataChannel_t), name);
                    var data = eegData[channel];
                    sensor.Value = data[data.Length-1];
                    sensor.Values = data;
                    if (_neutralPositionReading)
                    {
                        sensor.Statistics.AddValue(sensor.Value);
                        sensor.Statistics.AddValues(sensor.Values);
                    }
                    _sm.DrawSensor();
                } catch (Exception)
                {
                    
                }
            }
        }

        private void ProcessCsvData()
        {
            var eegData = _csvManager.GetData();
            if (eegData == null)
            {
                _isDataFromCsv = false;
                statusStrip1.Text = "Csv data read - normal mode on";
                MessageBox.Show("Csv data read end");
                return;
            }
            foreach (var sensor in _sm.Sensors.Keys)
            {
                var name = sensor.GetConvertedName();
                try
                {
                    var channel = (EdkDll.EE_DataChannel_t)Enum.Parse(typeof(EdkDll.EE_DataChannel_t), name);
                    var data = eegData[channel];
                    sensor.Value = data[data.Length - 1];
                    sensor.Values = data;
                    if (_neutralPositionReading)
                    {
                        sensor.Statistics.AddValue(sensor.Value);
                        sensor.Statistics.AddValues(sensor.Values);
                    }
                    _sm.DrawSensor();
                }
                catch (Exception exc)
                {

                }
            }
        }

        private void ConnectToEmoEngine()
        {
            try
            {
                _engine.Connect();
            }
            catch (EmoEngineException eeException)
            {
                statusStrip1.Text = eeException.Message;
            }
            catch (Exception exception)
            {
                statusStrip1.Text = exception.Message;
            }
        }

        void engine_UserRemoved(object sender, EmoEngineEventArgs e)
        {
            throw new NotImplementedException();
        }

        void EngineUserAdded(object sender, EmoEngineEventArgs e)
        {
            _engine.DataAcquisitionEnable(e.userId, true);
        }

        void EngineEmoEngineDisconnected(object sender, EmoEngineEventArgs e)
        {
            statusStrip1.Text = Resources.Form1_EngineEmoEngineDisconnected_Disconnected;
        }

        void EngineEmoEngineConnected(object sender, EmoEngineEventArgs e)
        {
            statusStrip1.Text = Resources.Form1_engine_EmoEngineConnected_Connected;
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
                statusStrip1.Text = eeException.Message;
            }
            catch (Exception exception)
            {
                statusStrip1.Text = exception.Message;
            }
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            if (!_isDataFromCsv)
            {
                _engine.ProcessEvents();
            } else
            {
                ProcessCsvData();
            }
           
        }

        private void NeutralPositionSetManuallyButtonClick(object sender, EventArgs e)
        {
            _neutralPositionReading = true;
            neutralPositionSetManuallyButton.Visible = false;
            neutralPositionStopSetManuallyButton.Visible = true;
        }

        private void NeutralPositionStopSetManuallyButtonClick(object sender, EventArgs e)
        {
            _neutralPositionReading = false;
            neutralPositionStopSetManuallyButton.Visible = false;
            neutralPositionSetManuallyButton.Visible = true;
            foreach (Sensor sensor in _sm.Sensors.Keys)
            {
                sensor.Statistics.CalculateAverage();
                sensor.Statistics.CalculateAverageForData();
            }
            DrawNeutralSensorGroupBox();
            NeutralPositionIsSetLabel.Visible = false;
        }

        private void DrawNeutralSensorGroupBox()
        {
            groupBox1.Controls.Clear();
            int yCounter = 20;
            foreach (Sensor sensor in _sm.Sensors.Keys)
            {
                if (!sensor.IsReference)
                {
                    var label = new Label {Text = sensor.Name.ToString(), Location = new Point(10, yCounter)};
                    groupBox1.Controls.Add(label);
                    label = new Label {Text = sensor.Statistics.DataAverage.ToString(CultureInfo.InvariantCulture)};
                    if (label.Text.Length > 6)
                    {
                        label.Text = label.Text.Remove(6);
                    }
                    label.Location = new Point(150, yCounter);
                    groupBox1.Controls.Add(label);
                    yCounter += 22;
                }
            }
        }

        private void EpocToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (epocToolStripMenuItem.Checked) return;
            
            SetEpocToolStripMenuItemChecked();
            csvControlGroupBox.Visible = false;
        }

        private void CsvToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (csvToolStripMenuItem.Checked) return;

                var csvManager = GetCsvManager();
                if (csvManager.IsFileLoaded())
                {
                    SetCsvToolStripMenuItemChecked();
                    csvControlGroupBox.Visible = true;
                    return;
                }

                LoadCsv();
                SetCsvToolStripMenuItemChecked();
                csvControlGroupBox.Visible = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                SetEpocToolStripMenuItemChecked();
            }
        }

        private void SetEpocToolStripMenuItemChecked()
        {
            csvToolStripMenuItem.Checked = false;
            epocToolStripMenuItem.Checked = true;
        }

        private void SetCsvToolStripMenuItemChecked()
        {
            epocToolStripMenuItem.Checked = false;
            csvToolStripMenuItem.Checked = true;
        }

        private CsvManager GetCsvManager()
        {
            return _csvManager ?? (_csvManager = new CsvManager());
        }

        private void LoadCsvButtonClick1(object sender, EventArgs e)
        {
            try
            {
                LoadCsv();
            } catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void PlayLoadedCsvButtonClick1(object sender, EventArgs e)
        {
            _isDataFromCsv = true;
        }

        private void LoadCsv()
        {
            var csvManager = GetCsvManager();
            var rowsLoaded = csvManager.LoadFile();
            MessageBox.Show(string.Format("{0} rows loaded", rowsLoaded));
            toolStripStatusLabel1.Text = string.Format("{0} read", csvManager.GetLoadedFileName());
        }
    }
}
