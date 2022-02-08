using MetricsAgent.DAL.Interfaces;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class DotnetMetricsControllerUnitTests
    {

        private DotnetMetricsController _controller;
        private Mock<IDotnetMetricsRepository> _mockRepository;
        private Mock<ILogger<DotnetMetricsController>> _mockLogger;

        public DotnetMetricsControllerUnitTests()
        {
            _mockRepository = new Mock<IDotnetMetricsRepository>();
            _mockLogger = new Mock<ILogger<DotnetMetricsController>>();
            _controller = new DotnetMetricsController(_mockLogger.Object, _mockRepository.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            var result = _controller.GetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
