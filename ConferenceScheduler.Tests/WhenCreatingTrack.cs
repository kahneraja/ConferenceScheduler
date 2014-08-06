using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class WhenCreatingTrack
    {
        [TestMethod]
        public void ShouldHaveMorningSessions()
        {
            var track = new Track();
            Assert.IsNull(track.MorningSession);
        }
        [TestMethod]
        public void ShouldHaveAfternoonSessions()
        {
            var track = new Track();
            Assert.IsNull(track.AfternoonSession);
        }

    }
}
