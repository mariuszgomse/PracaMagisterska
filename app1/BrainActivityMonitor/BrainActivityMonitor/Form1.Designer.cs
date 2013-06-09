namespace BrainActivityMonitor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusValueLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toEmoEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toEmoComposerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.NeutralPositionIsSetLabel = new System.Windows.Forms.Label();
            this.neutralPositionSetManuallyButton = new System.Windows.Forms.Button();
            this.neutralPositionStopSetManuallyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadCSVButton = new System.Windows.Forms.Button();
            this.PlayLoadedCsvButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 40);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status:";
            // 
            // statusValueLabel
            // 
            this.statusValueLabel.AutoSize = true;
            this.statusValueLabel.Location = new System.Drawing.Point(58, 40);
            this.statusValueLabel.Name = "statusValueLabel";
            this.statusValueLabel.Size = new System.Drawing.Size(79, 13);
            this.statusValueLabel.TabIndex = 1;
            this.statusValueLabel.Text = "Not Connected";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toEmoEngineToolStripMenuItem,
            this.toEmoComposerToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Connect";
            // 
            // toEmoEngineToolStripMenuItem
            // 
            this.toEmoEngineToolStripMenuItem.Name = "toEmoEngineToolStripMenuItem";
            this.toEmoEngineToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.toEmoEngineToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.toEmoEngineToolStripMenuItem.Text = "To EmoEngine";
            this.toEmoEngineToolStripMenuItem.Click += new System.EventHandler(this.ToEmoEngineToolStripMenuItemClick);
            // 
            // toEmoComposerToolStripMenuItem
            // 
            this.toEmoComposerToolStripMenuItem.Name = "toEmoComposerToolStripMenuItem";
            this.toEmoComposerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.toEmoComposerToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.toEmoComposerToolStripMenuItem.Text = "To EmoComposer";
            this.toEmoComposerToolStripMenuItem.Click += new System.EventHandler(this.ToEmoComposerToolStripMenuItemClick);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(161, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 381);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // NeutralPositionIsSetLabel
            // 
            this.NeutralPositionIsSetLabel.AutoSize = true;
            this.NeutralPositionIsSetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NeutralPositionIsSetLabel.ForeColor = System.Drawing.Color.Red;
            this.NeutralPositionIsSetLabel.Location = new System.Drawing.Point(534, 50);
            this.NeutralPositionIsSetLabel.Name = "NeutralPositionIsSetLabel";
            this.NeutralPositionIsSetLabel.Size = new System.Drawing.Size(223, 24);
            this.NeutralPositionIsSetLabel.TabIndex = 4;
            this.NeutralPositionIsSetLabel.Text = "Neutral position is not set!";
            // 
            // neutralPositionSetManuallyButton
            // 
            this.neutralPositionSetManuallyButton.Location = new System.Drawing.Point(558, 86);
            this.neutralPositionSetManuallyButton.Name = "neutralPositionSetManuallyButton";
            this.neutralPositionSetManuallyButton.Size = new System.Drawing.Size(171, 23);
            this.neutralPositionSetManuallyButton.TabIndex = 5;
            this.neutralPositionSetManuallyButton.Text = "Set neutral position manually";
            this.neutralPositionSetManuallyButton.UseVisualStyleBackColor = true;
            this.neutralPositionSetManuallyButton.Click += new System.EventHandler(this.neutralPositionSetManuallyButton_Click);
            // 
            // neutralPositionStopSetManuallyButton
            // 
            this.neutralPositionStopSetManuallyButton.Location = new System.Drawing.Point(558, 116);
            this.neutralPositionStopSetManuallyButton.Name = "neutralPositionStopSetManuallyButton";
            this.neutralPositionStopSetManuallyButton.Size = new System.Drawing.Size(171, 25);
            this.neutralPositionStopSetManuallyButton.TabIndex = 6;
            this.neutralPositionStopSetManuallyButton.Text = "Stop setting neutral possition";
            this.neutralPositionStopSetManuallyButton.UseVisualStyleBackColor = true;
            this.neutralPositionStopSetManuallyButton.Visible = false;
            this.neutralPositionStopSetManuallyButton.Click += new System.EventHandler(this.neutralPositionStopSetManuallyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(538, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 323);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neutral Values";
            // 
            // loadCSVButton
            // 
            this.loadCSVButton.Location = new System.Drawing.Point(15, 86);
            this.loadCSVButton.Name = "loadCSVButton";
            this.loadCSVButton.Size = new System.Drawing.Size(122, 23);
            this.loadCSVButton.TabIndex = 8;
            this.loadCSVButton.Text = "Load CSV";
            this.loadCSVButton.UseVisualStyleBackColor = true;
            this.loadCSVButton.Click += new System.EventHandler(this.loadCSVButton_Click);
            // 
            // PlayLoadedCsvButton
            // 
            this.PlayLoadedCsvButton.Location = new System.Drawing.Point(15, 116);
            this.PlayLoadedCsvButton.Name = "PlayLoadedCsvButton";
            this.PlayLoadedCsvButton.Size = new System.Drawing.Size(122, 25);
            this.PlayLoadedCsvButton.TabIndex = 9;
            this.PlayLoadedCsvButton.Text = "Play loaded CSV";
            this.PlayLoadedCsvButton.UseVisualStyleBackColor = true;
            this.PlayLoadedCsvButton.Visible = false;
            this.PlayLoadedCsvButton.Click += new System.EventHandler(this.PlayLoadedCsvButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 482);
            this.Controls.Add(this.PlayLoadedCsvButton);
            this.Controls.Add(this.loadCSVButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.neutralPositionStopSetManuallyButton);
            this.Controls.Add(this.neutralPositionSetManuallyButton);
            this.Controls.Add(this.NeutralPositionIsSetLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusValueLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Brain Activity Monitor";
            this.Load += new System.EventHandler(this.Form1Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusValueLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toEmoEngineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toEmoComposerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label NeutralPositionIsSetLabel;
        private System.Windows.Forms.Button neutralPositionSetManuallyButton;
        private System.Windows.Forms.Button neutralPositionStopSetManuallyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button loadCSVButton;
        private System.Windows.Forms.Button PlayLoadedCsvButton;


    }
}

