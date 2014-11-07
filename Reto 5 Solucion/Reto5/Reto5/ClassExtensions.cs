using System;
using System.Runtime.CompilerServices;

namespace Reto5
{
    public static class ClassExtensions
    {
        public static T NotNull<T>(this T @this, string paramName = null, [CallerMemberName] string callerName = null)
            where T : class
        {
            if (@this == null)
            {
                throw new ArgumentNullException(paramName, string.Format("{0} was called with null parameter", callerName));
            }

            return @this;
        }
    }
}
