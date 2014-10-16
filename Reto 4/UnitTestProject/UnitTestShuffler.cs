using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Shuffler;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestShuffler
    {
        private List<int> GenerateTestList(int count)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }
            return list;
        }

        [TestMethod]
        public void TestShuffle3Items()
        {
            List<int> original = new List<int>() { 0, 1, 2 };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> shuffled = original.Shuffle();

            stopwatch.Stop();
            Console.WriteLine(string.Format("Shuffling 3 items took {0} milliseconds or {1} ticks", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks));

            CollectionAssert.AllItemsAreUnique(shuffled);
            for (int index = 0; index < shuffled.Count; index++)
            {
                Assert.AreNotEqual(original[index], shuffled[index]);
            }
        }

        [TestMethod]
        public void TestShuffle10000Items()
        {
            List<int> original = GenerateTestList(10000);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> shuffled = original.Shuffle();

            stopwatch.Stop();
            Console.WriteLine(string.Format("Shuffling 10,000 items took {0} milliseconds or {1} ticks", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks));

            CollectionAssert.AllItemsAreUnique(shuffled);
            for (int index = 0; index < shuffled.Count; index++)
            {
                Assert.AreNotEqual(original[index], shuffled[index]);
            }
        }

        [TestMethod]
        public void TestShuffle100000Items()
        {
            List<int> original = GenerateTestList(100000);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> shuffled = original.Shuffle();

            stopwatch.Stop();
            Console.WriteLine(string.Format("Shuffling 100,000 items took {0} milliseconds or {1} ticks", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks));

            CollectionAssert.AllItemsAreUnique(shuffled);
            for (int index = 0; index < shuffled.Count; index++)
            {
                Assert.AreNotEqual(original[index], shuffled[index]);
            }
        }

        [TestMethod]
        public void TestShuffle10000000Items()
        {
            List<int> original = GenerateTestList(10000000);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> shuffled = original.Shuffle();

            stopwatch.Stop();
            Console.WriteLine(string.Format("Shuffling 10,000,000 items took {0} milliseconds or {1} ticks", stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks));

            CollectionAssert.AllItemsAreUnique(shuffled);
            for (int index = 0; index < shuffled.Count; index++)
            {
                Assert.AreNotEqual(original[index], shuffled[index]);
            }
        }
    }
}
