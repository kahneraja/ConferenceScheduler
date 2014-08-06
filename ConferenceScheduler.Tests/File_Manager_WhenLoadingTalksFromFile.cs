using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceScheduler.Common;
using System.Collections.Generic;
using System.Linq;
using ConferenceScheduler.Common.FileManager;

namespace ConferenceScheduler.Tests
{
    [TestClass]
    public class File_Manager_WhenLoadingTalksFromFile
    {
        [TestMethod]
        public void ShouldHaveSortedTalks()
        {
            var talks = LoadTalks.LoadFile("../../SampleData/Talks.txt");
            Assert.IsTrue(talks.First().Minutes > talks.Last().Minutes);
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

    }
}
