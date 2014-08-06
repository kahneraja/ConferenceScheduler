using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using ConferenceScheduler.Common.Sessions;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class Session_WhenCreatingMorningSession
    {

        [TestMethod]
        public void ShouldHaveCorrectStartTime()
        {
            var session = new Morning();
            var time = new TimeSpan(9, 0, 0);
            Assert.AreEqual(session.StartTime, time);
        }

        [TestMethod]
        public void ShouldHaveCorrectEndTime()
        {
            var session = new Morning();
            var time = new TimeSpan(12, 0, 0);
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
