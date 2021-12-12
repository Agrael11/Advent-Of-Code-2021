using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest03
    {
        private readonly string example;
        private readonly AdventOfCode.Day03.Challange1 _challange1;
        private readonly AdventOfCode.Day03.Challange2 _challange2;

        public UnitTest03()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange03/example03.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 198, $"Incorrect result! Expected:198, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 230, $"Incorrect result! Expected:230, Got:{result}");
        }
    }
}