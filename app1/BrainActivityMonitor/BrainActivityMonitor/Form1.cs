using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        private bool NeutralPositionReading = false;
        private bool IsDataFromCSV = false;
        private CsvDataManager csvDataManager;

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
                    if (NeutralPositionReading)
                    {
                        sensor.Statistics.AddValue(sensor.Value);
                        sensor.Statistics.addValues(sensor.Values);
                    }
                    _sm.DrawSensor();
                } catch(Exception exc)
                {
                    
                }
            }
        }

        private void ProcessCsvData()
        {
            var eegData = csvDataManager.getData();
            if (eegData == null)
            {
                IsDataFromCSV = false;
                PlayLoadedCsvButton.Visible = false;
                statusValueLabel.Text = "Csv data read - normal mode on";
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
                    if (NeutralPositionReading)
                    {
                        sensor.Statistics.AddValue(sensor.Value);
                        sensor.Statistics.addValues(sensor.Values);
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
            if (!IsDataFromCSV)
            {
                _engine.ProcessEvents();
            } else
            {
                ProcessCsvData();
            }
           
        }

        private void neutralPositionSetManuallyButton_Click(object sender, EventArgs e)
        {
            NeutralPositionReading = true;
            neutralPositionSetManuallyButton.Visible = false;
            neutralPositionStopSetManuallyButton.Visible = true;
        }

        private void neutralPositionStopSetManuallyButton_Click(object sender, EventArgs e)
        {
            NeutralPositionReading = false;
            neutralPositionStopSetManuallyButton.Visible = false;
            neutralPositionSetManuallyButton.Visible = true;
            int yCounter = 20;
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
                    Label label = new Label();
                    label.Text = sensor.Name.ToString();
                    label.Location = new Point(10, yCounter);
                    groupBox1.Controls.Add(label);
                    label = new Label();
                    label.Text = sensor.Statistics.dataAverage.ToString(CultureInfo.InvariantCulture);
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

        private void loadCSVButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openCsvFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var reader = new CsvEpocFileReader(openCsvFileDialog.FileName);
                var rowsReaded = reader.readData();
                MessageBox.Show("Loaded " + rowsReaded + " rows of data");
                PlayLoadedCsvButton.Visible = true;
                csvDataManager = new CsvDataManager(reader);
                statusValueLabel.Text = openCsvFileDialog.SafeFileName + " read";
            }
        }

        private void PlayLoadedCsvButton_Click(object sender, EventArgs e)
        {
            IsDataFromCSV = true;
        }
    }
}
