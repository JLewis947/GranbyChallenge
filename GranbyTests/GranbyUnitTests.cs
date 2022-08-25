namespace GranbyTests
{
    public class GranbyUnitTests
    {

        [Fact]
        public void TestHelloMethod()
        {
            GranbyTestClass testClass = new GranbyTestClass();
            string testString = testClass.GetHello();
            Assert.True(testString == "Hello");
        }
    }
}