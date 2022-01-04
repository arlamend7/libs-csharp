using Linq.Fluent.Funcs.Base;
using Linq.Fluent.Funcs.FuncBuilders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Fluent.Funcs.FuncBuilders
{
    public class FuncBuilder<T1, T2> : FuncBuilderBase<T1, T2>, IFuncBuilder<T1, T2>
    {
        public IFuncConditionsBuilder<T1, T2> Conditions { get; set; }

        public FuncBuilder(Func<T1, T2> firstExpression, IEnumerable<T1> query) : base(firstExpression, query)
        {
            Conditions = new FuncConditionsBuilder<T1, T2>(firstExpression, query);
        }

        public IEnumerable<T1> Condition(Func<T2, bool> secondExpression)
        {
            return ReturnValue(Concat(secondExpression));
        }

        public IEnumerable<T1> IsOneOfConditions(Func<T2, bool> secondExpression, params Func<T2, bool>[] expressions)
        {
            Func<T1, bool> expressionResult = Concat(secondExpression);
            foreach (Func<T2, bool> expression in expressions)
            {
                expressionResult = x => expressionResult.Invoke(x) || Concat(expression).Invoke(x);
            }

            return ReturnValue(expressionResult);
        }
        private IEnumerable<T1> ReturnValue(Func<T1, bool> expressionResult)
        {
            if (Negation)
            {
                return Query.Where(x => !expressionResult.Invoke(x));
            }
            return Query.Where(expressionResult);
        }

        public ILinqFluentFuncBuilder<T2, IEnumerable<T1>> Not => (ILinqFluentFuncBuilder<T2, IEnumerable<T1>>)Negate();
    }
}
