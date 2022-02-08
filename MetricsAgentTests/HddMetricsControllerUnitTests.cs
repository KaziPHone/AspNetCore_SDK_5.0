using MetricsAgent.DAL.Interfaces;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;
        private Mock<IHddMetricsRepository> _mockRepositore;
        private Mock<ILogger<HddMetricsController>> _mockLogger;

        public HddMetricsControllerUnitTests()
        {
            _mockRepositore = new Mock<IHddMetricsRepository>();
            _mockLogger = new Mock<ILogger<HddMetricsController>>();
            _controller = new HddMetricsController(_mockLogger.Object, _mockRepositore.Object);
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
