using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeditationTimer
{
    public class MeditationSession
    {
        public MeditationSession()
        {
        }

        public MeditationSession(DateTime endDateTime, TimeSpan duration, string meditationTechnique) {
            EndDateTime = endDateTime;
            Duration = duration;
            MeditationTechnique = meditationTechnique;
        }

        public MeditationSession(DateTime endDateTime, TimeSpan duration, string meditationTechnique,string memo) : this (endDateTime,duration,meditationTechnique) {
            Memo = memo;
        }

        public DateTime EndDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string MeditationTechnique { get; set; }
        public string Memo { get; set; }



        public static string GetDurationString(TimeSpan duration)
        {
            return duration.ToString(@"hh\:mm\:ss");
        }
    }
}
