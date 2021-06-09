using NUnit.Framework;

namespace test
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
            Assert.Equals(1, 2);
            Assert.Pass();
        }
    }
}