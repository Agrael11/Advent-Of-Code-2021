using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest22
    {
        private readonly string example1;
        private readonly string example2;
        private readonly string example3;

        public UnitTest22()
        {
            example1 = new System.IO.StreamReader("Examples/Challange22/example22a.txt").ReadToEnd();
            example2 = new System.IO.StreamReader("Examples/Challange22/example22b.txt").ReadToEnd();
            example3 = new System.IO.StreamReader("Examples/Challange22/example22c.txt").ReadToEnd();
        }

        [TestMethod]
        public void TestPart1()
        {
            var result1 = AdventOfCode.Day22.Challange1.DoChallange(example1);
            var result2 = AdventOfCode.Day22.Challange1.DoChallange(example2);
            var result3 = AdventOfCode.Day22.Challange1.DoChallange(example3);
            bool okay = true;
            string wrongString = "Incorrect result(s)! ";
            if (result1 != 474140)
            {
                wrongString += $"Expected:474140 Got:{result1}. ";
                okay = false;
            }
            if (result2 != 19)
            {
                wrongString += $"Expected:19 Got:{result2}. ";
                okay = false;
            }
            if (result3 != 75)
            {
                wrongString += $"Expected:75 Got:{result3}. ";
                okay = false;
            }
            Assert.IsTrue(okay, wrongString);
        }

        [TestMethod]
        public void TestPart2()
        {
            var result1 = AdventOfCode.Day22.Challange2.DoChallange(example1);
            var result2 = AdventOfCode.Day22.Challange2.DoChallange(example2);
            var result3 = AdventOfCode.Day22.Challange2.DoChallange(example3);
            bool okay = true;
            string wrongString = "Incorrect result(s)! ";
            if (result1 != 2758514936282235)
            {
                wrongString += $"Expected:2758514936282235 Got:{result1}. ";
                okay = false;
            }
            if (result2 != 19)
            {
                wrongString += $"Expected:19 Got:{result2}. ";
                okay = false;
            }
            if (result3 != 75)
            {
                wrongString += $"Expected:75 Got:{result3}. ";
                okay = false;
            }
            Assert.IsTrue(okay, wrongString);
        }
    }
}