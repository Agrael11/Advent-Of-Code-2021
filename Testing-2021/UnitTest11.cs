using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest11
    {
        private readonly string example;

        public UnitTest11()
        {
            example = new System.IO.StreamReader("Examples/Challange11/example11.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day11.Challange1.DoChallange(example);
            Assert.IsTrue(result == 1656, $"Incorrect result! Expected:1656, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day11.Challange2.DoChallange(example);
            Assert.IsTrue(result == 195, $"Incorrect result! Expected:195, Got:{result}");
        }
    }
}