﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotnetMetricsController : ControllerBase
    {

        private readonly ILogger<DotnetMetricsController> _logger;
        private IDotnetMetricsRepository _repository;
        private readonly IMapper _mapper;

        public DotnetMetricsController(ILogger<DotnetMetricsController> logger, IDotnetMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        
        
        [HttpPost("create")]
        public IActionResult Create([FromBody] DotnetMetricCreateRequest request)
        {
            _repository.Create(new DotnetMetric
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
            var response = new AllDotnetMetricsResponse()
            {
                Metrics = new List<DotnetMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotnetMetricDto>(metric));
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
            return Ok();
        }
    }
}
