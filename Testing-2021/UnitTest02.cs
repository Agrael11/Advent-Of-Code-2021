using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest02
    {
        private readonly string example;
        private readonly AdventOfCode.Day02.Challange1 _challange1;
        private readonly AdventOfCode.Day02.Challange2 _challange2;

        public UnitTest02()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange02/example02.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 150, $"Incorrect result! Expected:150, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 900, $"Incorrect result! Expected:900, Got:{result}");
        }
    }
}