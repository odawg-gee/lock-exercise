using LockSandbox.Jobs;
using LockSandbox.Jobs.Interfaces;
using LockSandbox.Services;
using LockSandbox.Services.Interfaces;
using SimpleInjector;

namespace LockSandbox.Ioc
{
    public static class SimpleInjectorConfig
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Register<IJob, MainJob>();
            container.Register<ITestServiceFactory, TestServiceFactory>(Lifestyle.Singleton);
            container.Verify();

            Container = container;
        }

        public static Container Container { get; private set; }
    }
}