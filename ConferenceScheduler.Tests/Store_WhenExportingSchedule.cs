using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using System.Linq;
using ConferenceScheduler.Common.Store;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class Store_WhenExportingSchedule
    {
        [TestMethod]
        public void ShouldLoadTalksAndExportSchedule()
        {
            var conferenceSchedule = new ConferenceSchedule();

            var talks = LoadTalks.LoadFile("../../SampleData/Talks.txt");

            conferenceSchedule.AllocateTalks(talks);

            var lines = SaveSchedule.ExportFile(conferenceSchedule, "../../SampleData/EndToEndSchedule.txt");

            Assert.IsNotNull(lines);
        }
    }
}
