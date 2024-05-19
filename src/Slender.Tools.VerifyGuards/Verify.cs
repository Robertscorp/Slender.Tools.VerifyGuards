using Slender.Tools.VerifyGuards.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Slender.Tools.VerifyGuards
{

    /// <summary>
    /// Provides a set of static methods for verifying guards are being enforced.
    /// </summary>
    public static class Verify
    {

        #region - - - - - - Methods - - - - - -

        /// <summary>
        /// Verifies that the parameters of an invocation are being correctly guarded.
        /// </summary>
        /// <param name="expression">
        /// An expression which represents an invocation, and the expected guards for the parameters of the invocation.<br/>
        /// <br/>
        /// Supports constructors, instance methods, and static methods.<br/>
        /// <br/>
        /// Constructors:
        /// <code>() => new Class(Is.Nullable&lt;T&gt;(), ...)</code>
        /// <br/>
        /// Instance Methods:
        /// <code>(Class c) => c.InstanceMethod(Is.Nullable&lt;T&gt;(), ...)</code>
        /// <code>() => new Class(...).InstanceMethod(Is.Nullable&lt;T&gt;(), ...)</code>
        /// <code>() => classParameter.InstanceMethod(Is.Nullable&lt;T&gt;(), ...)</code>
        /// <code>() => _ClassVariable.InstanceMethod(Is.Nullable&lt;T&gt;(), ...)</code>
        /// <code>() => this.m_ClassField.InstanceMethod(Is.Nullable&lt;T&gt;(), ...)</code>
        /// <br/>
        /// Static Methods:
        /// <code>() => Class.StaticMethod(Is.Nullable&lt;T&gt;(), ...)</code>
        /// </param>
        /// <exception cref="GuardException">Thrown when the actual guards within the invocation do not match the expected guards defined in the specified <paramref name="expression"/>.</exception>
        public static void Guards(LambdaExpression expression)
        {
            var _Action = new GuardsExpressionVisitor().Visit(expression, out var _Parameters);
            var _InvalidParameters = _Parameters.Select((p, index) => new
            {
                InvalidGuard = IsParameterIncorrectlyGuarded(_Action, _Parameters, index),
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

                throw new GuardException(_MessageBuilder.ToString());
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
