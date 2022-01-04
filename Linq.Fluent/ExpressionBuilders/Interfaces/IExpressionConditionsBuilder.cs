using Linq.Fluent.Expressions.Base;
using System.Linq;

namespace Linq.Fluent.Expressions.IExpressionBuilder.Interfaces
{
    public interface IExpressionConditionsBuilder<T1, T2> : ILinqFluentExpressionBuilder<T2, IExpressionConditionsBuilder<T1, T2>>
    {
        IQueryable<T1> Create();
    }
}
