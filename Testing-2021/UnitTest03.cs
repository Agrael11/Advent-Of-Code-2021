using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest03
    {
        private readonly string example;

        public UnitTest03()
        {
            example = new System.IO.StreamReader("Examples/Challange03/example03.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result = AdventOfCode.Day03.Challange1.DoChallange(example);
            Assert.IsTrue(result == 198, $"Incorrect result! Expected:198, Got:{result}");
        }


        [TestMethod]
        public void TestPart2()
        {
            var result = AdventOfCode.Day03.Challange2.DoChallange(example);
            Assert.IsTrue(result == 230, $"Incorrect result! Expected:230, Got:{result}");
        }
    }
}