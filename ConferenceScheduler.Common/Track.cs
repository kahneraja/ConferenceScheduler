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

        public bool IsFull
        {
            get
            {
                if (Morning.IsFull && Afternoon.IsFull)
                    return true;

                return false;
            }
        }

        public TimeSpan EarliestNetworkingTime { get { return new TimeSpan(16, 0, 0); } }

        public TimeSpan NetworkingTime
        {
            get
            {

                if (Afternoon.ClosingTime < EarliestNetworkingTime)
                    return EarliestNetworkingTime;

                return Afternoon.ClosingTime;
            }
        }

        public Track()
        {
            Morning = new Morning();
            Afternoon = new Afternoon();
        }



        public void Allocate(Talk talk)
        {
            if (Morning.CanFit(talk.Minutes))
                Morning.Allocate(talk);
            else if (Afternoon.CanFit(talk.Minutes))
                Afternoon.Allocate(talk);
        }

        internal bool HasAvailability(int minutes)
        {
            if (Morning.AvailableMinutes >= minutes || Afternoon.AvailableMinutes >= minutes)
                return true;

            return false;
        }


    }
}
