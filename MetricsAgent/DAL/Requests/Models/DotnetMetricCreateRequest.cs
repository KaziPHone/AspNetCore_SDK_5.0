using System;

namespace MetricsAgent.DAL.Requests.Models
{
    public class DotnetMetricCreateRequest
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
    }
}
