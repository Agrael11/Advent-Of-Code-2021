using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest08
    {
        private readonly string example;
        private readonly AdventOfCode.Day08.Challange1 _challange1;
        private readonly AdventOfCode.Day08.Challange2 _challange2;

        public UnitTest08()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange08/example08.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 26, $"Incorrect result! Expected:26, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 61229, $"Incorrect result! Expected:61229, Got:{result}");
        }
    }
}