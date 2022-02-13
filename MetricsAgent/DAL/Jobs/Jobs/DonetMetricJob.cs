using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Jobs.Jobs
{
    public class DotnetMetricJob : IJob
    {
        private IDotnetMetricsRepository _repository;
        private PerformanceCounter _counter;

        public DotnetMetricJob(IDotnetMetricsRepository repository)
        {
            _repository = repository;
            _counter = new PerformanceCounter("Память CLR .NET", "Байт во всех кучах","_Global_");
        }

        public Task Execute(IJobExecutionContext context)
        {
            
            var value = Convert.ToInt32(_counter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Models.DotnetMetric
            {
                Time = time,
                Value = value
            });
            return Task.CompletedTask;
        }
    }
}
