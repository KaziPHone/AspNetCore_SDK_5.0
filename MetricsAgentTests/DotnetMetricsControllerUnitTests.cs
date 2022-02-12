using System;
using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Requests.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class DotnetMetricsControllerUnitTests
    {

        private DotnetMetricsController _controller;
        private Mock<IDotnetMetricsRepository> _mockRepository;
        private Mock<ILogger<DotnetMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;
        private Mock<DotnetMetricCreateRequest> _mockRequest;

        public DotnetMetricsControllerUnitTests()
        {
            _mockRepository = new Mock<IDotnetMetricsRepository>();
            _mockLogger = new Mock<ILogger<DotnetMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _mockRequest = new Mock<DotnetMetricCreateRequest>();
            _controller = new DotnetMetricsController(_mockLogger.Object, _mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            var result = _controller.GetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        
        [Fact]
        public void Test_Create_ReturnsOk()
        {
            var result = _controller.Create(_mockRequest.Object);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Test_Delete_Returns_Ok()
        {
            var id = 0;
            var result = _controller.Delete(id);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        
        [Fact]
        public void Test_Update_Returns_Ok()
        {
            var id = 0;
            var result = _controller.Update(id);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        
        [Fact]
        public void Test_Get_All_Returns_Ok()
        {
            var result = _controller.GetAll();
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        
        [Fact]
        public void Test_Get_By_Id_Returns_Ok()
        {
            var result = _controller.GetById();
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
