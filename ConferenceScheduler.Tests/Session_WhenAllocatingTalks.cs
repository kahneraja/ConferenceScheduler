using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using ConferenceScheduler.Common.Sessions;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class Session_WhenAllocatingTalks
    {
        [TestMethod]
        public void ShouldHaveCorrectStartTime()
        {
            var morning = new Morning();
            var talk = new Talk { Minutes = 1 };
            morning.Allocate(talk);
            
            var startTime = new TimeSpan(9,0,0);
            Assert.AreEqual(talk.StartTime, startTime);
        }

        [TestMethod]
        public void ShouldFillSession()
        {
            var afternoon = new Afternoon();
            afternoon.Allocate(new Talk { Minutes = afternoon.AvailableMinutes });

            var isFull = afternoon.IsFull;
            Assert.AreEqual(true, isFull);
        }
    }
}
