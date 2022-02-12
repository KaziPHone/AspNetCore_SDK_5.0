using System.Collections.Generic;
using MetricsAgent.DAL.Responses.Models;

namespace MetricsAgent.DAL.Responses
{
    public class AllHddMetricsResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }
}
