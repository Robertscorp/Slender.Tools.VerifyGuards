using Moq;
using System;
using System.Linq;
using System.Text;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal static class InstanceResolver
    {

        #region - - - - - - Methods - - - - - -

        public static object GetInstance(Type type)
        {
            try
            {
                return GetInstanceInternal(type);
            }
            catch (Exception)
            {
                var _MessageBuilder = new StringBuilder(32)
                    .Append("Could not get an instance of '")
                    .Append(type.Name)
                    .Append("'. If possible, manually provide an instance of '")
                    .Append(type.Name)
                    .Append("' to resolve this issue.");

                throw new GuardException(_MessageBuilder.ToString());
            }
        }

        private static object GetInstanceInternal(Type type)
        {
            if (type.IsAbstract)
                return ((Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(type))).Object;

            else
            {
                var _Parameters = Array.Empty<object>();
                var _Constructor = type
                                    .GetConstructors()
                                    .Where(c => !c.GetParameters().Any(p => p.ParameterType == type))
                                    .OrderBy(c => c.GetParameters().Length)
                                    .FirstOrDefault();

                if (_Constructor != null)
                    _Parameters = _Constructor
                                    .GetParameters()
                                    .Select(p => GetInstanceInternal(p.ParameterType))
                                    .ToArray();

                return Activator.CreateInstance(type, _Parameters);
            }
        }

        #endregion Methods

    }

}
