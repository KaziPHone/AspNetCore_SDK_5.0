using System;

namespace MetricsAgent.DAL.Responses.Models
{
    public class DotnetMetricDto
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
