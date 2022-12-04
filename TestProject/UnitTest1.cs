namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int a = 2;
            int b = 2;
            int result = 4;
            Assert.That(a+b,Is.EqualTo(result));
        }
    }
}