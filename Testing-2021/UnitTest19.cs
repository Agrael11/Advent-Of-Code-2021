using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest19
    {
        private readonly string example;

        public UnitTest19()
        {
            example = new System.IO.StreamReader("Examples/Challange19/example19.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day19.Challange1.DoChallange(example);
            Assert.IsTrue(result == 79, $"Incorrect result! Expected:79, Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day19.Challange2.DoChallange(example);
            Assert.IsTrue(result == 3621, $"Incorrect result! Expected:3621, Got:{result}");
        }
    }
}