using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Common.Store
{
    public class LoadTalks
    {

        public static List<Talk> LoadFile(string path)
        {
            var lines = File.ReadAllLines(path).ToList();

            var talks = ConvertText(lines);

            talks.OrderByDescending(x => x.Minutes);

            return talks;
        }

        public static List<Talk> ConvertText(List<string> lines)
        {
            var talks = new List<Talk>();
            foreach(var line in lines)
            {
                var talk = CreateTalk(line);
                talks.Add(talk);
            }
            
            return talks;
        }

        private static Talk CreateTalk(string line)
        {
            var talk = new Talk();
            talk.Title = GetTitle(line);
            talk.Minutes = GetMinutes(line);
            talk.Description = line;
            return talk;
        }

        public static int GetMinutes(string line)
        {
            var minuteText = line.Split(' ').Last();
            if (minuteText == "lightning")
                return 5;

            var minuteString = minuteText.Replace("min", "");
            var minutes = int.Parse(minuteString);
            return minutes;
        }

        public static string GetTitle(string line)
        {
            return line.Substring(0, line.LastIndexOf(' '));
        }
    }
}
