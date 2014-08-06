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
            var afternoon = new Afternoon();
            var time = new TimeSpan(13, 0, 0);
            Assert.AreEqual(afternoon.StartTime, time);
        }

        [TestMethod]
        public void ShouldHaveCorrectEndTime()
        {
            var afternoon = new Afternoon();
            var time = new TimeSpan(17, 0, 0);
            Assert.AreEqual(afternoon.EndTime, time);
        }


        [TestMethod]
        public void ShouldHaveTalks()
        {
            var session = new Afternoon();
            Assert.IsNotNull(session.Talks);
        }

        [TestMethod]
        public void ShouldHaveCorrectTotalMinutes()
        {
            var afternoon = new Afternoon();
            var minutes = afternoon.TotalMinutes;
            Assert.AreEqual(minutes, 60 * 4);
        }

        [TestMethod]
        public void ShouldHaveAvailableMinutes()
        {
            var afternoon = new Afternoon();
            var minutes = afternoon.AvailableMinutes;
            Assert.AreEqual(minutes, 60 * 4);
        }

        [TestMethod]
        public void ShouldNotBeFull()
        {
            var afternoon = new Afternoon();
            var isFull = afternoon.IsFull;
            Assert.AreEqual(false, isFull);
        }
    }
}
