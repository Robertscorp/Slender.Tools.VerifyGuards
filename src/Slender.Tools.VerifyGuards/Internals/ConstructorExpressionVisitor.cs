using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal class ConstructorExpressionVisitor
    {

        #region - - - - - - Fields - - - - - -

        private readonly ParameterExpression m_ParameterExpression = Expression.Parameter(typeof(List<object>), "p");
        private readonly List<Parameter> m_Parameters = [];

        #endregion Fields

        #region - - - - - - Methods - - - - - -

        public Action<List<object>> Visit(Expression node, out List<Parameter> parameters)
        {
            parameters = this.m_Parameters;
            parameters.Clear();

            return this.VisitLambda(node as LambdaExpression).Compile();
        }

        private Expression VisitConstructor(NewExpression node)
        {
            var _Parameters = node.Constructor.GetParameters();

            return Expression.New(node.Constructor, node.Arguments.Select((a, index) => this.VisitConstructorParameter(a, _Parameters[index].Name)));
        }

        private Expression<Action<List<object>>> VisitLambda(LambdaExpression lambda)
            => Expression.Lambda<Action<List<object>>>(this.VisitConstructor((NewExpression)lambda.Body), this.m_ParameterExpression);

        private Expression VisitConstructorParameter(Expression node, string parameterName)
        {
            node = node is MemberExpression _MemberExpression
                    ? _MemberExpression.Expression
                    : ((UnaryExpression)node).Operand;

            var _Parameter = Expression.Lambda<Func<Parameter>>(node).Compile().Invoke();
            _Parameter.Name = parameterName;

            this.m_Parameters.Add(_Parameter);

            var _ArrayIndexExpression = Expression.Property(this.m_ParameterExpression, "Item", Expression.Constant(this.m_Parameters.Count - 1));
            return Expression.Convert(_ArrayIndexExpression, _Parameter.ParameterType);
        }

        #endregion Methods

    }

}
