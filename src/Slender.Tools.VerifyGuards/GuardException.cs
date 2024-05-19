using System;

namespace Slender.Tools.VerifyGuards
{

    /// <summary>
    /// Represents errors that occur while verifying guard clauses.
    /// </summary>
    public class GuardException : Exception
    {

        #region - - - - - - Constructors - - - - - -

        internal GuardException(string message) : base(message) { }

        #endregion Constructors

    }

}
