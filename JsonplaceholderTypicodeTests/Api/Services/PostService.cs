using JsonplaceholderTypicodeTests.Api.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JsonplaceholderTypicodeTests.Api.Services
{
    public class PostService : Service
    {
        public PostService()
        {
        }

        public async Task<PostModel?> GetPostAsync(int id) =>
        await _httpClient.GetFromJsonAsync<PostModel>(
        $"posts/{id}");

        public HttpStatusCode GetPostResponseCode(int id)
        {
            var statusCode = _httpClient.GetAsync($"posts/{id}").Result.StatusCode;

            return statusCode;
        }

        public HttpResponseMessage GetPostsResponse()
        {
            var response = _httpClient.GetAsync($"posts").Result;

            return response;
        }

        public HttpResponseMessage PostPostModel(PostModel post)
        {

            var responseMessage = _httpClient.PostAsJsonAsync($"posts/", post).Result;

            return responseMessage;
        }
    }

}
