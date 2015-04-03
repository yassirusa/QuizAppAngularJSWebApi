using System.Reflection;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyInjection
{
    public class Container
    {
        #region Properties

        private static IUnityContainer _instance;

        #endregion

        #region Configuration

        public static bool IsContainerConfigured()
        {
            return (_instance != null);
        }

        /// <returns></returns>
        public static void Configure()
        {
            if (_instance == null)
            {
                _instance = new UnityContainer();
            }
        }

        #endregion

        #region Register

        public static void RegisterInstance<T>(T instance)
        {
            _instance.RegisterInstance<T>(instance);
        }


        public static void RegisterType(Type type)
        {
            if (_instance.IsRegistered(type))
                _instance.RegisterType(type);
        }
        public static void RegisterType<T>(Type mapsTo)
        {
            if (_instance.IsRegistered(mapsTo))
                _instance.RegisterType(typeof(T), mapsTo);
        }
        public static void RegisterType<T>(Type mapsTo, string name)
        {
            if (_instance.IsRegistered(mapsTo, name))
                _instance.RegisterType(typeof(T), mapsTo, name);
        }
        public static void RegisterType(Type from, Type mapsTo)
        {
            if (_instance.IsRegistered(mapsTo))
                _instance.RegisterType(from, mapsTo);
        }
        #endregion

        #region Resolve

        public static bool IsRegistered(Type t)
        {
            return _instance.IsRegistered(t);
        }

        public static bool IsRegistered(Type t, string nameToCheck)
        {
            return _instance.IsRegistered(t, nameToCheck);
        }

        public static bool IsRegistered<T>()
        {
            return _instance.IsRegistered<T>();
        }

        public static T Resolve<T>()
        {
            return _instance.Resolve<T>();
        }

        public static object Resolve(Type t)
        {
            return _instance.Resolve(t);
        }

        public static T Resolve<T>(IDictionary<string, object> parameters)
        {
            return (T)Resolve(typeof(T), parameters);
        }

        public static object Resolve(Type t, IDictionary<string, object> parameters)
        {
            ResolverOverride[] overrides = new ParameterOverride[parameters.Count];

            int parameterCount = 0;

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                overrides[parameterCount++] = new ParameterOverride(parameter.Key, parameter.Value);
            }

            return _instance.Resolve(t, overrides);
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            //¿ TODO - ResolveAll requires a name registered with a type in Unity. If we do this, all other registrations will break. Try and find fix when upgrading to Unity 3.0 - TODO ?//

            return new List<T> { _instance.Resolve<T>() };
        }

        #endregion
    }
}
