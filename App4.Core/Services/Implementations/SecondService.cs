using System.Threading.Tasks;

namespace App4.Core.Services.Implementations
{
    public class SecondService : ISecondService
    {
        public Task WaitASecond()
        {
            return Task.Delay(1000);
        }
    }
}
