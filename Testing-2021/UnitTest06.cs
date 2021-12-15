using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest06
    {
        private readonly string example;

        public UnitTest06()
        {
            example = new System.IO.StreamReader("Examples/Challange06/example06.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day06.Challange1.DoChallange(example);
            Assert.IsTrue(result == 5934, $"Incorrect result! Expected:5934, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day06.Challange2.DoChallange(example);
            Assert.IsTrue(result == 26984457539, $"Incorrect result! Expected:26984457539, Got:{result}");
        }
    }
}