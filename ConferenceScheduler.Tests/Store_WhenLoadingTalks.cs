using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using System.Linq;
using ConferenceScheduler.Common.Store;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class Store_WhenLoadingTalks
    {
        [TestMethod]
        public void ShouldHaveLoadedTalks()
        {
            var talks = LoadTalks.LoadFile("../../SampleData/Talks.txt");
            Assert.IsNotNull(talks);
        }

        [TestMethod]
        public void ShouldSortTalksByDurationDesc()
        {
            var talks = CreateFullDaySampleTalks();
            var sortedTalks = LoadTalks.Sort(talks);
            var first = sortedTalks.First();
            var last = sortedTalks.Last();
            Assert.IsTrue(first.Minutes > last.Minutes);
        }
        
        [TestMethod]
        public void ShouldConvertSingleLineToTitle()
        { 
            var line = "Writing Fast Tests Against Enterprise Rails 60min";
            var title = LoadTalks.GetTitle(line);
            Assert.AreEqual(title, "Writing Fast Tests Against Enterprise Rails");
        }

        [TestMethod]
        public void ShouldConvertSingleLineToMinutes()
        {
            var line = "Writing Fast Tests Against Enterprise Rails 60min";
            var minutes = LoadTalks.GetMinutes(line);
            Assert.AreEqual(minutes, 60);
        }

        [TestMethod]
        public void ShouldConvertSingleLineLightningToMinutes()
        {
            var line = "Rails for Python Developers lightning";
            var minutes = LoadTalks.GetMinutes(line);
            Assert.AreEqual(minutes, 5);
        }

        [TestMethod]
        public void ShouldConvertSingleLineToTalk()
        {
            var lines = new List<string> { "Writing Fast Tests Against Enterprise Rails 60min" };
            var talks = LoadTalks.ConvertText(lines);
            var talk = talks.First();
            Assert.AreEqual(talk.Title, "Writing Fast Tests Against Enterprise Rails");
        }

        private List<Talk> CreateFullDaySampleTalks()
        {
            var talks = new List<Talk>();
            for (var i = 0; i < 3; i++)
            {
                var talk = new Talk { Minutes = i * 10 };
                talks.Add(talk);
            }
            return talks;
        }

    }
}
