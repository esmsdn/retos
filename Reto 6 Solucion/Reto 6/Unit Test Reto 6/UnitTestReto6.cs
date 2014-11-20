using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reto_6;

namespace Unit_Test_Reto_6
{
    [TestClass]
    public class UnitTestReto6
    {
        public class DummyClass
        {
            public string Name { get; set; }
            public byte[] Value { get; set; }

            public override string ToString()
            {
                return string.Format("Dummy {0}", Name);
            }
        }

        [TestMethod]
        public void TestCacheNoItemsAccessedBeforeGC()
        {
            Cache cache = new Cache();
            for (int i = 0; i < 5; i++)
            {
                cache.Add(i, i.ToString());
            }

            Assert.AreEqual(5, cache.Count);
            Assert.AreEqual(5, cache.ActiveCount);
            Assert.AreEqual("0", cache[0]);
            Assert.AreEqual("1", cache[1]);
            Assert.AreEqual("2", cache[2]);
            Assert.AreEqual("3", cache[3]);
            Assert.AreEqual("4", cache[4]);

            GC.Collect();

            Assert.AreEqual(5, cache.Count);
            Assert.AreEqual(0, cache.ActiveCount);
            Assert.IsNull(cache[0]);
            Assert.IsNull(cache[1]);
            Assert.IsNull(cache[2]);
            Assert.IsNull(cache[3]);
            Assert.IsNull(cache[4]);
        }

        [TestMethod]
        public void TestCacheSomeItemsAccessedJustBeforeGC()
        {
            Cache cache = new Cache();
            for (int i = 0; i < 5; i++)
            {
                cache.Add(i, new byte[1024]);
            }

            var value1 = cache[1];
            var value3 = cache[3];

            Assert.AreEqual(5, cache.Count);
            Assert.AreEqual(5, cache.ActiveCount);
            Assert.IsNotNull(cache[0]);
            Assert.IsNotNull(cache[1]);
            Assert.IsNotNull(cache[2]);
            Assert.IsNotNull(cache[3]);
            Assert.IsNotNull(cache[4]);

            GC.Collect();

            Assert.AreEqual(5, cache.Count);
            Assert.AreEqual(2, cache.ActiveCount);
            Assert.IsNull(cache[0]);
            Assert.IsNotNull(cache[1]);
            Assert.IsNull(cache[2]);
            Assert.IsNotNull(cache[3]);
            Assert.IsNull(cache[4]);
        }

        [TestMethod]
        public void TestCacheAllItemsAccessedJustBeforeGC()
        {
            Cache cache = new Cache();
            for (int i = 0; i < 4; i++)
            {
                cache.Add(i, new DummyClass { Name = i.ToString(), Value = new byte[1024] });
            }

            var value0 = cache[0];
            var value1 = cache[1];
            var value2 = cache[2];
            var value3 = cache[3];

            Assert.AreEqual(4, cache.Count);
            Assert.AreEqual(4, cache.ActiveCount);
            Assert.AreEqual("0", (cache[0] as DummyClass).Name);
            Assert.AreEqual("1", (cache[1] as DummyClass).Name);
            Assert.AreEqual("2", (cache[2] as DummyClass).Name);
            Assert.AreEqual("3", (cache[3] as DummyClass).Name);

            GC.Collect();

            Assert.AreEqual(4, cache.Count);
            Assert.AreEqual(4, cache.ActiveCount);
            Assert.AreEqual("0", (cache[0] as DummyClass).Name);
            Assert.AreEqual("1", (cache[1] as DummyClass).Name);
            Assert.AreEqual("2", (cache[2] as DummyClass).Name);
            Assert.AreEqual("3", (cache[3] as DummyClass).Name);

        }
    }
}
