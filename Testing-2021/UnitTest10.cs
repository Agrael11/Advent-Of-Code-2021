using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest10
    {
        private readonly string example;
        private readonly AdventOfCode.Day10.Challange1 _challange1;
        private readonly AdventOfCode.Day10.Challange2 _challange2;

        public UnitTest10()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange10/example10.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 26397, $"Incorrect result! Expected:26397, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 288957, $"Incorrect result! Expected:288957, Got:{result}");
        }
    }
}