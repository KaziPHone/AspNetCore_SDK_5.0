using System.Collections.Generic;
using MetricsAgent.DAL.Responses.Models;

namespace MetricsAgent.DAL.Responses
{
    public class AllRamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }
}
