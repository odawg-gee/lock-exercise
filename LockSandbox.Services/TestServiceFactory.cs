using LockSandbox.Services.Interfaces;

namespace LockSandbox.Services
{
    public class TestServiceFactory : ITestServiceFactory
    {
        private readonly ICacheService _cacheService;
        private readonly ITokenService _tokenService;

        public TestServiceFactory()
            : this(new CacheService(), new TokenService())
        { }

        internal TestServiceFactory(ICacheService cacheService, 
            ITokenService tokenService)
        {
            _cacheService = cacheService;
            _tokenService = tokenService;
        }

        public TestService GetInstance()
        {
            return new TestService(_cacheService, _tokenService);
        }
    }
}