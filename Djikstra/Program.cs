using System;
using System.Collections.Generic;

namespace Djikstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,] {                
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


            var list = Djikstra(graph, 0);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static public Array Djikstra(int[,] graph, int startNode)
        {
            int[] distances = new int[10];
            bool[] visited = new bool[10];

            for (int i = 0; i < 10; i++)
            {
               
                    distances[i] = (int.MaxValue);
                    visited[i] = (false);
                
            }

            distances[startNode] = 0;

            return ShortestPath(distances, visited, graph);

            //    while (true)
            //    {
            //        var shortestDistance = int.MaxValue;
            //        var shortestIndex = -1;

            //        for (int i = 0; i < 10; i++)
            //        {

            //                if (distances[i] < shortestDistance && !visited[i])
            //                {
            //                    shortestDistance = distances[i];
            //                    shortestIndex = i;
            //                }                    
            //        }
            //            if (shortestIndex == -1) return distances;

            //        for (int i = 0; i < 10; i++)
            //        {                   
            //                if (graph[shortestIndex, i] != 0 && distances[i] > distances[shortestIndex] + graph[shortestIndex, i])
            //                {
            //                    distances[i] = distances[shortestIndex] + graph[shortestIndex, i];
            //                }   
            //            visited[shortestIndex] = true;
            //        }
            //    }
            }
            private static Array ShortestPath(int[] distances, bool[] visited, int[,] graph)
        {
            var shortestDistance = int.MaxValue;
            var shortestIndex = -1;

            for (int i = 0; i < 10; i++)
            {

                if (distances[i] < shortestDistance && !visited[i])
                {
                    shortestDistance = distances[i];
                    shortestIndex = i;
                }
            }
            if (shortestIndex == -1) return distances;

            for (int i = 0; i < 10; i++)
            {
                if (graph[shortestIndex, i] != 0 && distances[i] > distances[shortestIndex] + graph[shortestIndex, i])
                {
                    distances[i] = distances[shortestIndex] + graph[shortestIndex, i];
                }
                visited[shortestIndex] = true;
            }
        
                return ShortestPath(distances, visited, graph);
            }
        }
    }
