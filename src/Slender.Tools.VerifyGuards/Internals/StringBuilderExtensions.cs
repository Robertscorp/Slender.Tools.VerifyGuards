using System.Text;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal static class StringBuilderExtensions
    {

        #region - - - - - - Methods - - - - - -

        internal static StringBuilder TryWriteInvalidParameterGuardError(this StringBuilder builder, Parameter parameter, bool shouldWrite)
            => shouldWrite
                ? builder
                    .Append("  - '")
                    .Append(parameter.Name)
                    .Append("' has been defined as ")
                    .Append(parameter.IsNullable ? "nullable" : "not nullable")
                    .Append(", but ")
                    .Append(parameter.IsNullable ? "is" : "is not")
                    .AppendLine(" guarded against null values.")
                : builder;

        internal static StringBuilder TryWriteInvalidNullableValueTypeError(this StringBuilder builder, Parameter parameter)
            => parameter.IsInvalidNullableValueType()
                ? builder
                    .Append("  - '")
                    .Append(parameter.Name)
                    .AppendLine("' has been defined as not nullable, but is a nullable value type.")
                : builder;

        internal static StringBuilder TryWriteInvalidNonNullableValueTypeError(this StringBuilder builder, Parameter parameter)
            => parameter.IsInvalidNonNullableValueType()
                ? builder
                    .Append("  - '")
                    .Append(parameter.Name)
                    .AppendLine("' has been defined as nullable, but is a non-nullable value type.")
                : builder;

        #endregion Methods

    }

}
