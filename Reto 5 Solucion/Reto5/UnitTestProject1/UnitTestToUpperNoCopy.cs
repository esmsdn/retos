using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Reto5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestToUpperNoCopy
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void TestToUpperNoCopyWithNullString()
        {
            string name = null;
            name.ToUpperNoCopy();
        }

        [TestMethod]
        public void TestToUpperNoCopyWithInmutableString()
        {
            string name = "tiene que funcionar con cualquier string";
            name.ToUpperNoCopy();
            Assert.AreEqual("TIENE QUE FUNCIONAR CON CUALQUIER STRING", name);
        }
    }
}
