using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest01
    {
        private readonly string example;

        public UnitTest01()
        {
            example = new System.IO.StreamReader("Examples/Challange01/example01.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day01.Challange1.DoChallange(example);
            Assert.IsTrue(result == 7, $"Incorrect result! Expected:7, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day01.Challange2.DoChallange(example);
            Assert.IsTrue(result == 5, $"Incorrect result! Expected:5, Got:{result}");
        }
    }
}