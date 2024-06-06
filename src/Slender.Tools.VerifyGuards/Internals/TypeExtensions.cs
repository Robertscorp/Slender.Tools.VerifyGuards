using System;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal static class TypeExtensions
    {

        #region - - - - - - Methods - - - - - -

        internal static Type GetTypeDefinition(this Type type)
            => type.IsGenericType ? type.GetGenericTypeDefinition() : type;

        internal static bool IsNonNullableValueType(this Type type)
            => type.IsValueType && !type.IsNullableValueType();

        internal static bool IsNullableValueType(this Type type)
            => type.GetTypeDefinition() == typeof(Nullable<>);

        #endregion Methods

    }

}
