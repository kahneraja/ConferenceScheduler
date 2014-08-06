using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Common.Store
{
    public class SaveSchedule
    {
        public static List<string> ExportFile(ConferenceSchedule conferenceSchedule, string path)
        {
            var lines = ConvertToLines(conferenceSchedule);
            File.WriteAllLines(path, lines.ToArray());
            return lines;
        }

        public static List<string> ConvertToLines(ConferenceSchedule conferenceSchedule)
        {
            var lines = new List<string>();

            var i = 1;
            foreach(var track in conferenceSchedule.Tracks){
                var line = string.Format("Track {0}:", i);
                lines.Add(line);

                foreach(var talk in track.Morning.Talks){
                    var talkLine = GetTalkLine(talk);
                    lines.Add(talkLine);
                }

                lines.Add("12:00PM Lunch");

                foreach (var talk in track.Afternoon.Talks)
                {
                    var talkLine = GetTalkLine(talk);
                    lines.Add(talkLine);
                }

                var networkingLine = GetNetworkingLine(track);

                lines.Add(networkingLine);

                lines.Add("");
                i++;
            }

            return lines;
        }

        private static string GetTalkLine(Talk talk)
        {
            var time = DateTime.Today.Add(talk.StartTime).ToString("hh:mmtt");
            var talkLine = string.Format("{0} {1}", time, talk.Description);
            return talkLine;
        }

        private static string GetNetworkingLine(Track track)
        {
            var time = DateTime.Today.Add(track.NetworkingTime).ToString("hh:mmtt");
            var talkLine = string.Format("{0} Networking Event", time);
            return talkLine;
        }
    }
}
