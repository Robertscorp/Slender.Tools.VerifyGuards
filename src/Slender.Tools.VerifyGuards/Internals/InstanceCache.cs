using System;
using System.Collections.Concurrent;
using System.Linq;

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
            if (!s_InstanceByType.TryGetValue(type, out var _Instance))
            {
                if (type.IsAbstract)
                {
                    // TODO: Mock.
                }
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
                                        .Select(p => GetInstance(p.ParameterType))
                                        .ToArray();

                    _Instance = Activator.CreateInstance(type, _Parameters);

                    s_InstanceByType.TryAdd(type, _Instance);
                }
            }

            return _Instance;
        }

        #endregion Methods

    }

}
