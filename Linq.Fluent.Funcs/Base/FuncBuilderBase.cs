using System;
using System.Collections.Generic;

namespace Linq.Fluent.Funcs.Base
{
    public class FuncBuilderBase<T1,T2>
    {
        protected IEnumerable<T1> Query { get; }
        protected bool Negation;

        protected Func<T1, T2> FirstFunc { get; }

        public FuncBuilderBase(Func<T1, T2> firstFunc, IEnumerable<T1> query)
        {
            FirstFunc = firstFunc;
            Query = query;
        }

        protected Func<T1, bool> Concat(Func<T2, bool> secondExpression)
        {
            return x => secondExpression.Invoke(FirstFunc.Invoke(x));
        }

        protected FuncBuilderBase<T1, T2> Negate()
        {
            Negation = true;
            return this;
        }
    }
}
