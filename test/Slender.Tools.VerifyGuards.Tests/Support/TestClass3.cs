namespace Slender.Tools.VerifyGuards.Tests.Support
{

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
