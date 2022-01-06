using Linq.Fluent.Funcs.Base;
using Linq.Fluent.Funcs.FuncBuilders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Fluent.Funcs.FuncBuilders
{
    public class FuncConditionsBuilder<T1, T2> : FuncBuilderBase<T1, T2>, IFuncConditionsBuilder<T1, T2>
    {
        private List<Func<T1, bool>> Expressions { get; set; }
        public FuncConditionsBuilder(Func<T1, T2> firstExpression, IEnumerable<T1> query) : base(firstExpression, query)
        {
            Expressions = new List<Func<T1, bool>>();
        }

        public IEnumerable<T1> Create()
        {
            return Query.Where(value => Expressions.All(x => x.Invoke(value)));
        }

        public IFuncConditionsBuilder<T1, T2> Condition(Func<T2, bool> secondExpression)
        {
            Add(Concat(secondExpression));
            return this;
        }

        public IFuncConditionsBuilder<T1, T2> IsOneOfConditions(Func<T2, bool> secondExpression, params Func<T2, bool>[] expressions)
        {
            List<Func<T2, bool>> expressionsList = expressions.ToList();
            expressionsList.Add(secondExpression);
            IEnumerable<Func<T1, bool>> expressionsResultList = expressionsList.Select(func => Concat(func));

            Add(x => expressionsResultList.Any(func => func.Invoke(x)));
            return this;
        }
        private void Add(Func<T1, bool> expression)
        {
            if (Negation)
            {
                Negation = false;
                Expressions.Add(x => !expression.Invoke(x));
            }
            Expressions.Add(expression);
        }

        public ILinqFluentFuncBuilder<T2, IFuncConditionsBuilder<T1, T2>> Not => (ILinqFluentFuncBuilder<T2, IFuncConditionsBuilder<T1, T2>>)Negate();

    }
}