namespace poetts
{
    partial class GUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textMatch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarRate = new System.Windows.Forms.TrackBar();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.comboBoxVoices = new System.Windows.Forms.ComboBox();
            this.textOcr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusStrings = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusOCR = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTTS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusApp = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textMatch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.trackBarRate);
            this.groupBox1.Controls.Add(this.trackBarVolume);
            this.groupBox1.Controls.Add(this.comboBoxVoices);
            this.groupBox1.Controls.Add(this.textOcr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1122, 472);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text To Speech";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Best matching string";
            // 
            // textMatch
            // 
            this.textMatch.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMatch.Location = new System.Drawing.Point(10, 202);
            this.textMatch.Multiline = true;
            this.textMatch.Name = "textMatch";
            this.textMatch.Size = new System.Drawing.Size(1081, 109);
            this.textMatch.TabIndex = 19;
            this.textMatch.Text = "No match found.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Voice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Volume";
            // 
            // trackBarRate
            // 
            this.trackBarRate.LargeChange = 2;
            this.trackBarRate.Location = new System.Drawing.Point(554, 406);
            this.trackBarRate.Name = "trackBarRate";
            this.trackBarRate.Size = new System.Drawing.Size(537, 56);
            this.trackBarRate.TabIndex = 14;
            this.trackBarRate.Value = 1;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(7, 406);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(541, 56);
            this.trackBarVolume.SmallChange = 5;
            this.trackBarVolume.TabIndex = 13;
            this.trackBarVolume.Value = 75;
            // 
            // comboBoxVoices
            // 
            this.comboBoxVoices.FormattingEnabled = true;
            this.comboBoxVoices.Location = new System.Drawing.Point(10, 335);
            this.comboBoxVoices.Name = "comboBoxVoices";
            this.comboBoxVoices.Size = new System.Drawing.Size(1081, 26);
            this.comboBoxVoices.TabIndex = 12;
            // 
            // textOcr
            // 
            this.textOcr.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOcr.Location = new System.Drawing.Point(10, 56);
            this.textOcr.Multiline = true;
            this.textOcr.Name = "textOcr";
            this.textOcr.Size = new System.Drawing.Size(1083, 109);
            this.textOcr.TabIndex = 7;
            this.textOcr.Text = "No text found.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 9F);
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Extracted text";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 607);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1122, 77);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(194, 36);
            this.button5.TabIndex = 4;
            this.button5.Text = "Extract (Ctrl+E)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(907, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 37);
            this.button4.TabIndex = 3;
            this.button4.Text = "Parameters";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(684, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Stop (Ctrl+S)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pause (Ctrl+P)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read (Ctrl+R)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusFiles,
            this.toolStripStatusStrings,
            this.toolStripStatusOCR,
            this.toolStripStatusTTS,
            this.toolStripStatusApp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 692);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1145, 25);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 20);
            this.toolStripStatusLabel1.Text = "Language: English";
            // 
            // toolStripStatusFiles
            // 
            this.toolStripStatusFiles.Name = "toolStripStatusFiles";
            this.toolStripStatusFiles.Size = new System.Drawing.Size(53, 20);
            this.toolStripStatusFiles.Text = "Files: 0";
            // 
            // toolStripStatusStrings
            // 
            this.toolStripStatusStrings.Name = "toolStripStatusStrings";
            this.toolStripStatusStrings.Size = new System.Drawing.Size(69, 20);
            this.toolStripStatusStrings.Text = "Strings: 0";
            // 
            // toolStripStatusOCR
            // 
            this.toolStripStatusOCR.Name = "toolStripStatusOCR";
            this.toolStripStatusOCR.Size = new System.Drawing.Size(53, 20);
            this.toolStripStatusOCR.Text = "OCR: 0";
            // 
            // toolStripStatusTTS
            // 
            this.toolStripStatusTTS.Name = "toolStripStatusTTS";
            this.toolStripStatusTTS.Size = new System.Drawing.Size(48, 20);
            this.toolStripStatusTTS.Text = "TTS: 0";
            // 
            // toolStripStatusApp
            // 
            this.toolStripStatusApp.Name = "toolStripStatusApp";
            this.toolStripStatusApp.Size = new System.Drawing.Size(116, 20);
            this.toolStripStatusApp.Text = "Status: Loading..";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1122, 110);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quick Help";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1109, 82);
            this.label6.TabIndex = 0;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 717);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI";
            this.Text = "Poe·tts — Pillars of Eternity Text to Speech";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textOcr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarRate;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.ComboBox comboBoxVoices;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusApp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusFiles;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStrings;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusOCR;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTTS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textMatch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;

    }
}

