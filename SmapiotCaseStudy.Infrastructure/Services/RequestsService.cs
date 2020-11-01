using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmapiotCaseStudy.Application.Interfaces;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Infrastructure.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public RequestsService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _client = clientFactory.CreateClient("smapiotRequestDataCollector");
            _apiKey = configuration["RequestDataCollectorAPIKey"];
        }

        public async Task<IList<Request>> GetBy(int year, int month)
        {
            var response = await _client.GetAsync($"{year}/{month}?code={_apiKey}");

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var requestResponse = JsonConvert.DeserializeObject<RequestResponse>(content);
            return requestResponse.Requests;
        }

        public Task<IList<Request>> GetBy(int year, int month, string subscription)
        {
            throw new NotImplementedException();
        }
    }

    public class RequestResponse
    {
        public IList<Request> Requests;
    }
}