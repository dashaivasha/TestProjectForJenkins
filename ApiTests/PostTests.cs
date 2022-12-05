using JsonplaceholderTypicodeTests.Api.Models;
using JsonplaceholderTypicodeTests.Constants;
using JsonplaceholderTypicodeTests.TestData;
using JsonplaceholderTypicodeTests.TestData.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using static JsonplaceholderTypicodeTests.Constants.Keys;

namespace JsonplaceholderTypicodeTests.ApiTests
{
    [TestFixture]
    internal class PostTests : BaseTest
    {

        [Test]
        public void GetPosts()
        {
            HttpResponseMessage postsResponse = postService.GetPostsResponse();
            string postsTxt = postsResponse.Content.ReadAsStringAsync().Result;
            IEnumerable<PostModel> posts = JsonManager.GetPostModelsFromJson(postsTxt);
            Assert.AreEqual(HttpStatusCode.OK, postsResponse.StatusCode, "Actual status code is not the same as expected");
            var correctContentType = JsonManager.GetTestData(DataKey.ContentType.GetDescription());
            Assert.AreEqual(postsResponse.Content.Headers.ContentType.MediaType, correctContentType, "Response content type not in json format");
            Assert.That(posts, Is.Ordered.By("Id"), "List is not ordered by Id");
        }

        [Test]
        public void GetPostById()
        {
            var expectedPost = JsonManager.GetPostFromJson();
            var post = postService.GetPostAsync(expectedPost.Id).Result;
            Assert.IsTrue(CompareHelper.Compare(expectedPost, post, new string[] { IgnoreItem.Body.GetDescription(), IgnoreItem.Title.GetDescription() }), "Object fields do not match");
            Assert.That(post.Body, Is.Not.Empty, "Id value is Empty");
            Assert.That(post.Title, Is.Not.Empty, "Id value is Empty");
        }

        [Test]
        public void GetPostByNotExistingId()
        {
            var notExistingId = Convert.ToInt32(JsonManager.GetTestData(DataKey.NotExistingPostId.GetDescription()));
            HttpStatusCode postStatusCode = postService.GetPostResponseCode(notExistingId);
            Assert.AreEqual(HttpStatusCode.NotFound, postStatusCode, "Actual status code is not the same as expected");
        }

        [Test]
        public void PostPost()
        {
            postToPost.UserId = Convert.ToInt32(JsonManager.GetTestData(DataKey.userIdForPostPost.GetDescription()));
            postToPost.Body = StringGenerator.RandomString();
            postToPost.Title = StringGenerator.RandomString();
            HttpResponseMessage responseMessage = postService.PostPostModel(postToPost);
            Assert.AreEqual(HttpStatusCode.Created, responseMessage.StatusCode, "Actual status code is not the same as expected");
            PostModel currentPost = JsonManager.GetResposeBody(postService.PostPostModel(postToPost).Content.ReadAsStringAsync().Result);
            Assert.IsTrue(CompareHelper.Compare(postToPost, currentPost, new string[] { IgnoreItem.Id.GetDescription() }), "Object fields do not match");
            Assert.That(currentPost.Id, Is.Not.Null, "Id value is Null");
        }

    }
}
