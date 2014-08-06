using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using ConferenceScheduler.Common.Store;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class ConferenceSchedule_WhenCreatingConferenceSchedule
    {
        [TestMethod]
        public void ShouldHaveTracks()
        {
            var conferenceSchedule = new ConferenceSchedule();
            Assert.IsNotNull(conferenceSchedule.Tracks);
        }



    }
}
