using MetricsAgent.DAL.Interfaces;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTests
    {

        private RamMetricsController _controller;
        private Mock<IRamMetricsRepository> _mockRepositore;
        private Mock<ILogger<RamMetricsController>> _mockLogger;

        public RamMetricsControllerUnitTests()
        {
            _mockRepositore = new Mock<IRamMetricsRepository>();
            _mockLogger = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(_mockLogger.Object, _mockRepositore.Object);
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
