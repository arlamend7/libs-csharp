using System;
using System.Linq.Expressions;

namespace Linq.Fluent.Expressions.Base
{
    public interface ILinqFluentExpressionBuilder<T, TResult>
    {
        TResult Condition(Expression<Func<T, bool>> secondExpression);
        TResult IsOneOfConditions(Expression<Func<T, bool>> secondExpression, params Expression<Func<T, bool>>[] expressions);
        ILinqFluentExpressionBuilder<T, TResult> Not { get; }
    }
}
