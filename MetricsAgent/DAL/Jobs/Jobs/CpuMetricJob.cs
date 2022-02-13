using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MetricsAgent.DAL.Interfaces;
using Quartz;

namespace MetricsAgent.DAL.Jobs.Jobs
{
    public class CpuMetricJob : IJob
    {
        
        private ICpuMetricsRepository _repository;
        private PerformanceCounter _counter;
        
        public CpuMetricJob(ICpuMetricsRepository repository)
        {
            _repository = repository;
            _counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            var value = Convert.ToInt32(_counter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Models.CpuMetric { 
                Time = time, 
                Value = value 
            });
            return Task.CompletedTask;
        }
    }
    
}