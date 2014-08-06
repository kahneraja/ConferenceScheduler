using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class WhenCreatingConferenceSchedule
    {
        [TestMethod]
        public void ShouldHaveTracks()
        {
            var conferenceSchedule = new ConferenceSchedule();
            Assert.IsNotNull(conferenceSchedule.Tracks);
        }

    }
}
