using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Reto5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestDictionaryPlus
    {
        [TestMethod]
        public void TestDictionaryPlusGetOne()
        {
            DictionaryPlus<int, string> dictionary =
                new DictionaryPlus<int, string>() { { 0, "zero" }, { 1, "one" }, { 2, "two" } };
            CollectionAssert.AreEqual(new List<string>() { "one" }, dictionary[1].ToList());
        }

        [TestMethod]
        public void TestDictionaryPlusGetTwo()
        {
            DictionaryPlus<int, string> dictionary =
                new DictionaryPlus<int, string>() { { 0, "zero" }, { 1, "one" }, { 2, "two" }, { 3, "three" } };
            CollectionAssert.AreEqual(new List<string>() { "two", "zero" }, dictionary[2, 0].ToList());
        }

        [TestMethod]
        public void TestDictionaryPlusGetTen()
        {
            DictionaryPlus<char, int> dictionary = new DictionaryPlus<char, int>();
            for (int i = 0; i < 20; i++)
            {
                dictionary.Add((char)('a' + i), i);
            }
            CollectionAssert.AreEqual(
                new List<int>() { 6, 0, 2, 12, 4, 5, 7, 11, 1, 14 },
                dictionary['g', 'a', 'c', 'm', 'e', 'f', 'h', 'l', 'b', 'o'].ToList());
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void TestDictionaryPlusGetInvalidKey()
        {
            DictionaryPlus<char, int> dictionary = new DictionaryPlus<char, int>();
            for (int i = 0; i < 13; i++)
            {
                dictionary.Add((char)('a' + i), i);
            }
            CollectionAssert.AreEqual(
                new List<int>() { 6, 0, 2, 12, 4, 5, 7, 11, 1, 14 },
                dictionary['g', 'a', 'c', 'm', 'e', 'f', 'h', 'l', 'b', 'o'].ToList());
        }
    }
}
