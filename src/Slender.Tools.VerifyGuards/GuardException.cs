using System;

namespace Slender.Tools.VerifyGuards
{

    /// <summary>
    /// Represents errors that occur while verifying guard clauses.
    /// </summary>
    /// <param name="Message">The message that describes the error.</param>
    public class GuardException(string Message) : Exception(Message) { }

}
