using System.Threading.Tasks;
using LockSandbox.Services.Interfaces;
using LockSandbox.Services.Models;

namespace LockSandbox.Services
{
    internal class TokenService : ITokenService
    {
        public async Task<TestModel> CallEndPoint()
        {
            var task = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                return new TestModel();
            });
            
            return await task.ConfigureAwait(false);
        }
    }
}