using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using ConferenceScheduler.Common.Sessions;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class Session_WhenCreatingAfternoonSession
    {

        [TestMethod]
        public void ShouldHaveCorrectStartTime()
        {
            var session = new Afternoon();
            var time = new TimeSpan(13, 0, 0);
            Assert.AreEqual(session.StartTime, time);
        }

        [TestMethod]
        public void ShouldHaveCorrectEndTime()
        {
            var session = new Afternoon();
            var time = new TimeSpan(17, 0, 0);
            Assert.AreEqual(session.EndTime, time);
        }


        [TestMethod]
        public void ShouldHaveTalks()
        {
            var session = new Morning();
            Assert.IsNotNull(session.Talks);
        }

    }
}
