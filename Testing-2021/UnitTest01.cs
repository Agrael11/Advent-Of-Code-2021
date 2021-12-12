using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest01
    {
        private readonly string example;
        private readonly AdventOfCode.Day01.Challange1 _challange1;
        private readonly AdventOfCode.Day01.Challange2 _challange2;

        public UnitTest01()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange01/example01.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 7, $"Incorrect result! Expected:7, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 5, $"Incorrect result! Expected:5, Got:{result}");
        }
    }
}