using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest02
    {
        private readonly string example;

        public UnitTest02()
        {
            example = new System.IO.StreamReader("Examples/Challange02/example02.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day02.Challange1.DoChallange(example);
            Assert.IsTrue(result == 150, $"Incorrect result! Expected:150, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day02.Challange2.DoChallange(example);
            Assert.IsTrue(result == 900, $"Incorrect result! Expected:900, Got:{result}");
        }
    }
}