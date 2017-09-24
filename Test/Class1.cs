using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessJudger;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void T1()
        {
            List<int[]> chess=new List<int[]>()
            {
                new [] {4,4},
                new [] {4,5},
                new [] {5,5},
                new [] {6,5},
                new [] {7,5},
                new [] {7,6},
            };
            var provider = new ChessValidatorDataProvider(chess);
            provider.WriteAllTrainingDatas(@"D:\broad\123.csv");
        }
    }
}
