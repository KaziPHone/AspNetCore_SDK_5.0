using System;

namespace MetricsAgent.DAL.Requests.Models
{
    public class RamMetricCreateRequest
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
    }
}
