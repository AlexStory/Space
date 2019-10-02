using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SpaceX.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Web;

namespace SpaceX.LaunchpadService
{
    public class WebLaunchpadService : ILaunchpadService
    {
        private IConfiguration _config;
        private HttpClient _client;
        private readonly ILogger<WebLaunchpadService> _logger;

        public WebLaunchpadService(IConfiguration config,
            HttpClient client,
            ILogger<WebLaunchpadService> logger)
        {
            _config = config;
            _logger = logger;
            _client = client;
        }

        public async Task<List<Launchpad>> Get(int limit = 0, int offset = 0)
        {
            try
            {
                var query = HttpUtility.ParseQueryString("");

                if (limit > 0)
                {
                    query["limit"] = limit.ToString();
                }

                if (offset > 0)
                {
                    query["offset"] = offset.ToString();
                }

                _logger.LogInformation($"Query: {query}");
                var result = await _client.GetAsync(_config["WebApi:Url"] + "?" + query);
                var resultString = await result.Content.ReadAsStringAsync();
                var resultOjbect = JsonConvert.DeserializeObject<List<Launchpad>>(resultString);
                //_logger.LogInformation(resultOjbect[0].Name);
                return resultOjbect;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Launchpad> Get(string id)
        {
            try
            {
                var result = await _client.GetAsync(id);
                var resultString = await result.Content.ReadAsStringAsync();
                var resultObject = JsonConvert.DeserializeObject<Launchpad>(resultString);
                return resultObject;
            }
            catch
            {
                throw;
            }
        }
    }
}
