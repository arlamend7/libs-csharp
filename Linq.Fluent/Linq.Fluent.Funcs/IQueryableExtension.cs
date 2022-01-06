using Linq.Fluent.Funcs.FuncBuilders;
using Linq.Fluent.Funcs.FuncBuilders.Interfaces;
using System;
using System.Collections.Generic;

namespace Linq.Fluent.Funcs
{
    public static class IQueryableExtension
    {
        public static IFuncBuilder<T1, T2> WhereParam<T1, T2>(this IEnumerable<T1> query, Func<T1, T2> expression)
        {
            return new FuncBuilder<T1, T2>(expression, query);
        }
        public static IFuncBuilder<T1, T1> WhereQuery<T1>(this IEnumerable<T1> query)
        {
            return new FuncBuilder<T1, T1>(x => x, query);
        }
    }
}
