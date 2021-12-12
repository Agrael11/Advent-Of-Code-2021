using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest05
    {
        private readonly string example;
        private readonly AdventOfCode.Day05.Challange1 _challange1;
        private readonly AdventOfCode.Day05.Challange2 _challange2;

        public UnitTest05()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange05/example05.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 5, $"Incorrect result! Expected:5, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 12, $"Incorrect result! Expected:12, Got:{result}");
        }
    }
}