using Linq.Fluent.Expressions.Base;
using Linq.Fluent.Expressions.IExpressionBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Extensions;
using System.Linq;
using System.Linq.Expressions;

namespace Linq.Fluent.Expressions.IExpressionBuilder
{
    public class ExpressionConditionsBuilder<T1, T2> : ExpressionBuilderBase<T1, T2>, IExpressionConditionsBuilder<T1, T2>
    {
        public ExpressionConditionsBuilder(Expression<Func<T1, T2>> firstExpression, IQueryable<T1> query) : base(firstExpression, query)
        {
            Expressions = new List<Expression<Func<T1, bool>>>();
        }

        private List<Expression<Func<T1, bool>>> Expressions { get; set; }

        public IQueryable<T1> Create()
        {
            Expression<Func<T1, bool>> expressionResult = Expressions.First();
            BinaryExpression binaryExpression;
            foreach (Expression<Func<T1, bool>> expression in Expressions.Skip(1))
            {
                binaryExpression = Expression.AndAlso(expressionResult.Body, expression.Body);
                expressionResult = Expression.Lambda<Func<T1, bool>>(binaryExpression, expressionResult.Parameters[0]);
            }

            return Query.Where(expressionResult);
        }

        public IExpressionConditionsBuilder<T1, T2> Condition(Expression<Func<T2, bool>> secondExpression)
        {
            Add(Concat(secondExpression));
            return this;
        }

        public IExpressionConditionsBuilder<T1, T2> IsOneOfConditions(Expression<Func<T2, bool>> secondExpression, params Expression<Func<T2, bool>>[] expressions)
        {
            Expression<Func<T1, bool>> expressionResult = Concat(secondExpression);
            BinaryExpression binaryExpression;
            foreach (Expression<Func<T2, bool>> expression in expressions)
            {
                binaryExpression = Expression.OrElse(expressionResult.Body, Concat(expression).Body);
                expressionResult = Expression.Lambda<Func<T1, bool>>(binaryExpression, expressionResult.Parameters[0]);
            }

            Add(expressionResult);
            return this;
        }
        private void Add(Expression<Func<T1, bool>> expression)
        {
            if (Negation)
            {
                Negation = false;
                Expressions.Add(expression.Not());
            }
            Expressions.Add(expression);
        }

        public ILinqFluentExpressionBuilder<T2, IExpressionConditionsBuilder<T1, T2>> Not => (ILinqFluentExpressionBuilder<T2, IExpressionConditionsBuilder<T1, T2>>)Negate();

    }
}