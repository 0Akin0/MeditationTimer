using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeditationTimer
{
    /// <remarks>
    /// results fenster
    ///     grid mit spalten: date, time, x th time of the day, duration
    /// Infos über meditation techniques + link + english/ german name
    /// Datei sortiert nach neuste meditation -> älteste meditation ganz unten(evt ein close event was die liste sortiert nochmal in die Datei schreibt)
    /// statistics: 
    ///     average meditation length a session, average meditation length a day, days meditated, days missed, longest meditation ever, 
    ///     at what time do I meditate most often, graph(line graph) like from ticktick(screenshot on desktop), how often did I do alternate nostril breathing for example
    /// on close: stoppuhr pause if stopuhr zeit nicht 00:00:00, bescheid geben das Zeit verworfen wird
    /// </remarks>

    public partial class MeditationTimer : Form
    {
        Stopwatch Stopwatch;
        public string TimeFileFullPath { get { return Path.Combine(Directory.GetCurrentDirectory(), "MeditationTimes.txt"); } }
        public string StopwatchElapsedTime { get { return MeditationSession.GetDurationString(Stopwatch.Elapsed); } }

        public MeditationTimer()
        {
            InitializeComponent();
            Stopwatch = new Stopwatch();
            //timeMeditation ist standardmäßig aktiv

            AddMeditationTechniques();
            UpdateTimeTodayLabel();
        }

        private void timeMeditation_Tick(object sender, EventArgs e)
        {
            lblStopwatch.Text = StopwatchElapsedTime;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Stopwatch.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Stopwatch.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Stopwatch.Stop();

            DialogResult result = MessageBox.Show("Do you want to reset the timer? The time will be lost.", this.Text, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                cmbMeditationTechniques.SelectedItem = null;
                Stopwatch.Reset();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Stopwatch.Stop();

            if (Stopwatch.ElapsedTicks == 0)
            {
                MessageBox.Show("No time has passed!");
                return;
            }

            if (cmbMeditationTechniques.SelectedItem == null || string.IsNullOrWhiteSpace(cmbMeditationTechniques.SelectedItem.ToString()))
            {
                MessageBox.Show("No meditation technique selected!");
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to stop meditating?", this.Text, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                //File.AppendAllText(TimeFileFullPath, $"{DateTime.Now.ToString()};{StopwatchElapsedTime};{cmbMeditationTechniques.SelectedItem.ToString()}\n");
                TextFileConnection conn = new TextFileConnection(TimeFileFullPath);
                conn.AppendSession(Stopwatch.Elapsed, cmbMeditationTechniques.SelectedItem.ToString());

                cmbMeditationTechniques.SelectedItem = null;
                Stopwatch.Reset();
                UpdateTimeTodayLabel();
            }
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            Process.Start(TimeFileFullPath);
        }

        private void AddMeditationTechniques()
        {
            TextFileConnection conn = new TextFileConnection(TimeFileFullPath);

            foreach (var technique in conn.GetOftenUsedMeditations())
            {
                cmbMeditationTechniques.Items.Add(technique);
            }

            cmbMeditationTechniques.Items.Add("");

            foreach (var technique in conn.GetSometimesUsedMeditations())
            {
                cmbMeditationTechniques.Items.Add(technique);
            }
        }

        private void UpdateTimeTodayLabel()
        {
            TextFileConnection conn = new TextFileConnection(TimeFileFullPath);
            TimeSpan meditatedToday = new TimeSpan();
            List<MeditationSession> sessions = conn.GetMeditationSessions();
            lblDurationToday.Text = "Time meditated today: ";

            foreach (var session in sessions)
            {
                if (session.EndDateTime.Date == DateTime.Today)
                {
                    meditatedToday = meditatedToday.Add(session.Duration);
                }
            }

            lblDurationToday.Text += MeditationSession.GetDurationString(meditatedToday);
        }

    }
}
