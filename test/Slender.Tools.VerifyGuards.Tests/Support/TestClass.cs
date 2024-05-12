namespace Slender.Tools.VerifyGuards.Tests.Support
{

    internal class TestClass
    {

        #region - - - - - - Constructors - - - - - -

        public TestClass(string s, int i, TestClass2 tc, ITestInterface ti)
        {
            ArgumentNullException.ThrowIfNull(s);
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(ti);
        }

        public TestClass(string s, int? i, TestClass2 tc, ITestInterface ti) { }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public static void GuardedNullableValueTypeParam(int? i)
            => ArgumentNullException.ThrowIfNull(i);

        public void InstanceActionNotNullableParams(string s, int i, TestClass2 tc, ITestInterface ti)
        {
            ArgumentNullException.ThrowIfNull(s);
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(ti);
        }

        public void InstanceActionNullableParams(string s, int? i, TestClass2 tc, ITestInterface ti) { }

        public string InstanceFuncNotNullableParams(string s, int i, TestClass2 tc, ITestInterface ti)
        {
            ArgumentNullException.ThrowIfNull(s);
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(ti);

            return string.Empty;
        }

        public string InstanceFuncNullableParams(string s, int? i, TestClass2 tc, ITestInterface ti)
            => string.Empty;

        public static void StaticActionNotNullableParams(string s, int i, TestClass2 tc, ITestInterface ti)
        {
            ArgumentNullException.ThrowIfNull(s);
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(ti);
        }

        public static void StaticActionNullableParams(string s, int? i, TestClass2 tc, ITestInterface ti) { }

        public static string StaticFuncNotNullableParams(string s, int i, TestClass2 tc, ITestInterface ti)
            => string.Empty;

        public static string StaticFuncNullableParams(string s, int? i, TestClass2 tc, ITestInterface ti)
        {
            ArgumentNullException.ThrowIfNull(s);
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(ti);

            return string.Empty;
        }

        #endregion Methods

    }

}
