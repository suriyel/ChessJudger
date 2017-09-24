using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace ChessJudger
{
    public interface IDataWriter
    {
        void Write(string filePath,int[,] oriChessBorad,int[,] chess,bool isValid);
    }

    public class DataWriter: IDataWriter
    {
        public void Write(
            string fileName,
            int[,] oriChessBorad,
            int[,] chess,
            bool isValid)
        {
            JObject o = new JObject();
            JArray trainingData = new JArray();
            SetMatrix(trainingData, oriChessBorad);
            SetMatrix(trainingData, chess);
            trainingData.Add(isValid);
            o.Add("tranningData", trainingData);

            using (var sw = new StreamWriter(fileName, true))
            {
                sw.Write(o.ToString());
            }
        }

        private void SetMatrix(JArray ja, int[,] matrix)
        {
            List<int> result=new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result.Add(matrix[i,j]);
                }
            }

            ja.Add(String.Join(",", result));
        }

        private static int Count = 0;

        //private string GetFilePath(string dirPath)
        //{
        //    var filePath = Path.Combine(dirPath, string.Format("{0}.csv", Count));
        //    while (File.Exists(filePath))
        //    {
        //        Count++;
        //        filePath = Path.Combine(dirPath, string.Format("{0}.csv", Count));
        //    }

        //    return filePath;
        //}
    }
}
