using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class Track_WhenCreatingTrack
    {
        [TestMethod]
        public void ShouldHaveMorningSessions()
        {
            var track = new Track();
            Assert.IsNotNull(track.Morning);
        }
        [TestMethod]
        public void ShouldHaveAfternoonSessions()
        {
            var track = new Track();
            Assert.IsNotNull(track.Afternoon);
        }

    }
}
