using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest21
    {
        private readonly string example;

        public UnitTest21()
        {
            example = new System.IO.StreamReader("Examples/Challange21/example21.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day21.Challange1.DoChallange(example);
            Assert.IsTrue(result == 739785, $"Incorrect result! Expected:739785 Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day21.Challange2.DoChallange(example);
            Assert.IsTrue(result == 444356092776315, $"Incorrect result! Expected:444356092776315, Got:{result}");
        }
    }
}