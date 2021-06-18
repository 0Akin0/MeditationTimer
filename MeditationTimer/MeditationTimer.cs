using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Stopwatch Stopwatch;
        private string StopwatchElapsedTime { get { return MeditationSession.GetDurationString(Stopwatch.Elapsed); } }
        private TextFileConnection Conn;
        private TimeSpan NextDongTime;

        public MeditationTimer()
        {
            InitializeComponent();
            Stopwatch = new Stopwatch();
            Conn = new TextFileConnection();
            //timeMeditation ist standardmäßig aktiv

            AddMeditationTechniques();
            UpdateTimeTodayLabel();
        }

        private TimeSpan DongAfterXMinutes {
            get {
                int numberInTextbox = 0;

                if (int.TryParse(txtNoise.Text, out numberInTextbox) && numberInTextbox > 0)
                {
                    return new TimeSpan(0, numberInTextbox, 0);
                }

                return TimeSpan.Zero;
            }
        }

        private void timeMeditation_Tick(object sender, EventArgs e)
        {
            lblStopwatch.Text = StopwatchElapsedTime;

            if (NextDongTime > TimeSpan.Zero)
            {
                //timer und nächstes mal wo glocke geläutet werden soll zu string machen und vergleichen.
                //Damit nur stunden, minuten und sekunden verglichen werden, nicht millisekunden.
                if (StopwatchElapsedTime == MeditationSession.GetDurationString(NextDongTime))
                {
                    //wenn all x sekunden geläutet werden soll -> minuten anzahl die user geschrieben hat auf "nächstes mal wo glocke geläutet werden soll" addieren
                    if (chkNoiseAfterEvery.Checked)
                    {
                        NextDongTime += DongAfterXMinutes;
                    }

                    PlaySound();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Stopwatch.Start();
            NextDongTime = DongAfterXMinutes;
            DongSettingsEditable(false); //man darf nicht mehr dong time ändern. Erst nachdem man neue medit session startet geht es wieder
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
                DongSettingsEditable(true); //man darf wieder dong time ändern
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
                Conn.AppendSession(Stopwatch.Elapsed, cmbMeditationTechniques.SelectedItem.ToString());

                cmbMeditationTechniques.SelectedItem = null;
                Stopwatch.Reset();
                UpdateTimeTodayLabel();

                DongSettingsEditable(true); //man darf wieder dong time ändern
            }
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            Conn.OpenFile();
        }

        private void AddMeditationTechniques()
        {
            foreach (var technique in Conn.GetOftenUsedMeditations())
            {
                cmbMeditationTechniques.Items.Add(technique);
            }

            cmbMeditationTechniques.Items.Add("");

            foreach (var technique in Conn.GetSometimesUsedMeditations())
            {
                cmbMeditationTechniques.Items.Add(technique);
            }
        }

        private void UpdateTimeTodayLabel()
        {
            TimeSpan meditatedToday = new TimeSpan();
            int countMeditatedToday = 0;
            List<MeditationSession> sessions = Conn.GetMeditationSessions();
            lblDurationToday.Text = "Time meditated today: ";
            lblAmmountToday.Text = "How often meditated today: ";

            foreach (var session in sessions)
            {
                if (session.EndDateTime.Date == DateTime.Today)
                {
                    meditatedToday = meditatedToday.Add(session.Duration);
                    countMeditatedToday += 1;
                }
            }

            lblDurationToday.Text += MeditationSession.GetDurationString(meditatedToday);
            lblAmmountToday.Text += countMeditatedToday;
        }

        private void DongSettingsEditable(bool enabled)
        {
            txtNoise.Enabled = enabled;
            chkNoiseAfterEvery.Enabled = enabled;
        }

        private void PlaySound()
        {
            const string sAudioFileName = "MeditationAlertNoise.wav";
            string sAudioPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), sAudioFileName);

            using (var soundPlayer = new System.Media.SoundPlayer(sAudioPath))
            {
                soundPlayer.Load();
                soundPlayer.Play();
            }
        }

    }
}
