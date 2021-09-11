using System;
using System.Collections.Generic;

namespace Djikstra
{
    public static class Backend
    {
        public const int maxValue = int.MaxValue;

        public static void CalculateShortestPath(
            int[] edges,
            bool[] visited,
            int[,] matrix,
            int numberOfNodes,
            int shortestIndex)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                IfMatrixIsNotZero(edges,
                                  matrix,
                                  shortestIndex,
                                  i);
                visited[shortestIndex] = true;
            }
        }
        //Finds the starting node and sets its edge to 0 and shortestIndex to that index
        //After staring node is set, looks for shortest edge in unvisited nodes
        public static void CountNodes(
            int[] edges,
            bool[] visited,
            int numberOfNodes,
            ref int shortestDistance,
            ref int shortestIndex)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                FindNearestEdgeWithoutVisitingNodesTwice(edges,
                                                         visited,
                                                         ref shortestDistance,
                                                         ref shortestIndex,
                                                         i);
            }
        }

        public static Array Djikstra(
            int[,] matrix,
            int startNode,
            int numberOfNodes)
        {
            var edges = new int[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                edges[i] = maxValue;
            }

            edges[startNode] = 0;

            return ShortestPath(edges,
                                new bool[numberOfNodes],
                                matrix,
                                numberOfNodes);
        }

        public static void ExceptionThrown(Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }

        public static void FindNearestEdgeWithoutVisitingNodesTwice(
            int[] edges,
            bool[] visited,
            ref int shortestDistance,
            ref int shortestIndex,
            int i)
        {
            if (edges[i] < shortestDistance
                && !visited[i])
            {
                shortestDistance = edges[i];
                shortestIndex = i;
            }
        }

        public static void IfMatrixIsNotZero(
            int[] edges,
            int[,] matrix,
            int shortestIndex,
            int i)
        {
            if (!(matrix[i, shortestIndex] == 0 ||
                edges[i] <= edges[shortestIndex] + matrix[i, shortestIndex]))
            {
                edges[i] = edges[shortestIndex] + matrix[i, shortestIndex];
            }
        }

        public static void RunMatrix(List<int> startNodeEndNode)
        {
            var startNode = startNodeEndNode[0];
            var endNode = startNodeEndNode[startNodeEndNode.Count - 1];
            var count = 0;

            try
            {
                var node = Djikstra(
                    Matrix.DefaultMatrix,
                    startNode,
                    Convert.ToInt32(Math.Sqrt(Matrix.DefaultMatrix.Length)))
                    .GetEnumerator();

                while (node.MoveNext())
                {
                    if(count == endNode)
                     Console.WriteLine($"Quickest way from {Matrix.DefaultNodes[startNode]} to {Matrix.DefaultNodes[endNode]} is {node.Current}");
                    count++;
                }
            }
            catch (Exception ex)
            {
                ExceptionThrown(ex);
            }
        }

        public static Array ShortestPath(
            int[] edges,
            bool[] visited,
            int[,] matrix,
            int numberOfNodes)
        {
            //Sets shortestDistance closest to infinity and shortest index to -1
            //since no node is yet visited
            try
            {
                var shortestDistance = maxValue;
                var shortestIndex = -1;                
                CountNodes(
                    edges,
                    visited,
                    numberOfNodes,
                    ref shortestDistance,
                    ref shortestIndex);
                //If no edge is shorter that shortestDistance and all nodes are visited
                //returns the array with info about shortest path between nodes
                if (shortestIndex == -1) return edges;

                CalculateShortestPath(edges,
                                      visited,
                                      matrix,
                                      numberOfNodes,
                                      shortestIndex);
            }
            catch (Exception ex)
            {
                ExceptionThrown(ex);
            }

            //Calls the method again with updated props (recursion)
            return ShortestPath(edges,
                                visited,
                                matrix,
                                numberOfNodes);
        }
        //checks if input is a correct given int
        public static int Invalid_input_check()
        {
            int parseOK;

            while (!int.TryParse(Console.ReadLine(), out parseOK))
            {
                Console.WriteLine("Invalid input, only use digits");
            }

            return parseOK;
        }
  
    }
}