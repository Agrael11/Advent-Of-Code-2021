using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest20
    {
        private readonly string example;

        public UnitTest20()
        {
            example = new System.IO.StreamReader("Examples/Challange20/example20.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day20.Challange1.DoChallange(example);
            Assert.IsTrue(result == 35, $"Incorrect result! Expected:35 Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day20.Challange2.DoChallange(example);
            Assert.IsTrue(result == 3351, $"Incorrect result! Expected:3351, Got:{result}");
        }
    }
}