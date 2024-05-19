using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal class GuardsExpressionVisitor
    {

        #region - - - - - - Fields - - - - - -

        protected readonly ParameterExpression m_ParameterExpression = Expression.Parameter(typeof(List<object>), "p");
        protected readonly List<Parameter> m_Parameters = [];

        #endregion Fields

        #region - - - - - - Methods - - - - - -

        public Action<List<object>> Visit(LambdaExpression lambda, out List<Parameter> parameters)
        {
            parameters = this.m_Parameters;
            parameters.Clear();

            return Expression.Lambda<Action<List<object>>>(this.VisitLambdaBody(lambda.Body), this.m_ParameterExpression).Compile();
        }

        private Expression VisitLambdaBody(Expression body)
            => body is NewExpression _NewExpression
                ? this.VisitLambdaBody_Constructor(_NewExpression, _NewExpression.Constructor.GetParameters())
                : this.VisitLambdaBody_MethodCall((MethodCallExpression)body, ((MethodCallExpression)body).Method.GetParameters());

        private Expression VisitLambdaBody_Constructor(NewExpression newExpression, ParameterInfo[] parameters)
            => Expression.New(newExpression.Constructor, newExpression.Arguments.Select((a, index) => this.VisitParameter(a, parameters[index].Name)));

        private Expression VisitLambdaBody_MethodCall(MethodCallExpression call, ParameterInfo[] parameters)
            => Expression.Call(
                call.Object == null || call.Object.NodeType != ExpressionType.Parameter
                    ? call.Object
                    : Expression.Constant(InstanceCache.GetInstance(call.Object.Type)),
                call.Method,
                call.Arguments.Select((a, index) => this.VisitParameter(a, parameters[index].Name)));

        protected Expression VisitParameter(Expression node, string parameterName)
        {
            var _Call = (MethodCallExpression)node;
            if (_Call.Method.DeclaringType != typeof(Is))
                throw new Exception();

            var _Parameter = new Parameter(_Call.Method.Name == nameof(Is.Nullable), _Call.Method.GetGenericArguments()[0]) { Name = parameterName };

            var _ValueExpression = _Call.Arguments.FirstOrDefault();
            if (_ValueExpression != null)
                _Parameter.Value = Expression.Lambda<Func<object>>(Expression.Convert(_ValueExpression, typeof(object))).Compile().Invoke();

            this.m_Parameters.Add(_Parameter);

            var _ArrayIndexExpression = Expression.Property(this.m_ParameterExpression, "Item", Expression.Constant(this.m_Parameters.Count - 1));
            return Expression.Convert(_ArrayIndexExpression, _Parameter.ParameterType);
        }

        #endregion Methods

    }

}
