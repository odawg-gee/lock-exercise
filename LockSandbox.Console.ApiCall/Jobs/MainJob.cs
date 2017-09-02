using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LockSandbox.Console.ApiCall.Jobs.Interfaces;

namespace LockSandbox.Console.ApiCall.Jobs
{
    public class MainJob : IMainJob
    {
        private readonly IEnumerable<IJob> _jobs;

        public MainJob(IEnumerable<IJob> jobs)
        {
            _jobs = jobs;
        }

        public void Execute()
        {
            var tasks = _jobs
                .Select(job => job.GetResponse())
                .ToList();

            Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                System.Console.WriteLine(task.Result);
            }
        }
    }
}