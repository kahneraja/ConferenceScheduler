using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceScheduler.Common.Sessions
{
    public class Morning : Session
    {
        public Morning()
        {
            StartTime = new TimeSpan(9, 0, 0);
            EndTime = new TimeSpan(12, 0, 0);
            Talks = new List<Talk>();
        }


    }

}
