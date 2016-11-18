using App4.Core.Services;
using App4.Core.Services.Implementations;
using Microsoft.Practices.Unity;

namespace App4.Core
{
    public class CoreRegitry
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<ISecondService, SecondService>();
        }
    }
}
