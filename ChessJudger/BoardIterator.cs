using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessJudger
{
    class BoardIterator
    {
        private bool m_IsEnd = false;
        private Rectangle m_Rectangle;
        public BoardIterator(Rectangle rectangle)
        {
            m_Rectangle = rectangle;
        }

        public void GetBroad(Action<int[,]> randBroadCallBack)
        {
            var n = m_Rectangle.GetLength();
            var index = 0;
            var array = new int[n];

            GetRandArrayByFB(n, index, array,
                (data) =>
                {
                    var temp = new int[11, 11];
                    for (int i = 0; i < data.Length; i++)
                    {
                        int x = i%m_Rectangle.Width;
                        int y = i/m_Rectangle.Width;

                        temp[x + m_Rectangle.LeftX, y + m_Rectangle.BottomY] = data[i];
                    }

                    randBroadCallBack(temp);
                });
        }

        private static int[] m_Choose = new int[3] {0, 1, 2};

        private void GetRandArrayByFB(
            int n,
            int index,
            int[] array,
            Action<int[]> callBack
            )
        {
            if (n == index)
            {
                return;
            }

            foreach (var choose in m_Choose)
            {
                array[index] = choose;
                callBack(array);
                var cloneArray = (int[])array.Clone();
                GetRandArrayByFB(n, index + 1, cloneArray, callBack);
            }
        }
    }
}
