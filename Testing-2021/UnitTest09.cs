using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest09
    {
        private readonly string example;

        public UnitTest09()
        {
            example = new System.IO.StreamReader("Examples/Challange09/example09.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day09.Challange1.DoChallange(example);
            Assert.IsTrue(result == 15, $"Incorrect result! Expected:15, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day09.Challange2.DoChallange(example);
            Assert.IsTrue(result == 1134, $"Incorrect result! Expected:1134, Got:{result}");
        }
    }
}