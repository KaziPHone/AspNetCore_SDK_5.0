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
    public class NetworkMetricsControllerUnitTests
    {

        private NetworkMetricsController _controller;
        private Mock<INetworkMetricsRepository> _mockRepositore;
        private Mock<ILogger<NetworkMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;
        private Mock<NetworkMetricCreateRequest> _mockRequest;
        
        public NetworkMetricsControllerUnitTests()
        {
            _mockRepositore = new Mock<INetworkMetricsRepository>();
            _mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _mockRequest = new Mock<NetworkMetricCreateRequest>();
            _controller = new NetworkMetricsController(_mockLogger.Object, _mockRepositore.Object, _mockMapper.Object);
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
