using System.Collections.Generic;
using MetricsAgent.DAL.Responses.Models;

namespace MetricsAgent.DAL.Responses
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }
}
