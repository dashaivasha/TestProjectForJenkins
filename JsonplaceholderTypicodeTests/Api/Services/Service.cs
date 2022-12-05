using JsonplaceholderTypicodeTests.Api.Client;
using JsonplaceholderTypicodeTests.TestData;
using System;
using System.Net.Http;
using static JsonplaceholderTypicodeTests.Constants.Keys;

namespace JsonplaceholderTypicodeTests.Api.Services
{
    public class Service
    {
        private protected HttpClient _httpClient = HttpClientFactory.GetHttpClient();

        public Service()
        {

            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(JsonManager.GetTestData(DataKey.Url.GetDescription()));
            }

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
