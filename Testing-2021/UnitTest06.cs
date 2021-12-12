using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest06
    {
        private readonly string example;
        private readonly AdventOfCode.Day06.Challange1 _challange1;
        private readonly AdventOfCode.Day06.Challange2 _challange2;

        public UnitTest06()
        {
            _challange1 = new();
            _challange2 = new();
            example = new System.IO.StreamReader("Examples/Challange06/example06.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = _challange1.DoChallange(example);
            Assert.IsTrue(result == 5934, $"Incorrect result! Expected:5934, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = _challange2.DoChallange(example);
            Assert.IsTrue(result == 26984457539, $"Incorrect result! Expected:26984457539, Got:{result}");
        }
    }
}