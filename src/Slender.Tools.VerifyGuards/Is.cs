namespace Slender.Tools.VerifyGuards
{

    public static class Is
    {

        #region - - - - - - Methods - - - - - -

        public static T NotNullable<T>()
            => default;

        public static T NotNullable<T>(T value)
            => value;

        public static T Nullable<T>()
            => default;

        public static T Nullable<T>(T value)
            => value;

        #endregion Methods

    }

}
