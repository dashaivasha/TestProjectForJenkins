using KellermanSoftware.CompareNetObjects;
using System.Collections.Generic;


namespace JsonplaceholderTypicodeTests.TestData.Utilities
{
    public static class CompareHelper
    {
        public static bool Compare(object expected, object actual, string[] itemForIngnoring)
        {
            var compareObjects = new CompareObjects()
            {
                ElementsToIgnore = new List<string>(itemForIngnoring)
            };

            return compareObjects.Compare(expected, actual);
        }
    }
}
