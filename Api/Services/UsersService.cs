using JsonplaceholderTypicodeTests.Api.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JsonplaceholderTypicodeTests.Api.Services
{
    internal class UsersService : Service
    {
        public UsersService()
        {
        }

        public async Task<User?> GetUserAsync(int id) =>
        await _httpClient.GetFromJsonAsync<User>(
        $"users/{id}");

        public HttpStatusCode GetUserStatusCode(int id)
        {
            var statusCode = _httpClient.GetAsync($"users/{id}").Result.StatusCode;

            return statusCode;
        }


        public HttpResponseMessage GetUsersResponse()
        {
            var response = _httpClient.GetAsync($"users").Result;

            return response;
        }
    }
}
