using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;

namespace Accounts.Core
{
    /// <summary>
    /// TinyIoC wrapper class for required methods, therefore if needed service provider can be changed easily in future.
    /// </summary>
    public class ServiceLocator
    {
        private static TinyIoC.TinyIoCContainer _container;

        static ServiceLocator()
        {
            _container = new TinyIoCContainer();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static void Register<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>();
        }
    }
}
