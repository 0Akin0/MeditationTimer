using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeditationTimer
{
    class TextFileConnection
    {
        public TextFileConnection(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        public void AppendSession(MeditationSession session)
        {
            AppendSession(session.Duration, session.MeditationTechnique);
        }
        public void AppendSession(TimeSpan duration, string meditationTechnique)
        {
            File.AppendAllText(FilePath, $"{DateTime.Now.ToString()};{MeditationSession.GetDurationString(duration)};{meditationTechnique}\n");
        }

        public List<MeditationSession> GetMeditationSessions()
        {
            List<MeditationSession> sessions = new List<MeditationSession>();
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

                sessions.Add(session);
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

        private List<string> GetMeditations(int line)
        {
            string meditationTechniquesString = File.ReadAllLines(FilePath)[line];
            string[] meditationTechniques = meditationTechniquesString.Split(';');

            return meditationTechniques.ToList();
        }
    }
}
