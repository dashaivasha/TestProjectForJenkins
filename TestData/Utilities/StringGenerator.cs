using System;
using System.Linq;
using static JsonplaceholderTypicodeTests.Constants.Keys;

namespace JsonplaceholderTypicodeTests.TestData.Utilities
{
    internal class StringGenerator
    {
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString()
        {
            var length = Convert.ToInt32(JsonManager.GetTestData(DataKey.RandomStringLength.GetDescription()));
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
