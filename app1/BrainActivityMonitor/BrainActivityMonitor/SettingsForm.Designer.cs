namespace BrainActivityMonitor
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxRemoteHost = new System.Windows.Forms.TextBox();
            this.textBoxRemotePort = new System.Windows.Forms.TextBox();
            this.groupBoxRemote = new System.Windows.Forms.GroupBox();
            this.labelRemotePort = new System.Windows.Forms.Label();
            this.labelRemoteHost = new System.Windows.Forms.Label();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonCancelSettings = new System.Windows.Forms.Button();
            this.groupBoxRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxRemoteHost
            // 
            this.textBoxRemoteHost.AccessibleName = "";
            this.textBoxRemoteHost.Location = new System.Drawing.Point(42, 19);
            this.textBoxRemoteHost.Name = "textBoxRemoteHost";
            this.textBoxRemoteHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxRemoteHost.TabIndex = 0;
            // 
            // textBoxRemotePort
            // 
            this.textBoxRemotePort.Location = new System.Drawing.Point(42, 49);
            this.textBoxRemotePort.Name = "textBoxRemotePort";
            this.textBoxRemotePort.Size = new System.Drawing.Size(100, 20);
            this.textBoxRemotePort.TabIndex = 1;
            // 
            // groupBoxRemote
            // 
            this.groupBoxRemote.Controls.Add(this.labelRemotePort);
            this.groupBoxRemote.Controls.Add(this.labelRemoteHost);
            this.groupBoxRemote.Controls.Add(this.textBoxRemotePort);
            this.groupBoxRemote.Controls.Add(this.textBoxRemoteHost);
            this.groupBoxRemote.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRemote.Name = "groupBoxRemote";
            this.groupBoxRemote.Size = new System.Drawing.Size(172, 86);
            this.groupBoxRemote.TabIndex = 2;
            this.groupBoxRemote.TabStop = false;
            this.groupBoxRemote.Text = "Remote";
            // 
            // labelRemotePort
            // 
            this.labelRemotePort.AutoSize = true;
            this.labelRemotePort.Location = new System.Drawing.Point(7, 52);
            this.labelRemotePort.Name = "labelRemotePort";
            this.labelRemotePort.Size = new System.Drawing.Size(26, 13);
            this.labelRemotePort.TabIndex = 2;
            this.labelRemotePort.Text = "Port";
            // 
            // labelRemoteHost
            // 
            this.labelRemoteHost.AutoSize = true;
            this.labelRemoteHost.Location = new System.Drawing.Point(7, 22);
            this.labelRemoteHost.Name = "labelRemoteHost";
            this.labelRemoteHost.Size = new System.Drawing.Size(29, 13);
            this.labelRemoteHost.TabIndex = 1;
            this.labelRemoteHost.Text = "Host";
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(127, 142);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 3;
            this.buttonSaveSettings.Text = "OK";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // buttonCancelSettings
            // 
            this.buttonCancelSettings.Location = new System.Drawing.Point(208, 142);
            this.buttonCancelSettings.Name = "buttonCancelSettings";
            this.buttonCancelSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelSettings.TabIndex = 4;
            this.buttonCancelSettings.Text = "Cancel";
            this.buttonCancelSettings.UseVisualStyleBackColor = true;
            this.buttonCancelSettings.Click += new System.EventHandler(this.buttonCancelSettings_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 177);
            this.Controls.Add(this.buttonCancelSettings);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.groupBoxRemote);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBoxRemote.ResumeLayout(false);
            this.groupBoxRemote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRemoteHost;
        private System.Windows.Forms.TextBox textBoxRemotePort;
        private System.Windows.Forms.GroupBox groupBoxRemote;
        private System.Windows.Forms.Label labelRemotePort;
        private System.Windows.Forms.Label labelRemoteHost;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonCancelSettings;
    }
}