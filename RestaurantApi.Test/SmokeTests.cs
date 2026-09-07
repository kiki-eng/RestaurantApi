using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Restaurant.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace RestaurantApi.Test
{
    public class SmokeTests : IClassFixture<WebApplicationFactory<Program>>

    {
        private readonly HttpClient _client;
        public SmokeTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Api_Should_Start_And_Respond()
        {

            var response = await _client.GetAsync("/swagger/index.html");


            Assert.NotNull(response);

        }

        [Fact]

        public async Task Register_Endpoint_Should_Return_Ok()
        {
            //Arrange

            var request = new RegisterUserRequest
            {
                Name = "Smoke Test User",
                Email = $"smoketest{Guid.NewGuid()}@example.com",
                Password = "Password123!",
                Location = "Toronto"
            };

            var response = await _client.PostAsJsonAsync(
                 "/api/User/register", request
            );

            Assert.Equal(HttpStatusCode.OK,
              response.StatusCode);
        }


    }
}   
