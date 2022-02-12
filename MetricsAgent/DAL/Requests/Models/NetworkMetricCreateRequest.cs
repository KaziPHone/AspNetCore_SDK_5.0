using System;

namespace MetricsAgent.DAL.Requests.Models
{
    public class NetworkMetricCreateRequest
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
    }
}
