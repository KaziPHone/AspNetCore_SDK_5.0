using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Jobs.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _counter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _counter = new PerformanceCounter("Network Interface", "Bytes Total/sec");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var value = Convert.ToInt32(_counter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Models.NetworkMetric
            {
                Time = time,
                Value = value
            });
            return Task.CompletedTask;
        }
    }
}
