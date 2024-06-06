namespace Slender.Tools.VerifyGuards
{

    /// <summary>
    /// Provides a set of static methods for defining method parameters.
    /// </summary>
    public static class Is
    {

        #region - - - - - - Methods - - - - - -

        /// <summary>
        /// Declares that a parameter will be guarded against null values.
        /// </summary>
        /// <typeparam name="T">The type of parameter.</typeparam>
        /// <remarks>
        /// This method represents a parameter within an Expression; it should not be used outside an Expression.
        /// </remarks>
        public static T NotNullable<T>()
            => default;

        /// <summary>
        /// Declares that a parameter will be guarded against null values.
        /// </summary>
        /// <typeparam name="T">The type of parameter.</typeparam>
        /// <param name="value">The value for the parameter when verifying other parameters. Must pass all guards.</param>
        /// <remarks>
        /// This method represents a parameter within an Expression; it should not be used outside an Expression.
        /// </remarks>
        public static T NotNullable<T>(T value)
            => value;

        /// <summary>
        /// Declares that a parameter will not be guarded against null values.
        /// </summary>
        /// <typeparam name="T">The type of parameter.</typeparam>
        /// <remarks>
        /// This method represents a parameter within an Expression; it should not be used outside an Expression.
        /// </remarks>
        public static T Nullable<T>()
            => default;

        /// <summary>
        /// Declares that a parameter will not be guarded against null values.
        /// </summary>
        /// <typeparam name="T">The type of parameter.</typeparam>
        /// <param name="value">The value for the parameter when verifying other parameters. Must pass all guards.</param>
        /// <remarks>
        /// This method represents a parameter within an Expression; it should not be used outside an Expression.
        /// </remarks>
        public static T Nullable<T>(T value)
            => value;

        #endregion Methods

    }

}
