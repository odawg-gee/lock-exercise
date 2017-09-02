using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockSandbox.Ioc;
using LockSandbox.Jobs.Interfaces;

namespace LockSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleInjectorConfig.Initialize();

            var container = SimpleInjectorConfig.Container;

            var job = container.GetInstance<IJob>();

            job.Execute();

            Console.ReadLine();
        }
    }
}
