using AutoMapper;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Responses.Models;

namespace MetricsAgent.DAL.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<DotnetMetric, DotnetMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();
        }
    }
}
