using Linq.Fluent.Expressions.Base;
using Linq.Fluent.Expressions.IExpressionBuilder.Interfaces;
using System;
using System.Extensions;
using System.Linq;
using System.Linq.Expressions;

namespace Linq.Fluent.Expressions.IExpressionBuilder
{
    public class ExpressionBuilder<T1, T2> : ExpressionBuilderBase<T1, T2>, IExpressionBuilder<T1, T2>
    {
        public IExpressionConditionsBuilder<T1, T2> Conditions { get; set; }

        public ExpressionBuilder(Expression<Func<T1, T2>> firstExpression, IQueryable<T1> query) : base(firstExpression, query)
        {
            Conditions = new ExpressionConditionsBuilder<T1, T2>(firstExpression, query);
        }

        public IQueryable<T1> Condition(Expression<Func<T2, bool>> secondExpression)
        {
            return ReturnValue(Concat(secondExpression));
        }

        public IQueryable<T1> IsOneOfConditions(Expression<Func<T2, bool>> secondExpression, params Expression<Func<T2, bool>>[] expressions)
        {
            Expression<Func<T1, bool>> expressionResult = Concat(secondExpression);
            BinaryExpression binaryExpression;
            foreach (Expression<Func<T2, bool>> expression in expressions)
            {
                binaryExpression = Expression.OrElse(expressionResult.Body, Concat(expression).Body);
                expressionResult = Expression.Lambda<Func<T1, bool>>(binaryExpression, expressionResult.Parameters[0]);
            }

            return ReturnValue(expressionResult);
        }
        private IQueryable<T1> ReturnValue(Expression<Func<T1, bool>> expressionResult)
        {
            if (Negation)
            {
                Negation = false;
                return Query.Where(expressionResult.Not());
            }
            return Query.Where(expressionResult);
        }

        public ILinqFluentExpressionBuilder<T2, IQueryable<T1>> Not => (ILinqFluentExpressionBuilder<T2, IQueryable<T1>>)Negate();
    }
}
