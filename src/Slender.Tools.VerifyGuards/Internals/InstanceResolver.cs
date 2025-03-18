using Moq;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Slender.Tools.VerifyGuards.Internals
{

    internal static class InstanceResolver
    {

        #region - - - - - - Fields - - - - - -

        private static readonly Func<Type, object> s_InstanceFactory;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        static InstanceResolver()
        {
            var _InstanceFactoryCache = new ConcurrentDictionary<Type, Func<object>>();

            s_InstanceFactory = type =>
            {
                try
                {
                    if (!_InstanceFactoryCache.TryGetValue(type, out var _ValueFunc))
                    {
                        if (type.IsAbstract)
                            _ValueFunc = () => ((Mock)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(type))).Object;

                        else if (type.IsValueType)
                            _ValueFunc = () => Activator.CreateInstance(type);

                        else // This can be made more efficient by using a compiled expression tree.
                        {
                            var _Constructor
                                = type
                                    .GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                    .OrderBy(c => c.GetParameters().Length)
                                    .First();

                            var _Parameters
                                = _Constructor
                                    .GetParameters()
                                    .Select<ParameterInfo, Func<object>>(p
                                        => IsParameterNullable(p)
                                            ? () => default(object)
                                            : () => s_InstanceFactory(p.ParameterType))
                                    .ToList();

                            _ValueFunc = () => _Constructor.Invoke(_Parameters.Select(p => p()).ToArray());
                        }

                        _ValueFunc = _InstanceFactoryCache.GetOrAdd(type, _ValueFunc);
                    }

                    return _ValueFunc();
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
            };
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public static object GetInstance(Type type)
            => s_InstanceFactory(type);

        private static bool IsParameterNullable(ParameterInfo parameter)
        {
            if (parameter.ParameterType.IsValueType)
                return Nullable.GetUnderlyingType(parameter.ParameterType) != null;

            var _NullableAttribute = parameter.CustomAttributes.FirstOrDefault(attr => attr.AttributeType.Name == "NullableAttribute");
            return _NullableAttribute != null && ((byte)_NullableAttribute.ConstructorArguments[0].Value) == 2;
        }

        #endregion Methods

    }

}
