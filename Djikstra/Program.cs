using System;
using System.Collections.Generic;

namespace Djikstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] {                
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

            var list = Djikstra(matrix, 4, Convert.ToInt32(Math.Sqrt(matrix.Length)));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static public Array Djikstra(int[,] matrix, int startNode, int numberOfNodes)
        {
            int[] edges = new int[numberOfNodes];
            bool[] visited = new bool[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {               
                    edges[i] = (int.MaxValue);
            }

            edges[startNode] = 0;

            return ShortestPath(edges, visited, matrix, numberOfNodes);

            }
            private static Array ShortestPath(int[] edges, bool[] visited, int[,] matrix, int numberOfNodes)
        {
            var shortestDistance = int.MaxValue;
            var shortestIndex = -1;

            for (int i = 0; i < numberOfNodes; i++)
            {
                if (edges[i] < shortestDistance && !visited[i])
                {
                    shortestDistance = edges[i];
                    shortestIndex = i;
                }
            }

            if (shortestIndex == -1) return edges;

            for (int i = 0; i < numberOfNodes; i++)
            {
                if (matrix[shortestIndex, i] != 0 && edges[i] > edges[shortestIndex] + matrix[shortestIndex, i])
                {
                    edges[i] = edges[shortestIndex] + matrix[shortestIndex, i];
                }
                visited[shortestIndex] = true;
            }
        
                return ShortestPath(edges, visited, matrix, numberOfNodes);
            }
        }
    }

            //    while (true)
            //    {
            //        var shortestDistance = int.MaxValue;
            //        var shortestIndex = -1;

            //        for (int i = 0; i < numberOfNodes; i++)
            //        {

            //                if (edges[i] < shortestDistance && !visited[i])
            //                {
            //                    shortestDistance = edges[i];
            //                    shortestIndex = i;
            //                }                    
            //        }
            //            if (shortestIndex == -1) return edges;

            //        for (int i = 0; i < numberOfNodes; i++)
            //        {                   
            //                if (matrix[shortestIndex, i] != 0 && edges[i] > edges[shortestIndex] + matrix[shortestIndex, i])
            //                {
            //                    edges[i] = edges[shortestIndex] + matrix[shortestIndex, i];
            //                }   
            //            visited[shortestIndex] = true;
            //        }
            //    }