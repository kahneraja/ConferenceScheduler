using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceScheduler.Common
{
    public class Afternoon : Session
    {
        public Afternoon()
        {
            StartTime = new TimeSpan(13, 0, 0);
            EndTime = new TimeSpan(17, 0, 0);
            Talks = new List<Talk>();
        }

    }
}
