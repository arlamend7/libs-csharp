using System;
using System.Collections.Generic;

namespace Linq.Fluent.Funcs.Base
{
    public class FuncBuilderBase<T1, T2>
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
            return x =>
            {
                if (x == null) return false;

                T2 param = FirstFunc.Invoke(x);
                if (param == null) return false;

                return secondExpression.Invoke(param);
            };
        }

        protected FuncBuilderBase<T1, T2> Negate()
        {
            Negation = true;
            return this;
        }
    }
}
