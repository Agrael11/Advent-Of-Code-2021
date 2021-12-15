using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest12
    {
        private readonly string example1;
        private readonly string example2;
        private readonly string example3;

        public UnitTest12()
        {
            example1 = new System.IO.StreamReader("Examples/Challange12/example12a.txt").ReadToEnd();
            example2 = new System.IO.StreamReader("Examples/Challange12/example12b.txt").ReadToEnd();
            example3 = new System.IO.StreamReader("Examples/Challange12/example12c.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1Small()
        {
            var result = AdventOfCode.Day12.Challange1.DoChallange(example1);
            Assert.IsTrue(result == 10, $"Incorrect result! Expected:10, Got:{result}");
        }

        [TestMethod]
        public void TestPart1Medium()
        {
            var result = AdventOfCode.Day12.Challange1.DoChallange(example2);
            Assert.IsTrue(result == 19, $"Incorrect result! Expected:19, Got:{result}");
        }

        [TestMethod]
        public void TestPart1Big()
        {
            int result = AdventOfCode.Day12.Challange1.DoChallange(example3);
            Assert.IsTrue(result == 226, $"Incorrect result! Expected:226, Got:{result}");
        }


        [TestMethod]
        public void TestPart2Small()
        {
            ulong result = AdventOfCode.Day12.Challange2.DoChallange(example1);
            Assert.IsTrue(result == 36, $"Incorrect result! Expected:36, Got:{result}");
        }

        [TestMethod]
        public void TestPart2Medium()
        {
            ulong result = AdventOfCode.Day12.Challange2.DoChallange(example2);
            Assert.IsTrue(result == 103, $"Incorrect result! Expected:103, Got:{result}");
        }

        [TestMethod]
        public void TestPart2Big()
        {
            ulong result = AdventOfCode.Day12.Challange2.DoChallange(example3);
            Assert.IsTrue(result == 3509, $"Incorrect result! Expected:3509, Got:{result}");
        }
    }
}