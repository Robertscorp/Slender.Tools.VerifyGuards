using System;

namespace Slender.Tools.VerifyGuards
{

    public class GuardException(string Message) : Exception(Message) { }

}
