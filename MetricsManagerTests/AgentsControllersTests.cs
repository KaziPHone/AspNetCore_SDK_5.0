using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Controllers;
using MetricsManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllersTests
    {
        private AgentsController _controller;
        private AgentInfo agentInfo;

        public AgentsControllersTests()
        {
            _controller = new AgentsController();
            agentInfo = new AgentInfo();
        }


        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            var result = _controller.RegisterAgent(agentInfo);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            var agentId = 1;
            var result = _controller.EnableAgentById(agentId);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            var agentId = 1;
            var result = _controller.EnableAgentById(agentId);
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
