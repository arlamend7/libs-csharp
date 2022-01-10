using System;
using System.Linq.Expressions;

namespace Libs.System.Extensions
{
    public static class IExpressionExtensions
    {
        public static Expression<Func<T,T2>> Not<T, T2>(this Expression<Func<T, T2>> expression)
        {
            return Expression.Lambda<Func<T, T2>>(Expression.Not(expression.Body), expression.Parameters);
        }
    }
}
