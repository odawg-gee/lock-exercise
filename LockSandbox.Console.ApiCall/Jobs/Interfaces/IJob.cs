using System.Threading.Tasks;
using LockSandbox.Services.Models;

namespace LockSandbox.Console.ApiCall.Jobs.Interfaces
{
    public interface IJob
    {
        Task<string> GetResponse();
    }
}