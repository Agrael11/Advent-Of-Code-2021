using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest14
    {
        private readonly string example;
        private readonly AdventOfCode.Day14.Challange1 _challange1;
        private readonly AdventOfCode.Day14.Challange2 _challange2;

        public UnitTest14()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange14/example14.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 1588, $"Incorrect result! Expected:1588, Got:{result}");
        }

        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 2188189693529, $"Incorrect result! Expected:2188189693529, Got:{result}");
        }
    }
}