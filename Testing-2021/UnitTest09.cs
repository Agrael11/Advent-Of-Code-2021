using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest09
    {
        private readonly string example;
        private readonly AdventOfCode.Day09.Challange1 _challange1;
        private readonly AdventOfCode.Day09.Challange2 _challange2;

        public UnitTest09()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange09/example09.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 15, $"Incorrect result! Expected:15, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 1134, $"Incorrect result! Expected:1134, Got:{result}");
        }
    }
}