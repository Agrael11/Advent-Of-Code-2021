using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest17
    {
        private readonly string example;

        public UnitTest17()
        {
            example = new System.IO.StreamReader("Examples/Challange17/example17.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day17.Challange1.DoChallange(example);
            Assert.IsTrue(result == 45, $"Incorrect result! Expected:45, Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day17.Challange2.DoChallange(example);
            Assert.IsTrue(result == 112, $"Incorrect result! Expected:112, Got:{result}");
        }
    }
}