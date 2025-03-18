namespace Slender.Tools.VerifyGuards.Tests.Support
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    internal class TestClass3
    {

        #region - - - - - - Constructors - - - - - -

        public TestClass3(int i)
            => ArgumentOutOfRangeException.ThrowIfNegativeOrZero(i);

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public void TestMethod(int i1) { }

        #endregion Methods

    }

}
