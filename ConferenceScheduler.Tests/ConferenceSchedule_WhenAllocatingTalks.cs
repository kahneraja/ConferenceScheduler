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
        public void CanFindSuitableTrackForShortTalk()
        {
            var conferenceSchedule = new ConferenceSchedule();
            var talks = new List<Talk>();
            talks.Add(new Talk{ Minutes = 1});
            conferenceSchedule.AllocateTalks(talks);
            Assert.IsTrue(conferenceSchedule.Tracks.Count > 0);
        }

        [TestMethod]
        public void ShouldCreateTwoTracks()
        {
            var conferenceSchedule = new ConferenceSchedule();

            var talks = CreateTwoDaysSampleTalks();

            conferenceSchedule.AllocateTalks(talks);

            Assert.AreEqual(conferenceSchedule.Tracks.Count, 2);
        }

        private List<Talk> CreateTwoDaysSampleTalks()
        {
            var talks = new List<Talk>();
            for (var i = 0; i < 14; i++)
            {
                var talk = new Talk { Minutes = 60 };
                talks.Add(talk);
            }
            return talks;
        }

    }
}
