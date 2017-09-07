using System.Threading;
using System.Threading.Tasks;
using LockSandbox.Services.Interfaces;
using LockSandbox.Services.Models;

namespace LockSandbox.Services
{
    public class TestService : ITestService
    {
        private readonly ICacheService _cacheService;
        private readonly ITokenService _tokenService;
        private static readonly SemaphoreSlim Locker = new SemaphoreSlim(1,1);

        internal TestService()
        { }

        internal TestService(ICacheService cacheService,
            ITokenService tokenService)
        {
            _cacheService = cacheService;
            _tokenService = tokenService;
        }

        public async Task<TestModel> GetModel()
        {
            try
            {
                await Locker.WaitAsync();

                var cacheData = _cacheService.GetCache<TestModel>("TestKey");

                if (cacheData != null)
                    return cacheData;

                var response = await _tokenService
                    .CallEndPoint();
                
                _cacheService.SetCache(response, "TestKey", 3600);

                return response;
            }
            finally
            {
                Locker.Release();
            }
        }
    }
}