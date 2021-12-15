using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest04
    {
        private readonly string example;

        public UnitTest04()
        {
            example = new System.IO.StreamReader("Examples/Challange04/example04.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day04.Challange1.DoChallange(example);
            Assert.IsTrue(result == 4512, $"Incorrect result! Expected:4512, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day04.Challange2.DoChallange(example);
            Assert.IsTrue(result == 1924, $"Incorrect result! Expected:1924, Got:{result}");
        }
    }
}