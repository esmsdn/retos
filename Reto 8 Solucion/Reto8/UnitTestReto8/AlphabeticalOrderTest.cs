using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reto8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UnitTestReto8
{
    [TestClass]
    public class AlphabeticalOrderTest
    {
        [TestMethod]
        public void ShouldReturnEnumerableExceptForOneElement()
        {
            IEnumerable<string> strs0 = AlphabeticalOrder.GetShortestConcatString();
            string str1 = AlphabeticalOrder.GetShortestConcatString("");
            IEnumerable<string> strs2 = AlphabeticalOrder.GetShortestConcatString("", "");
        }


        [TestMethod]
        public void ShouldBeAbleToReceiveStringsOrEnumerable()
        {
            IEnumerable<string> it = new string[] { "hello", "bye" };
            Assert.AreEqual(2, AlphabeticalOrder.GetShortestConcatString(it).Count());

            Assert.AreEqual(2, AlphabeticalOrder.GetShortestConcatString("hello", "bye").Count());
        }

        [TestMethod]
        public void ShouldReturnOneElementPerInput()
        {
            Assert.AreEqual(0, AlphabeticalOrder.GetShortestConcatString().Count());

            var strs = new string[] { "", "", "", "", "", "", "", "", "", "" };
            Assert.AreEqual(10, AlphabeticalOrder.GetShortestConcatString(strs).Count());
        }

        [TestMethod]
        public void ShouldThrowExceptionIfAnyInputParamIsNull()
        {
            AssertArgumentNullException(() =>
            {
                AlphabeticalOrder.GetShortestConcatString((string)null);
            });
            AssertArgumentNullException(() =>
            {
                AlphabeticalOrder.GetShortestConcatString((IEnumerable<string>)null);
            });
            AssertArgumentNullException(() =>
            {
                AlphabeticalOrder.GetShortestConcatString((string[])null);
            });
            AssertArgumentNullException(() =>
            {
                AlphabeticalOrder.GetShortestConcatString("hello", null, "bye");
            });
        }

        [TestMethod]
        public void ShouldReturnSameStringWhenJustOneElement()
        {
            Assert.AreEqual("a", AlphabeticalOrder.GetShortestConcatString("a"));
            Assert.AreEqual("hello", AlphabeticalOrder.GetShortestConcatString("hello"));
        }


        [TestMethod]
        public void ShouldReturnAlphabeticalConcatString()
        {
            Assert.AreEqual("ab", AlphabeticalOrder.GetShortestConcatString("a b"));
            Assert.AreEqual("ab", AlphabeticalOrder.GetShortestConcatString("b a"));
            Assert.AreEqual("aab", AlphabeticalOrder.GetShortestConcatString("ab a"));

            var strs = new string[] { "a b", "b a", "banana apple coconut" };
            var expected = new string[] { "ab", "ab", "applebananacoconut" };
            CollectionAssert.AreEqual(expected, AlphabeticalOrder.GetShortestConcatString(strs).ToList());
        }

        [TestMethod]
        public void ShouldReturnHarderCases()
        {
            var table = new string[][] {
                 new string[] { "rgh woqg dmabatgbt qrvpcrx eluunoi sy w wnthqxgkg aimallazuc", "zOLuytilqRYh5scqwNk51l34sp9HbyHiRY3d8PvqWbI=", "G+vsRunRFDkm15fbpIKDkGnuM2cirbHjfn4DALPWUqg=" },
                 new string[] { "jg j uj ujnzdng nzdng nzdn e g ujnzdngj", "V191oJHcPL4FU+6ZCfTCdXUo69dI/V/TD0SkAl+IE4E=", "mXCd/wctbYe/pft4RWZMSbDXUBiPd5vA1py1B0G/NnQ=" },
                 new string[] { "jibw ji jp bw jibw", "fycg5r/sN/amHmWrpJeP0U9o71vSXQxoq2inaPulHqM=", "qQww2SnmJD0KOkWf7pFwfALcEFrXDo8MRKprVAPEHJo=" },
                 new string[] { "nl jtdmdxu ux nlmnyzdxu mnyz jtdm nlmnyz dxu uxdxu", "FOEIzRicYE2j/VuvoZZwRPnrLGxuEDkl2UV/DP0tM2I=", "/N7WQqzv6Opn5ZQzDI/NTYHCJ9xzIpq3gYwmHajKZ78=" },
                 new string[] { "dcn csmzj krnc vkcoume wvpva yqoexwujwp v cxepgptf xb", "m2uqRWP+pVdVralXFbaNXA+6UHiItbn6JTmfUw5C/DU=", "s2LhLnzUCfoTF4LLmk2rLZgEb3bevMvxO+2ykKRNG6w=" },
                 new string[] { "ksdzsjz bbio ja mvvyxzkmq zgdvxolmt xgvwdbfqzn rhubnqtaad qa eeb", "BC7IcPW2icWrZQU1Obx3LvJeYrZj6OneiOXhMTt2Oc8=", "BC7IcPW2icWrZQU1Obx3LvJeYrZj6OneiOXhMTt2Oc8=" },
                 new string[] { "iccrmcrm mwp sil iccrmcrm ic odo iccrm crm odocrm", "0utdQ1EV0HeN7matisJOP762yBjsNHQzQlEPzprtrRY=", "BrjOUX0IgWngKb9JzXrnz6WSxf2u4z1YavlsYjUlQTY=" },
                 new string[] { "o zt da wv brorejctww fu phnej ynrdkylwys ekggrmehcl", "jcp5zeZrmjznNMBMk8UBnvPDIl7uJhiJGnEOrxrvvKk=", "jcp5zeZrmjznNMBMk8UBnvPDIl7uJhiJGnEOrxrvvKk="},
                 new string[] {"a ab", "OHYOq7Zm6OYe5iihfECQzFByjglf8kIYEZ1RvSJHU2M=", "OHYOq7Zm6OYe5iihfECQzFByjglf8kIYEZ1RvSJHU2M=" },
                 new string[] {"b ba", "Mk6NVxav5HdRGP4SJW/T1IjM5XXjdc5vjrFstLW7tdM=", "7N2XQFx5tAjud5ECnQXStXiT2bBqEoJTHg33KdrvzvU=" }
            };

            var someFailure = false;
            foreach (var elm in table)
            {
                var output = OnewayFunction(AlphabeticalOrder.GetShortestConcatString(elm[0]));
                var msg = "CORRECT. Result por {0} is correct: {1}";
                if (output != elm[2])
                {
                    someFailure = true;
                    msg = output == elm[1] ?
                         "ALMOST. Result por {0} is almost correct: {1}. You're very close but a word which appears before yours in a dictionary exists"
                        : "INCORRECT. Result por {0} is incorect: {1}";
                }
                Console.WriteLine(string.Format(msg, elm[0], output));
            }
            if (someFailure)
            {
                Assert.Fail("There is at least one failing test");
            }
        }

        private void AssertArgumentNullException(Action action)
        {
            try
            {
                action();
                Assert.Fail("should throw ArgumentNullException");
            }
            catch (ArgumentNullException)
            {
            }
        }

        private string OnewayFunction(string input)
        {
            return Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }
}
