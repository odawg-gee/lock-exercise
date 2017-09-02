using System.Threading.Tasks;
using LockSandbox.Services.Models;

namespace LockSandbox.Services.Interfaces
{
    internal interface ITokenService
    {
        Task<TestModel> CallEndPoint();
    }
}