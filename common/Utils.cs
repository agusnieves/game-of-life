using System;
using System.Collections.Generic;
using System.Linq;

namespace common.Utils
{
    public static class Utils
    {
        public static bool AreBoardsEqual(List<List<int>> originBoard, List<List<int>> targetBoard)
        {
            if (originBoard.Count != targetBoard.Count) return false;

            for (int i = 0; i < originBoard.Count; i++)
            {
                if (originBoard[i].Count != targetBoard[i].Count) return false;

                for (int j = 0; j < originBoard[i].Count; j++)
                {
                    if (originBoard[i][j] != targetBoard[i][j]) return false;
                }
            }
            return true;
        }
    }
}