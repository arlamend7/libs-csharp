using Linq.Fluent.Expressions.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Linq.Fluent.Expressions.Base
{
    public class ExpressionBuilderBase<T1, T2>
    {
        protected IQueryable<T1> Query { get; }
        protected bool Negation;

        protected Expression<Func<T1, T2>> FirstExpression { get; }

        public ExpressionBuilderBase(Expression<Func<T1, T2>> firstExpression, IQueryable<T1> query)
        {
            FirstExpression = firstExpression;
            Query = query;
        }

        protected Expression<Func<T1, bool>> Concat(Expression<Func<T2, bool>> SecondExpression)
        {
            MemberExpression? memberExpression = FirstExpression.Body as MemberExpression;

            if (memberExpression == null)
            {
                return Expression.Lambda<Func<T1, bool>>(SecondExpression.Body, SecondExpression.Parameters);
            }

            Expression<Func<T1, bool>> expression = Expression.Lambda<Func<T1, bool>>(SecondExpression.Body, FirstExpression.Parameters);
            ExpressionConcater rebinder = new ExpressionConcater(SecondExpression.Parameters[0], memberExpression);

            var customExpression = rebinder.Visit(expression.Body);

            return Expression.Lambda<Func<T1, bool>>(customExpression, expression.Parameters);
        }

        protected ExpressionBuilderBase<T1,T2> Negate()
        {
            Negation = true;
            return this;
        }
    }
}
