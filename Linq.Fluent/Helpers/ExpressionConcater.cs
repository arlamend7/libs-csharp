using System.Linq.Expressions;

namespace Linq.Fluent.Expressions.Helpers
{
    public class ExpressionConcater : ExpressionVisitor
    {
        private readonly ParameterExpression parametroExpression;
        private readonly MemberExpression memberExpression;

        public ExpressionConcater(ParameterExpression parametroExpression, MemberExpression memberExpression)
        {
            this.parametroExpression = parametroExpression;
            this.memberExpression = memberExpression;
        }

        public override Expression Visit(Expression node)
        {
            return base.Visit(node == parametroExpression ? memberExpression : node);
        }
    }
}
