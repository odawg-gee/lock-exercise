using LockSandbox.Console.ApiCall.Ioc;
using LockSandbox.Console.ApiCall.Jobs.Interfaces;
using static System.Console;

namespace LockSandbox.Console.ApiCall
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleInjectorConfig.Initialize();
            var container = SimpleInjectorConfig.Container;
            container.GetInstance<IMainJob>().Execute();

            ReadLine();
        }
    }
}
