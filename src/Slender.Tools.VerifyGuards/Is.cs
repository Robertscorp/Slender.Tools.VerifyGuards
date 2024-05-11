namespace Slender.Tools.VerifyGuards
{

    public static class Is
    {

        #region - - - - - - Methods - - - - - -

        public static Parameter<T> NotNullable<T>()
            => new(IsNullable: false);

        public static Parameter<T> Nullable<T>()
            => new(IsNullable: true);

        #endregion Methods

    }

}
