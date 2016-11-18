using System;
using App4.Core;
using Microsoft.Practices.Unity;

namespace App4
{
    public static class ServiceLocator
    {
        public static IUnityContainer Container { get; private set; }

        static ServiceLocator()
        {
            var container = new UnityContainer();
            new CoreRegitry().Register(container);
            new DroidRegistry().Register(container);
            Container = container;
        }
    }
}