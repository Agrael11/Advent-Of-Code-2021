using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest10
    {
        private readonly string example;

        public UnitTest10()
        {
            example = new System.IO.StreamReader("Examples/Challange10/example10.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day10.Challange1.DoChallange(example);
            Assert.IsTrue(result == 26397, $"Incorrect result! Expected:26397, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day10.Challange2.DoChallange(example);
            Assert.IsTrue(result == 288957, $"Incorrect result! Expected:288957, Got:{result}");
        }
    }
}