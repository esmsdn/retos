using System;
using System.Collections.Generic;
using System.Linq;

namespace Reto8
{
    public class AlphabeticalOrder
    {
        private static IComparer<string> comparer = Comparer<string>.Create(
            (a, b) => (a + b).CompareTo(b + a));

        public static IEnumerable<string> GetShortestConcatString(params string[] input)
        {
            return GetShortestConcatString(input as IEnumerable<string>);
        }

        public static IEnumerable<string> GetShortestConcatString(IEnumerable<string> input)
        {

            if (input == null || input.Any(x => x == null))
            {
                throw new ArgumentNullException("input", "must not be null or contains null elements");
            }

            return input.Select(GetShortestConcatString);
        }

        public static string GetShortestConcatString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return string.Join("", input.Split().OrderBy(x => x, comparer));
        }
    }
}
