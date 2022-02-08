using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        public RamMetricsControllerUnitTests()
        {
            _controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {

            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            Console.WriteLine(fromTime);
           
            var toTime = TimeSpan.FromSeconds(100);
            Console.WriteLine(toTime);
            //Act
            var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
