using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest04
    {
        private readonly string example;
        private readonly AdventOfCode.Day04.Challange1 _challange1;
        private readonly AdventOfCode.Day04.Challange2 _challange2;

        public UnitTest04()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange04/example04.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 4512, $"Incorrect result! Expected:4512, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 1924, $"Incorrect result! Expected:1924, Got:{result}");
        }
    }
}