using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest11
    {
        private readonly string example;
        private readonly AdventOfCode.Day11.Challange1 _challange1;
        private readonly AdventOfCode.Day11.Challange2 _challange2;

        public UnitTest11()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange11/example11.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 1656, $"Incorrect result! Expected:1656, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 195, $"Incorrect result! Expected:195, Got:{result}");
        }
    }
}