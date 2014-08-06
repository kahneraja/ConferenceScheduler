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
            foreach (var talk in talks)
            {
                var track = FindSuitableTrack(talk.Minutes);
                track.Allocate(talk);
            }
        }

        private Track FindSuitableTrack(int minutes)
        {
            foreach (var track in Tracks)
            {
                if (track.HasAvailability(minutes))
                    return track;
            }

            var t = CreateNewTrack();
            return t;
        }

        private Track CreateNewTrack()
        {
            var track = new Track();
            Tracks.Add(track);
            return track;
        }
    }
}
