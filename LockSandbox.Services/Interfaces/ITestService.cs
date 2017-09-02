using System.Threading.Tasks;
using LockSandbox.Services.Models;

namespace LockSandbox.Services.Interfaces
{
    public interface ITestService
    {
        Task<TestModel> GetModel();
    }
}