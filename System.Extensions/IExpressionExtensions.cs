using System.Linq.Expressions;

namespace System.Extensions
{
    public static class IExpressionExtensions
    {
        public static Expression<Func<T,T2>> Negate<T, T2>(this Expression<Func<T, T2>> expression)
        {
            return Expression.Lambda<Func<T, T2>>(Expression.Negate(expression));
        }
    }
}
