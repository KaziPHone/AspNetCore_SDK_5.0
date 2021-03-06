using System;
using System.Collections.Generic;
using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Requests.Models;
using MetricsAgent.DAL.Responses;
using MetricsAgent.DAL.Responses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {

        private readonly ILogger<HddMetricsController> _logger;
        private IHddMetricsRepository _repository;
        private readonly IMapper _mapper;

        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _repository.Create(new HddMetric
            {
                Time =  request.Time,
                Value = request.Value
            });
            return Ok();
        }

        

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug($"Контроллер Delete: delete id - {id} ");
            _repository.Delete(id);
            return Ok();
        }
 
        
        
        [HttpPost("update")]
        public IActionResult Update(int id)
        {
            return Ok();
        }
        
        

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }
            return Ok(response);
        }
        
        
        
        [HttpGet("get-by-id")]
        public IActionResult GetById()
        {
            return Ok();
        }



        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var metrics = _repository.GetAllBetweenTime(fromTime, toTime);
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }
            return Ok(response);
        }
    }
}
