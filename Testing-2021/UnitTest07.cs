using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest07
    {
        private readonly string example;

        public UnitTest07()
        {
            example = new System.IO.StreamReader("Examples/Challange07/example07.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day07.Challange1.DoChallange(example);
            Assert.IsTrue(result == 37, $"Incorrect result! Expected:37, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day07.Challange2.DoChallange(example);
            Assert.IsTrue(result == 168, $"Incorrect result! Expected:168, Got:{result}");
        }
    }
}