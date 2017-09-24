using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessJudger
{
    class Rectangle
    {
        public int LeftX = int.MaxValue;
        public int RightX = int.MinValue;
        public int TopY = int.MinValue;
        public int BottomY = int.MaxValue;

        public int Width;
        public int Height;

        public Rectangle(List<int[]> chess)

        {
            var xs = chess.Select(r => r[0]);
            var ys = chess.Select(r => r[1]);
            BottomY = ys.Min();
            TopY = ys.Max();
            RightX = xs.Max();
            LeftX = xs.Min();

            LeftX -= 1;
            RightX += 1;
            TopY += 1;
            BottomY -= 1;
            Height = TopY - BottomY + 1;
            Width = RightX - LeftX + 1;
        }

        public int GetLength()
        {
            return Height*Width;
        }
    }
}
