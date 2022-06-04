using FridgeManager.Domain;
using FridgeManager.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FridgeManager.Tests.IntegrationTests
{
    public class FridgesControllerTests
    {
        [Fact]
        public async Task GetAll_SendRequest_ReturnOk()
        {
            // Arrange
            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            // Act
            HttpResponseMessage response = await httpClient.GetAsync("api/Fridges/GetAll");

            // Asserts
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
