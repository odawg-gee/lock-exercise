using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LockSandbox.Jobs.Interfaces;
using LockSandbox.Services.Interfaces;
using LockSandbox.Services.Models;

namespace LockSandbox.Jobs
{
    public class MainJob : IJob
    {
        private readonly ITestServiceFactory _factory;

        public MainJob(ITestServiceFactory factory)
        {
            _factory = factory;
        }

        public void Execute()
        {
            var service1 = _factory.GetInstance();
            var service2 = _factory.GetInstance();
            var service3 = _factory.GetInstance();
            
            var tasks = new List<Task<TestModel>>
            {
                Task<TestModel>.Factory.StartNew(() => service1.GetModel().Result),
                Task<TestModel>.Factory.StartNew(() => service2.GetModel().Result),
                Task<TestModel>.Factory.StartNew(() => service3.GetModel().Result)
            };

            Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                Console.WriteLine(task.Result.AccessToken);  
            }
        }
    }
}