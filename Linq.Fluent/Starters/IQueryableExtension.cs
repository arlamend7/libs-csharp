using Linq.Fluent.Expressions.IExpressionBuilder;
using Linq.Fluent.Expressions.IExpressionBuilder.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Linq.Fluent.Expressions.Starters
{
    public static class IQueryableExtension
    {
        public static IExpressionBuilder<T1, T2> WhereParam<T1, T2>(this IQueryable<T1> query, Expression<Func<T1, T2>> expression)
        {
            return new ExpressionBuilder<T1, T2>(expression, query);
        }
        public static IExpressionBuilder<T1, T1> WhereQuery<T1>(this IQueryable<T1> query)
        {
            return new ExpressionBuilder<T1, T1>(x => x, query);
        }
    }
}
