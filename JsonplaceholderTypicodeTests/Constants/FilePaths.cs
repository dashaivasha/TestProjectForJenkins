﻿using System.IO;

namespace JsonplaceholderTypicodeTests.Constants
{
    static class FilePaths
    {
        public static readonly string _projectDirectory = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        public static readonly string DataPath = Path.Combine("TestData", "Resources", "TestData.json");
        public static readonly string PostPath = Path.Combine("TestData", "Resources", "Post.json");
        public static readonly string UserPath = Path.Combine("TestData", "Resources", "User.json");
    }
}
 