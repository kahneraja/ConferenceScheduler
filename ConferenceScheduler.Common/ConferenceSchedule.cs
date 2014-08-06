using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Common
{
    public class ConferenceSchedule
    {
        public List<Track> Tracks { get; set; }

        public ConferenceSchedule()
        {
            Tracks = new List<Track>();
        }


        public void AllocateTalks(List<Talk> talks)
        {
            var track = new Track();

            foreach (var talk in talks)
            {
                track.MorningSession.Talks.Add(talk);
            }

            Tracks.Add(track);
        }
    }
}
