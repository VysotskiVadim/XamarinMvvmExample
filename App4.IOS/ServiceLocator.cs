using App4.Core;
using Microsoft.Practices.Unity;

namespace App4.IOS
{
    public static class ServiceLocator
    {
        public static IUnityContainer Container { get; private set; }

        static ServiceLocator()
        {
            var container = new UnityContainer();
            new CoreRegitry().Register(container);
            new IosRegistry().Register(container);
            Container = container;
        }
    }
}