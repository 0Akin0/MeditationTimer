using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeditationTimer
{
    public class TextFileConnection
    {
        public TextFileConnection()
        {
            string sampleMedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "MeditationTimes.txt");

            if (!File.Exists(FilePath) && File.Exists(sampleMedFilePath))
            {
                File.Move(sampleMedFilePath, FilePath);
            }
        }

        public string FilePath { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Programm Data", "MeditationTimes.txt"); } }

        public void AppendSession(MeditationSession session)
        {
            File.AppendAllText(FilePath, $"{session.EndDateTime};{MeditationSession.GetDurationString(session.Duration)};{session.MeditationTechnique};{session.Memo}\n");
        }

        public List<MeditationSession> GetMeditationSessions()
        {
            List<MeditationSession> sessions = new List<MeditationSession>();

            if (File.Exists(FilePath))
            {
                List<string> lines = File.ReadAllLines(FilePath).ToList();
                lines.RemoveAt(1); //zweite Zeile ist sometimes used meditation techniques
                lines.RemoveAt(0); //erste Zeile ist often used meditation techniques

                foreach (var line in lines)
                {
                    MeditationSession session = new MeditationSession();
                    string[] components = line.Split(';');

                    session.EndDateTime = Convert.ToDateTime(components[0]);
                    session.Duration = TimeSpan.Parse(components[1]);
                    session.MeditationTechnique = components[2];
                    if (components.Length > 3) session.Memo = components[3];

                    sessions.Add(session);
                }
            }

            return sessions;
        }

        public List<string> GetOftenUsedMeditations()
        {
            return GetMeditations(0);
        }

        public List<string> GetSometimesUsedMeditations()
        {
            return GetMeditations(1);
        }

        public void OpenFile()
        {
            Process.Start(FilePath);
        }

        private List<string> GetMeditations(int line)
        {
            List<string> meditations = new List<string>();

            if (File.Exists(FilePath))
            {
                string meditationTechniquesString = File.ReadAllLines(FilePath)[line];
                meditations = meditationTechniquesString.Split(';').ToList();
            }

            return meditations;
        }
    }
}
