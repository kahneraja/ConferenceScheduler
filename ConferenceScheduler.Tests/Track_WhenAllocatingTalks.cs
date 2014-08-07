using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class Track_WhenAllocatingTalks
    {
        [TestMethod]
        public void ShouldNotBeFull()
        {
            var track = new Track();
            
            Assert.IsFalse(track.IsFull);
        }

        [TestMethod]
        public void ShouldAddShortTalkToMorningSession()
        {
            var track = new Track();

            var talk = new Talk { Title = "Sample Talk 123", Minutes = 1 };
            track.Allocate(talk);

            Assert.AreEqual(track.Morning.Talks.First().Title, "Sample Talk 123");
        }

        [TestMethod]
        public void ShouldNotAddExtraLongTalkToMorningSession()
        {
            var track = new Track();

            var talk = new Talk { Title = "Sample Talk 123", Minutes = 60 * 3 + 1 };
            track.Allocate(talk);

            Assert.AreEqual(track.Afternoon.Talks.First().Title, "Sample Talk 123");
        }

        [TestMethod]
        public void ShouldJustFillMorningSession()
        {
            var track = new Track();

            var talk1 = new Talk { Title = "Sample Talk 1", Minutes = 179 };
            track.Allocate(talk1);

            var talk2 = new Talk { Title = "Sample Talk 2", Minutes = 1 };
            track.Allocate(talk1);

            Assert.AreEqual(1, track.Morning.Talks.Count);
        }

        [TestMethod]
        public void ShouldNotGoOvertime()
        {
            var track = new Track();

            var talk1 = new Talk { Title = "Sample Talk 1", Minutes = 179 };
            track.Allocate(talk1);

            var talk2 = new Talk { Title = "Sample Talk 2", Minutes = 2 };
            track.Allocate(talk1);

            Assert.AreEqual(1, track.Morning.Talks.Count);
        }


        [TestMethod]
        public void ShouldFillTrack()
        {
            var track = new Track();
            var talks = CreateFullDaySampleTalks();

            foreach (var talk in talks)
            {
                track.Allocate(talk);
            }

            var isFull = track.IsFull;
            Assert.AreEqual(true, isFull);
        }

        [TestMethod]
        public void ShouldBringNetworkingForwardToFourPM()
        {
            var track = new Track();

            var talk = new Talk { Title = "Sample Talk 123", Minutes = 1 };
            track.Allocate(talk);

            var networkingTime = track.NetworkingTime;
            var fourPM = new TimeSpan(16, 0, 0);

            Assert.AreEqual(networkingTime, fourPM);
        }

        private List<Talk> CreateFullDaySampleTalks()
        {
            var talks = new List<Talk>();
            for (var i = 0; i < 7; i++) {
                var talk = new Talk { Minutes = 60 };
                talks.Add(talk);
            }
            return talks;
        }
    }
}
