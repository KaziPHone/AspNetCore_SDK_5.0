using System.Collections.Generic;
using MetricsAgent.DAL.Responses.Models;

namespace MetricsAgent.DAL.Responses
{
    public class AllNetworkMetricsResponse
    {
        public List<NetworkMetricDto> Metrics { get; set; }
    }
}
