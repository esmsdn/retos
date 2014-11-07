using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Reto5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestNotNull
    {
        private class Dummy
        {
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNotNullWithNullString()
        {
            try
            {
                string name = null;
                name.NotNull("name");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("TestNotNullWithNullString was called with null parameter\r\nParameter name: name", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void TestNotNullWithString()
        {
            string name = "AlejaCMa";
            Assert.AreEqual(name, name.NotNull());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestNotNullWithNullDummyObject()
        {
            try
            {
                Dummy dummy = null;
                dummy.NotNull("dummy");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("TestNotNullWithNullDummyObject was called with null parameter\r\nParameter name: dummy", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void TestNotNullWithDummyObject()
        {
            Dummy dummy = new Dummy();
            Assert.AreEqual(dummy, dummy.NotNull());
        }
    }
}
