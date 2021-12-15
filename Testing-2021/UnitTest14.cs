using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest14
    {
        private readonly string example;

        public UnitTest14()
        {
            example = new System.IO.StreamReader("Examples/Challange14/example14.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day14.Challange1.DoChallange(example);
            Assert.IsTrue(result == 1588, $"Incorrect result! Expected:1588, Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day14.Challange2.DoChallange(example);
            Assert.IsTrue(result == 2188189693529, $"Incorrect result! Expected:2188189693529, Got:{result}");
        }
    }
}