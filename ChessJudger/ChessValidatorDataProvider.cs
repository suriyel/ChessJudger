using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessJudger
{
    public class ChessValidatorDataProvider
    {
        private static List<Tuple<int, int>> m_Offsets = new List<Tuple<int, int>>()
        {
            new Tuple<int, int>(0, -1),
            new Tuple<int, int>(0, 1),
            new Tuple<int, int>(-1, 0),
            new Tuple<int, int>(1, 0),
        };

        private const int SIZE = 11;
        //private readonly int[,] m_OriChessBorad;
        private readonly List<int[]> m_Chess;
        private readonly IDataWriter m_Writer;

        public ChessValidatorDataProvider(
            List<int[]> chess)
        {
            //m_OriChessBorad = oriChessBorad;
            m_Chess = chess;
            m_Writer=new DataWriter();
        }

        public void WriteAllTrainingDatas(string fileName)
        {
            Rectangle rectangle = new Rectangle(m_Chess);
            BoardIterator iterator=new BoardIterator(rectangle);
            var chess = GetChess();
            iterator.GetBroad((temp) =>
            {
                var isValid = IsValid(temp);
                m_Writer.Write(fileName, temp, chess, isValid);
            });
        }

        private bool IsValid(int[,] temp)
        {
            foreach (var point in m_Chess)
            {
                var x = point[0];
                var y = point[1];

                if (temp[x,y] != 0)
                {
                    return false;
                }

                var query = (
                    from offset in m_Offsets
                    let offsetCol = y + offset.Item1
                    let offsetRow = x + offset.Item2
                    where temp[offsetRow, offsetCol] == 1
                    select offsetCol);
                if (query.Any())
                {
                    return false;
                }
            }

            return true;
        }

        private int[,] GetChess()
        {
            var chess = new int[SIZE, SIZE];
            foreach (var point in m_Chess)
            {
                chess[point[0], point[1]] = 1;
            }

            return chess;
        }
    }
}
