using System.Collections.Generic;

namespace MetricsAgent.DAL.Responses.Models
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }
}
