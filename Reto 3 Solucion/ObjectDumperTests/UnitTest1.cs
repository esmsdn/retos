using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectDumper;

namespace ObjectDumperTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Dumping_Null_Returns_Empty_Collection()
        {
            var dumper = new ObjectDumper<Test1Class>();
            var result = dumper.Dump(null);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void Only_Properties_With_Getter_Are_Dump()
        {
            var dumper = new ObjectDumper<Test1Class>();
            var desc = dumper.Dump(new Test1Class());
            Assert.AreEqual(1, desc.Count());
        }

        [TestMethod]
        public void Dump_Is_Sorted_By_Property_Name()
        {
            var dumper = new ObjectDumper<Test3Class>();
            var desc = dumper.Dump(new Test3Class()).Select(kvp => kvp.Key);

            CollectionAssert.AreEqual(desc.ToList(), new List<string>() { "AProperty", "BProperty", "ZProperty" });
        }

        [TestMethod]
        public void Default_Template_Is_To_String()
        {

            var dumper = new ObjectDumper<Test2Class>();
            var desc = dumper.Dump(new Test2Class());
            Assert.AreEqual(new Test2Class.Test2Inner().ToString(), desc.First().Value);

        }

        [TestMethod]
        public void Template_For_Simple_Type_Is_Applied()
        {
            const string IS_42 = "Answer to everything";
            const string IS_NOT_42 = "not meaningful";

            var dumper = new ObjectDumper<Test2Class.Test2Inner>();
            dumper.AddTemplateFor(o => o.Value, v => v == 42 ? IS_42 : IS_NOT_42);

            var data = new Test2Class.Test2Inner()
            {
                Name = "Some name",
                Value = 42
            };

            var desc = dumper.Dump(data);
            Assert.IsTrue(desc.Any(kvp => kvp.Key == "Value" && kvp.Value == IS_42));
        }

        [TestMethod]
        public void Template_For_Complex_Type_Is_Applied()
        {
            var ufo = new Ufo()
            {
                Name = "Conqueror III",
                Speed = 10,
                Origin = new Planet()
                {
                    Name = "Alpha Centauri 3",
                    DaysPerYear = 452
                }
            };
            var dumper = new ObjectDumper<Ufo>();
            dumper.AddTemplateFor(u => u.Origin, o => string.Format("Planet: {0}", o.Name));
            var desc = dumper.Dump(ufo);
            Assert.IsTrue(desc.Any(kvp =>
                kvp.Key == "Origin" && kvp.Value == string.Format("Planet: {0}", ufo.Origin.Name)));
        }

        [TestMethod]
        public void Not_Listed_Property_Is_Not_Invoked()
        {
            var dumper = new ObjectDumper<CrashedUfo>();
            var crashed = new CrashedUfo()
            {
                Name = "Conqueror III",
                Speed = 10,
                Origin = new Planet()
                {
                    Name = "Alpha Centauri 3",
                    DaysPerYear = 452
                }
            };

            var desc = dumper.Dump(crashed);
            var twoPropertiesList = desc.Take(2).ToList();
            // No exception at this point because ZLastProperty is *never* invoked
            Assert.AreEqual(2, twoPropertiesList.Count);
        }
    }
}
