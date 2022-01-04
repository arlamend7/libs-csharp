using Linq.Fluent.Funcs.Base;
using System.Collections.Generic;

namespace Linq.Fluent.Funcs.FuncBuilders.Interfaces
{
    public interface IFuncConditionsBuilder<T1, T2> : ILinqFluentFuncBuilder<T2, IFuncConditionsBuilder<T1, T2>>
    {
        IEnumerable<T1> Create();
    }
}
