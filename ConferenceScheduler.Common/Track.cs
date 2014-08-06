using ConferenceScheduler.Common.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Common
{
    public class Track
    {
        public Morning Morning { get; set; }

        public Afternoon Afternoon { get; set; }

        public Track()
        {
            Morning = new Morning();
            Afternoon = new Afternoon();
        }

        public bool IsFull
        {
            get
            {
                if (Morning.IsFull && Afternoon.IsFull)
                    return true;

                return false;
            }
        }

    }
}
