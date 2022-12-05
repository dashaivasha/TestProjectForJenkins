using JsonplaceholderTypicodeTests.Api.Models;
using JsonplaceholderTypicodeTests.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace JsonplaceholderTypicodeTests.TestData
{
    public class JsonManager
    {
        public static string GetTestData(string key)
        {
            var json = File.ReadAllText(FilePaths.DataPath);
            var data = (JObject)JsonConvert.DeserializeObject(json);
            var result = data[key].Value<string>();

            return result;
        }

        public static PostModel GetPostFromJson()
        {
            var json = File.ReadAllText(FilePaths.PostPath);
            var post = JsonConvert.DeserializeObject<PostModel>(json);

            return post;
        }

        public static User GetUserFromJson()
        {
            var json = File.ReadAllText(FilePaths.UserPath);
            var user = JsonConvert.DeserializeObject<User>(json);

            return user;
        }

        public static PostModel GetResposeBody(string result)
        {
            PostModel post = JsonConvert.DeserializeObject<PostModel>(result);

            return post;
        }

        public static IEnumerable<PostModel> GetPostModelsFromJson(string result)
        {
            var posts = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(result);

            return posts;
        }

        public static IEnumerable<User> GetUserModelsFromJson(string result)
        {
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(result);

            return users;
        }
    }
}
