using JsonplaceholderTypicodeTests.Api.Models;
using JsonplaceholderTypicodeTests.TestData;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static JsonplaceholderTypicodeTests.Constants.Keys;

namespace JsonplaceholderTypicodeTests.ApiTests
{
    [TestFixture]
    internal class UsersTests : BaseTest
    {
        [Test]
        public void GetUsers()
        {
            var usersResponse = userService.GetUsersResponse();
            string usersTxt = usersResponse.Content.ReadAsStringAsync().Result;
            IEnumerable<User> users = JsonManager.GetUserModelsFromJson(usersTxt);
            Assert.AreEqual(HttpStatusCode.OK, usersResponse.StatusCode, "Actual status code is not the same as expected");
            var correctContentType = JsonManager.GetTestData(DataKey.ContentType.GetDescription());
            Assert.AreEqual(usersResponse.Content.Headers.ContentType.MediaType, correctContentType, "Response content type not in json format");
            var expectedUser = JsonManager.GetUserFromJson();
            var actualUser = users.ToList().FirstOrDefault(user => user.Id == expectedUser.Id);
            Assert.IsTrue(expectedUser.Equals(actualUser), "Expected user data doesn't match the actual data");
        }

        [Test]
        public void GetUserById()
        {
            var expectedUser = JsonManager.GetUserFromJson();
            var userStatusCode = userService.GetUserStatusCode(expectedUser.Id);
            Assert.AreEqual(HttpStatusCode.OK, userStatusCode, "Actual status code is not the same as expected");
            var actualUser = userService.GetUserAsync(expectedUser.Id).Result;
            Assert.IsTrue(expectedUser.Equals(actualUser), "Expected user data doesn't match the actual data");
        }
    }
}
