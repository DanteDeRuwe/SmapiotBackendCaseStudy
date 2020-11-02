using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmapiotCaseStudy.Core.Interfaces;
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
            _apiKey = configuration.GetSection("RequestDataCollector:APIKey").Value;
        }

        public async Task<IList<Request>> GetBy(int year, int month)
        {
            var response = await _client.GetAsync($"{year}/{month}?code={_apiKey}");

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var requestResponse = JsonConvert.DeserializeObject<RequestResponse>(content);
            return requestResponse.Requests;
        }

        public async Task<IList<Request>> GetBy(int year, int month, Guid subscription)
        {
            var requests = await GetBy(year, month);
            return requests.Where(r => r.SubscriptionId.Equals(subscription)).ToList();
        }
    }

    public class RequestResponse
    {
        public IList<Request> Requests;
    }
}