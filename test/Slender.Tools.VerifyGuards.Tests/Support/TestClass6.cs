namespace Slender.Tools.VerifyGuards.Tests.Support
{

    public delegate object TestDelegate();

#pragma warning disable CS9113 // Parameter is unread.
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    internal class TestClass6(Action<object> action1, Func<object> func1, TestDelegate testDelegate1, Delegate @delagate1, MulticastDelegate multicastDelegate1)
#pragma warning restore CS9113 // Parameter is unread.
    {

        #region - - - - - - Methods - - - - - -

        public void NonNullableDelegates(Action<object> action, Func<object> func, TestDelegate testDelegate, Delegate @delagate, MulticastDelegate multicastDelegate)
        {
            ArgumentNullException.ThrowIfNull(action);
            ArgumentNullException.ThrowIfNull(func);
            ArgumentNullException.ThrowIfNull(testDelegate);
            ArgumentNullException.ThrowIfNull(delagate);
            ArgumentNullException.ThrowIfNull(multicastDelegate);
        }

        public void NullableDelegates(Action<object>? action, Func<object>? func, TestDelegate? testDelegate, Delegate? @delagate, MulticastDelegate? multicastDelegate) { }

        #endregion Methods

    }

}
