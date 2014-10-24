using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuffler
{
    public static class ListExtensions
    {
        private static Random random = new Random();

        public static List<T> Shuffle<T>(this List<T> original)
        {
            T[] shuffled = original.ToArray();

            for (int index = shuffled.Length - 1; index > 0; index--)
            {
                int randomIndex = random.Next(index);

                T temp = shuffled[index];
                shuffled[index] = shuffled[randomIndex];
                shuffled[randomIndex] = temp;
            }

            return shuffled.ToList();
        }
    }
}



