﻿namespace Slender.Tools.VerifyGuards.Tests.Support
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
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

        public static long NoParameters()
            => 0;

        public static void NotNullableValueTypeParam(int i) { }

        public static void NullableValueTypeParam(int? i) { }

        public static void StaticActionNotNullableParams(string s, int i, TestClass2 tc, ITestInterface ti)
        {
            ArgumentNullException.ThrowIfNull(s);
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(ti);
        }

        public static void StaticActionNullableParams(string? s, int? i, TestClass2? tc, ITestInterface ti) { }

        public static string StaticFuncNotNullableParams(string s, int i, TestClass2 tc, ITestInterface ti)
            => string.Empty;

        public static string StaticFuncNullableParams(string? s, int? i, TestClass2? tc, ITestInterface ti)
        {
            ArgumentNullException.ThrowIfNull(s);
            ArgumentNullException.ThrowIfNull(tc);
            ArgumentNullException.ThrowIfNull(ti);

            return string.Empty;
        }

        public static void UnconstructibleParamDirect(TestClass3 tc) { }

        public static void UnconstructibleParamIndirect(TestClass4 tc) { }

        #endregion Methods

    }

}
