using System.Collections.Generic;
using LockSandbox.Console.ApiCall.Jobs;
using LockSandbox.Console.ApiCall.Jobs.Interfaces;
using LockSandbox.Services;
using LockSandbox.Services.Interfaces;
using SimpleInjector;

namespace LockSandbox.Console.ApiCall.Ioc
{
    public static class SimpleInjectorConfig
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Register<ITestServiceFactory, TestServiceFactory>(Lifestyle.Singleton);
            container.Register<IMainJob, MainJob>();
            container.RegisterCollection<IJob>(new[]
            {
                typeof(Job1),
                typeof(Job2),
                typeof(Job3)
            });

            container.Verify();

            Container = container;
        }

        public static Container Container { get; private set; }
    }
}