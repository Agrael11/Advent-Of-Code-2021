using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest13
    {
        private readonly string example;
        private readonly string exampleResult;

        public UnitTest13()
        {
            example = new System.IO.StreamReader("Examples/Challange13/example13.txt").ReadToEnd();
            exampleResult = new System.IO.StreamReader("Examples/Challange13/example13result.txt").ReadToEnd().Replace("\r","");
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day13.Challange1.DoChallange(example);
            Assert.IsTrue(result == 17, $"Incorrect result! Expected:17, Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day13.Challange2.DoChallange(example);
            Assert.IsTrue(result == exampleResult, $"Incorrect result!");
        }
    }
}