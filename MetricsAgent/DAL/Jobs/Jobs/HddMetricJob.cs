using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using Quartz;

namespace MetricsAgent.DAL.Jobs.Jobs
{
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _counter;
        
        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _counter = new PerformanceCounter("PhysicalDisk", "Disk Reads/sec", "_Total");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            var value = Convert.ToInt32(_counter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Models.HddMetric { 
                Time = time, 
                Value = value 
            });
            return Task.CompletedTask;
        }
    }
}