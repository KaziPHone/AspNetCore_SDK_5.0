using MetricsAgent.DAL.Interfaces;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class NetworkMetricsControllerUnitTests
    {

        private NetworkMetricsController _controller;
        private Mock<INetworkMetricsRepository> _mockRepositore;
        private Mock<ILogger<NetworkMetricsController>> _mockLogger;

        public NetworkMetricsControllerUnitTests()
        {
            _mockRepositore = new Mock<INetworkMetricsRepository>();
            _mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            _controller = new NetworkMetricsController(_mockLogger.Object, _mockRepositore.Object);
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
