using Linq.Fluent.Funcs.Base;
using System.Collections.Generic;

namespace Linq.Fluent.Funcs.FuncBuilders.Interfaces
{
    public interface IFuncBuilder<T1, T2> : ILinqFluentFuncBuilder<T2, IEnumerable<T1>>
    {
        IFuncConditionsBuilder<T1, T2> Conditions { get; }
    }
}
