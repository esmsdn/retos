using System;

namespace Reto5
{
    public static class StringExtensions
    {
        public static unsafe void ToUpperNoCopy(this string @this)
        {
            if (@this == null)
            {
                throw new ArgumentNullException("@this");
            }

            fixed (char* chars = @this)
            {
                for (char* @char = chars; *@char != 0; @char++)
                {
                    *@char = char.ToUpper(*@char);
                }
            }
        }
    }
}
