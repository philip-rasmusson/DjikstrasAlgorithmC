using System.Collections.Generic;

namespace Djikstra
{
    public static class Matrix
    {
        //Default matrix and node names
        public static int[,] DefaultMatrix => new int[,] {
                {0, 4, 7, 0, 7, 0, 0, 0, 0, 0 },
                {4, 0, 3, 12, 0, 0, 0, 5, 0, 0 },
                {7, 3, 0, 0, 0, 0, 4, 0, 12, 0},
                {0, 12, 0, 0, 0, 0, 0, 7, 3, 0},
                {7, 0, 0, 0, 0, 3, 5, 0, 0, 0},
                {0, 0, 0, 0, 3, 0, 5, 0, 0, 0},
                {0, 0, 4, 0, 5, 5, 0, 8, 13, 8},
                {0, 5, 0, 7, 0, 0, 8, 0, 0, 9},
                {0, 0, 12, 3, 0, 0, 13, 0, 0, 7},
                {0, 0, 0, 0, 0, 0, 8, 9, 7, 0}
             };
        public static char[] DefaultNodes => new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

    }
}