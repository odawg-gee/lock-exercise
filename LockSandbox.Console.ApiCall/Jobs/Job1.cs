using System.Net.Http;
using System.Threading.Tasks;
using LockSandbox.Console.ApiCall.Jobs.Interfaces;

namespace LockSandbox.Console.ApiCall.Jobs
{
    public class Job1 : IJob
    {
        public Task<string> GetResponse()
        {
            var httpClient = new HttpClient();
            
            return httpClient
                .GetStringAsync("http://localhost:54828/api/test");
        }
    }
}