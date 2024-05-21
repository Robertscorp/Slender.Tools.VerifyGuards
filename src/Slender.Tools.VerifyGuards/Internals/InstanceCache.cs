using Moq;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal static class InstanceCache
    {

        #region - - - - - - Fields - - - - - -

        private static readonly ConcurrentDictionary<Type, object> s_InstanceByType = [];

        #endregion Fields

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
            if (!s_InstanceByType.TryGetValue(type, out var _Instance))
            {
                if (type.IsAbstract)
                    _Instance = ((Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(type))).Object;

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

                    _Instance = Activator.CreateInstance(type, _Parameters);
                }

                s_InstanceByType.TryAdd(type, _Instance);
            }

            return _Instance;
        }

        #endregion Methods

    }

}
