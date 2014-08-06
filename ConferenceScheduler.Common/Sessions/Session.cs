using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceScheduler.Common
{
    public abstract class Session
    {
        public List<Talk> Talks { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan ClosingTime
        {
            get
            {
                var availableTimeSpan = TimeSpan.FromMinutes(AvailableMinutes);
                return EndTime - availableTimeSpan;
            }
        }

        public int TotalMinutes
        {
            get
            {
                var timespan = EndTime - StartTime;
                return (int)timespan.TotalMinutes;
            }
        }

        public int AvailableMinutes
        {
            get
            {
                var talkMinutes = Talks.Sum(x => x.Minutes);
                var availableTime = TotalMinutes - talkMinutes;
                return availableTime;
            }
        }

        public bool IsFull
        {
            get
            {
                if (AvailableMinutes > 0)
                    return false;

                return true;
            }
        }

        public void Allocate(Talk talk)
        {
            var availableTimeSpan = TimeSpan.FromMinutes(AvailableMinutes);

            var startTime = EndTime - availableTimeSpan;

            talk.StartTime = startTime;

            Talks.Add(talk);
        }

    }
}
