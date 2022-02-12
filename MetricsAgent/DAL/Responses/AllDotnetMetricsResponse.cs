using System.Collections.Generic;
using MetricsAgent.DAL.Responses.Models;

namespace MetricsAgent.DAL.Responses
{
    public class AllDotnetMetricsResponse
    {
        public List<DotnetMetricDto> Metrics { get; set; }
    }
}
