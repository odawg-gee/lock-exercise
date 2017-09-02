using System.Threading.Tasks;
using LockSandbox.Services.Interfaces;
using LockSandbox.Services.Models;

namespace LockSandbox.Services
{
    internal class TokenService : ITokenService
    {
        public Task<TestModel> CallEndPoint()
        {
            return Task.FromResult(new TestModel());
        }
    }
}