using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class ConferenceSchedule_WhenAllocatingTalks
    {
        [TestMethod]
        public void ShouldHaveTracks()
        {
            var conferenceSchedule = new ConferenceSchedule();
            var talks = new List<Talk>();
            conferenceSchedule.AllocateTalks(talks);
            Assert.IsTrue(conferenceSchedule.Tracks.Count > 0);
        }

    }
}
