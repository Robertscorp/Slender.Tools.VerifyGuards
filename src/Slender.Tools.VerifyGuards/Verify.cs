using Slender.Tools.VerifyGuards.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Slender.Tools.VerifyGuards
{

    public static class Verify
    {

        #region - - - - - - Methods - - - - - -

        public static void Guards<T>(Expression<Func<T>> constructor)
        {
            var _Visitor = new ConstructorExpressionVisitor();
            var _Constructor = _Visitor.Visit(constructor, out var _Parameters);

            Guards(_Constructor, _Parameters);
        }

        public static void Guards<T>(Expression<Action<T>> methodCall) { }

        private static void Guards(Action<List<object>> action, List<Parameter> parameters)
        {
            var _InvalidParameters = parameters.Select((p, index) => new
            {
                InvalidGuard = IsParameterIncorrectlyGuarded(action, parameters, index),
                InvalidNonNullableValueType = p.IsInvalidNonNullableValueType(),
                InvalidNullableValueType = p.IsInvalidNullableValueType(),
                Parameter = p
            }).Where(p => p.InvalidGuard || p.InvalidNonNullableValueType || p.InvalidNullableValueType).ToList();

            if (_InvalidParameters.Any())
            {
                var _MessageBuilder = new StringBuilder(16);
                _MessageBuilder.AppendLine("The following parameters have issues:");

                foreach (var _Param in _InvalidParameters)
                    _MessageBuilder
                        .TryWriteInvalidParameterGuardError(_Param.Parameter, _Param.InvalidGuard)
                        .TryWriteInvalidNonNullableValueTypeError(_Param.Parameter)
                        .TryWriteInvalidNullableValueTypeError(_Param.Parameter);

                throw new Exception(_MessageBuilder.ToString());
            }
        }

        private static bool IsParameterIncorrectlyGuarded(Action<List<object>> action, List<Parameter> parameters, int index)
        {
            var _Parameter = parameters[index];
            if (_Parameter.ParameterType.IsNonNullableValueType())
                return false;

            var _Params = parameters.Select(param => param.GetValue()).ToList();
            _Params[index] = null;

            try
            {
                action.Invoke(_Params);

                if (!_Parameter.IsNullable && !_Parameter.ParameterType.IsValueType) return true;
            }
            catch (ArgumentNullException)
            {
                if (_Parameter.IsNullable) return true;
            }
            catch (Exception) { }

            return false;
        }

        #endregion Methods

    }

}
