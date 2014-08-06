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
            var morning = new Morning();
            var time = new TimeSpan(9, 0, 0);
            Assert.AreEqual(morning.StartTime, time);
        }

        [TestMethod]
        public void ShouldHaveCorrectEndTime()
        {
            var morning = new Morning();
            var time = new TimeSpan(12, 0, 0);
            Assert.AreEqual(morning.EndTime, time);
        }


        [TestMethod]
        public void ShouldHaveTalks()
        {
            var morning = new Morning();
            Assert.IsNotNull(morning.Talks);
        }

        [TestMethod]
        public void ShouldHaveCorrectTotalMinutes()
        {
            var morning = new Morning();
            var minutes = morning.TotalMinutes;
            Assert.AreEqual(minutes, 60 * 3);
        }

        [TestMethod]
        public void ShouldHaveAvailableMinutes()
        {
            var morning = new Morning();
            var minutes = morning.AvailableMinutes;
            Assert.AreEqual(minutes, 60 * 3);
        }

        [TestMethod]
        public void ShouldNotBeFull()
        {
            var morning = new Morning();
            var isFull = morning.IsFull;
            Assert.AreEqual(false, isFull);
        }

        [TestMethod]
        public void ShouldFillSession()
        {
            var morning = new Morning();
            morning.Allocate(new Talk { Minutes = morning.AvailableMinutes });

            var isFull = morning.IsFull;
            Assert.AreEqual(true, isFull);
        }

    }
}
