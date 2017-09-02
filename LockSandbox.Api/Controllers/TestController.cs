using System.Threading.Tasks;
using System.Web.Http;
using LockSandbox.Services.Interfaces;

namespace LockSandbox.Api.Controllers
{
    public class TestController : ApiController
    {
        private readonly ITestServiceFactory _testServiceFactory;

        public TestController(ITestServiceFactory testServiceFactory)
        {
            _testServiceFactory = testServiceFactory;
        }

        [Route("api/Test")]
        public async Task<IHttpActionResult> Get()
        {
            var testModel = await _testServiceFactory
                .GetInstance()
                .GetModel();

            return Ok(testModel);
        }
    }
}