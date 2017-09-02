using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace LockSandbox.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();

            httpConfiguration.Formatters.Clear();
            var jsonMediaTypeFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
            };
            httpConfiguration.Formatters.Add(jsonMediaTypeFormatter);

            Ioc.SimpleInjectorConfig.Initialize(httpConfiguration);

            app.UseWebApi(httpConfiguration);
        }
    }
}