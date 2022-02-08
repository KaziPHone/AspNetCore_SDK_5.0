using MetricsAgent.DAL.Interfaces;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;
        private Mock<ICpuMetricsRepository> _mockRepositore;
        private Mock<ILogger<CpuMetricsController>> _mockLogger;

        public CpuMetricsControllerUnitTests()
        {
            _mockRepositore = new Mock<ICpuMetricsRepository>();
            _mockLogger = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(_mockLogger.Object, _mockRepositore.Object);
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
