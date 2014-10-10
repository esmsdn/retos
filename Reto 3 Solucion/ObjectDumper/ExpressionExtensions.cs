using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumper
{
    static class ExpressionExtensions
    {
        public static PropertyInfo AsPropertyInfo<T, TR>(this Expression<Func<T, TR>> expr)
        {
            var memberExp = expr.Body as MemberExpression;
            if (memberExp == null)
            {
                return null;
            }

            return memberExp.Member as PropertyInfo;
        }
    }
}
