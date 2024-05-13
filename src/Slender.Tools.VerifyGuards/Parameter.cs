using Slender.Tools.VerifyGuards.Internals;
using System;

namespace Slender.Tools.VerifyGuards
{

    public class Parameter(bool IsNullable, Type ParameterType)
    {

        #region - - - - - - Properties - - - - - -

        internal bool IsNullable { get; } = IsNullable;

        internal string Name { get; set; }

        internal Type ParameterType { get; } = ParameterType;

        internal object Value { get; set; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        internal object GetValue()
            => this.Value ?? InstanceCache.GetInstance(this.ParameterType);

        internal bool IsInvalidNonNullableValueType()
            => this.IsNullable && this.ParameterType.IsNonNullableValueType();

        internal bool IsInvalidNullableValueType()
            => !this.IsNullable && this.ParameterType.IsNullableValueType();

        #endregion Methods

    }

}
