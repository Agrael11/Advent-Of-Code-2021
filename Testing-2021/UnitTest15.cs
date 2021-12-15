using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest15
    {
        private readonly string example;

        public UnitTest15()
        {
            example = new System.IO.StreamReader("Examples/Challange15/example15.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day15.Challange1.DoChallange(example);
            Assert.IsTrue(result == 40, $"Incorrect result! Expected:40, Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day15.Challange2.DoChallange(example);
            Assert.IsTrue(result == 315, $"Incorrect result! Expected:315, Got:{result}");
        }
    }
}