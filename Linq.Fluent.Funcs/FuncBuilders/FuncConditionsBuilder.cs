using Linq.Fluent.Funcs.Base;
using Linq.Fluent.Funcs.FuncBuilders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Fluent.Funcs.FuncBuilders
{
    internal class FuncConditionsBuilder<T1, T2> : FuncBuilderBase<T1, T2>, IFuncConditionsBuilder<T1, T2>
    {
        private List<Func<T1, bool>> Expressions { get; set; }
        public FuncConditionsBuilder(Func<T1, T2> firstExpression, IEnumerable<T1> query) : base(firstExpression, query)
        {
            Expressions = new List<Func<T1, bool>>();
        }

        public IEnumerable<T1> Create()
        {
            Func<T1, bool> expressionResult = Expressions.First();
            foreach (Func<T1, bool> expression in Expressions.Skip(1))
            {
                expressionResult = x => expressionResult.Invoke(x) && expression.Invoke(x);
            }
            return Query.Where(expressionResult);
        }

        public IFuncConditionsBuilder<T1, T2> Condition(Func<T2, bool> secondExpression)
        {
            Add(Concat(secondExpression));
            return this;
        }

        public IFuncConditionsBuilder<T1, T2> IsOneOfConditions(Func<T2, bool> secondExpression, params Func<T2, bool>[] expressions)
        {
            Func<T1, bool> expressionResult = Concat(secondExpression);
            foreach (Func<T2, bool> expression in expressions)
            {
                expressionResult = x => expressionResult.Invoke(x) && Concat(expression).Invoke(x);
            }

            Add(expressionResult);
            return this;
        }
        private void Add(Func<T1, bool> expression)
        {
            if (Negation)
            {
                Expressions.Add(x => !expression.Invoke(x));
            }
            Expressions.Add(expression);
        }

        public ILinqFluentFuncBuilder<T2, IFuncConditionsBuilder<T1, T2>> Not => (ILinqFluentFuncBuilder<T2, IFuncConditionsBuilder<T1, T2>>)Negate();

    }
}