namespace Slender.Tools.VerifyGuards
{

    public class Parameter<T>(bool IsNullable) : Parameter(IsNullable, typeof(T))
    {

        #region - - - - - - Properties - - - - - -

        public T Object => default!;

        #endregion Properties

        #region - - - - - - Operations - - - - - -

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public static implicit operator T(Parameter<T> parameter) => parameter;

        #endregion Operations

    }

}
