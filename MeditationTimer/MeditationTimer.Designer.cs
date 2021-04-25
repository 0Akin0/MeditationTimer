namespace MeditationTimer
{
    partial class MeditationTimer
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
            this.lblStopwatch = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.timeMeditation = new System.Windows.Forms.Timer(this.components);
            this.cmbMeditationTechniques = new System.Windows.Forms.ComboBox();
            this.lblDurationToday = new System.Windows.Forms.Label();
            this.lblAmmountToday = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStopwatch
            // 
            this.lblStopwatch.AutoSize = true;
            this.lblStopwatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopwatch.Location = new System.Drawing.Point(12, 9);
            this.lblStopwatch.Name = "lblStopwatch";
            this.lblStopwatch.Size = new System.Drawing.Size(103, 29);
            this.lblStopwatch.TabIndex = 0;
            this.lblStopwatch.Text = "00:00:00";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 90);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(113, 90);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(13, 140);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(113, 140);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(13, 234);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(92, 23);
            this.btnViewResults.TabIndex = 5;
            this.btnViewResults.Text = "View Results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // timeMeditation
            // 
            this.timeMeditation.Enabled = true;
            this.timeMeditation.Tick += new System.EventHandler(this.timeMeditation_Tick);
            // 
            // cmbMeditationTechniques
            // 
            this.cmbMeditationTechniques.FormattingEnabled = true;
            this.cmbMeditationTechniques.Location = new System.Drawing.Point(12, 169);
            this.cmbMeditationTechniques.Name = "cmbMeditationTechniques";
            this.cmbMeditationTechniques.Size = new System.Drawing.Size(176, 21);
            this.cmbMeditationTechniques.TabIndex = 6;
            // 
            // lblDurationToday
            // 
            this.lblDurationToday.AutoSize = true;
            this.lblDurationToday.Location = new System.Drawing.Point(17, 42);
            this.lblDurationToday.Name = "lblDurationToday";
            this.lblDurationToday.Size = new System.Drawing.Size(35, 13);
            this.lblDurationToday.TabIndex = 7;
            this.lblDurationToday.Text = "label1";
            // 
            // lblAmmountToday
            // 
            this.lblAmmountToday.AutoSize = true;
            this.lblAmmountToday.Location = new System.Drawing.Point(17, 60);
            this.lblAmmountToday.Name = "lblAmmountToday";
            this.lblAmmountToday.Size = new System.Drawing.Size(35, 13);
            this.lblAmmountToday.TabIndex = 8;
            this.lblAmmountToday.Text = "label1";
            // 
            // MeditationTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 279);
            this.Controls.Add(this.lblAmmountToday);
            this.Controls.Add(this.lblDurationToday);
            this.Controls.Add(this.cmbMeditationTechniques);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblStopwatch);
            this.Name = "MeditationTimer";
            this.Text = "Meditation Timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStopwatch;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.Timer timeMeditation;
        private System.Windows.Forms.ComboBox cmbMeditationTechniques;
        private System.Windows.Forms.Label lblDurationToday;
        private System.Windows.Forms.Label lblAmmountToday;
    }
}

