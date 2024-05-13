using System;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal class Parameter(bool IsNullable, Type ParameterType)
    {

        #region - - - - - - Properties - - - - - -

        public bool IsNullable { get; } = IsNullable;

        public string Name { get; set; }

        public Type ParameterType { get; } = ParameterType;

        public object Value { get; set; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public object GetValue()
            => this.Value ?? InstanceCache.GetInstance(this.ParameterType);

        public bool IsInvalidNonNullableValueType()
            => this.IsNullable && this.ParameterType.IsNonNullableValueType();

        public bool IsInvalidNullableValueType()
            => !this.IsNullable && this.ParameterType.IsNullableValueType();

        #endregion Methods

    }

}
