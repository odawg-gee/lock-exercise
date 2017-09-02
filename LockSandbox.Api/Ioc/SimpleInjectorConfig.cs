using System.Web.Http;
using LockSandbox.Services;
using LockSandbox.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace LockSandbox.Api.Ioc
{
    public static class SimpleInjectorConfig
    {
        public static void Initialize(HttpConfiguration httpConfiguration)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<ITestServiceFactory, TestServiceFactory>(Lifestyle.Singleton);
            container.Verify();

            httpConfiguration.DependencyResolver = 
                new SimpleInjectorWebApiDependencyResolver(container);

            Container = container;
        }

        public static Container Container { get; private set; }
    }
}