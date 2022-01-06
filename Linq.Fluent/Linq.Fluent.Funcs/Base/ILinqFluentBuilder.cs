using System;

namespace Linq.Fluent.Funcs.Base
{
    public interface ILinqFluentFuncBuilder<T, TResult>
    {
        TResult Condition(Func<T, bool> secondExpression);
        TResult IsOneOfConditions(Func<T, bool> secondExpression, params Func<T, bool>[] expressions);
        ILinqFluentFuncBuilder<T, TResult> Not { get; }
    }
}
