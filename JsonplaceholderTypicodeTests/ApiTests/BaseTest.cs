using JsonplaceholderTypicodeTests.Api.Models;
using JsonplaceholderTypicodeTests.Api.Services;
using NUnit.Framework;

namespace JsonplaceholderTypicodeTests.ApiTests
{
    public class BaseTest
    {
        private PostService? _postService;
        private protected PostService postService => _postService ??= new PostService();

        private UsersService? _userService;
        private protected UsersService userService => _userService ??= new UsersService();

        private protected PostModel postToPost = new PostModel();

        [OneTimeSetUp]
        public void Open()
        {

        }
    }
}
