using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Reto7;
using System.Diagnostics;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private string trendingShowsJson;
        private string comedyShowsJson;
        private string otherShowsJson;

        [TestInitialize]
        public void SetUp()
        {
            using (var reader = new StreamReader("AllShows.json"))
            {
                trendingShowsJson = reader.ReadToEnd();
            }

            using (var reader = new StreamReader("ComedyShows.json"))
            {
                comedyShowsJson = reader.ReadToEnd();
            }

            using (var reader = new StreamReader("NoComedyShows.json"))
            {
                otherShowsJson = reader.ReadToEnd();
            }
        }

        [TestMethod]
        public void TestSplitShowsByComedyGenre()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = JsonSplitter.SplitShowsByGenre(trendingShowsJson, "Comedy");

            stopwatch.Stop();
            Console.WriteLine(string.Format("Millisecs = {0}, Ticks = {1}", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks));

            Assert.AreEqual(comedyShowsJson, result.Item1);
            Assert.AreEqual(otherShowsJson, result.Item2);
        }
    }
}
