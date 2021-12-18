using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest18
    {
        private readonly string example;

        public UnitTest18()
        {
            example = new System.IO.StreamReader("Examples/Challange18/example18.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day18.Challange1.DoChallange(example);
            Assert.IsTrue(result == 4140, $"Incorrect result! Expected:45, Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day18.Challange2.DoChallange(example);
            Assert.IsTrue(result == 3993, $"Incorrect result! Expected:112, Got:{result}");
        }
    }
}