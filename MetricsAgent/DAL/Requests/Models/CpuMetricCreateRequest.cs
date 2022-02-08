using System;

namespace MetricsAgent.DAL.Requests.Models
{
    public class CpuMetricCreateRequest
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
    }
}
