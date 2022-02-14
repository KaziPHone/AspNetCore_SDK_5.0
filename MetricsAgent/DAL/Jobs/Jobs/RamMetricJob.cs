using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using Quartz;

namespace MetricsAgent.DAL.Jobs.Jobs
{
    public class RamMetricJob : IJob
    {
        
        private IRamMetricsRepository _repository;
        private PerformanceCounter _counter;
        
        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
            _counter = new PerformanceCounter("Memory", "Available MBytes");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            var value = Convert.ToInt32(_counter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Models.RamMetric { 
                Time = time, 
                Value = value 
            });
            return Task.CompletedTask;
        }
    }
    
}