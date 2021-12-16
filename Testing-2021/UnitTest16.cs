using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Testing_2021
{
    [TestClass]
    public class UnitTest16
    {
        readonly List<(string example, int result1, ulong result2)> examples;

        public UnitTest16()
        {
            examples = new();
            foreach (string example in new System.IO.StreamReader("Examples/Challange16/examples16.txt").ReadToEnd().Split('\n'))
            {
                string[] data = example.Split(';');
                examples.Add((data[0], int.Parse(data[1]), ulong.Parse(data[2])));
            }
        }

        [TestMethod]
        public void TestPart1()
        {
            string wrongStringBuild = "Incorrect result! Expected: {";
            for (int i = 0; i < examples.Count; i++)
            {
                wrongStringBuild += examples[i].result1;
                if (i < examples.Count - 1) wrongStringBuild += ";";
            }
            wrongStringBuild += "}, Got: {";
            bool wrong = false;
            for (int i = 0; i < examples.Count; i++)
            {
                int result = AdventOfCode.Day16.Challange1.DoChallange(examples[i].example);
                wrong |= (result != examples[i].result1);
                wrongStringBuild += result;
                if (i < examples.Count - 1) wrongStringBuild += ";";
            }
            wrongStringBuild += "}";
            Assert.IsFalse(wrong, wrongStringBuild);
        }

        [TestMethod]
        public void TestPart2()
        {
            string wrongStringBuild = "Incorrect result! Expected: {";
            for (int i = 0; i < examples.Count; i++)
            {
                wrongStringBuild += examples[i].result2;
                if (i < examples.Count - 1) wrongStringBuild += ";";
            }
            wrongStringBuild += "}, Got: {";
            bool wrong = false;
            for (int i = 0; i < examples.Count; i++)
            {
                ulong result = AdventOfCode.Day16.Challange2.DoChallange(examples[i].example);
                wrong |= (result != examples[i].result2);
                wrongStringBuild += result;
                if (i < examples.Count - 1) wrongStringBuild += ";";
            }
            wrongStringBuild += "}";
            Assert.IsFalse(wrong, wrongStringBuild);
        }
    }
}