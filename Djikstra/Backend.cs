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
            int shortestIndex,
            List<Node> nodePath)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                IfMatrixIsNotZero(edges,
                                  matrix,
                                  shortestIndex,
                                  i,
                                  nodePath);

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
        public static List<Node> Djikstra(
            int[,] matrix,
            int startNode,
            int numberOfNodes)
        {
            var edges = new int[numberOfNodes];
            var nodePath = new List<Node>();

            for (int i = 0; i < numberOfNodes; i++)
            {
                edges[i] = maxValue;
            }
            edges[startNode] = 0;
            return ShortestPath(edges,
                                new bool[numberOfNodes],
                                matrix,
                                numberOfNodes,
                                nodePath);
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
            int i,
            List<Node> nodePath)
        {
            if (!(matrix[i, shortestIndex] == 0 ||
                edges[i] <= edges[shortestIndex] + matrix[i, shortestIndex]))
            {
                edges[i] = edges[shortestIndex] + matrix[i, shortestIndex];
                var node = new Node(Matrix.DefaultNodes[shortestIndex], Matrix.DefaultNodes[i], edges[i]);
                nodePath.Add(node);
            }
        }
        public static void RunMatrix(List<int> startNodeEndNode, int totalTime)
        {
            var startNode = startNodeEndNode[0];
            var endNode = startNodeEndNode[1];
            var path = new List<char>();
            var printTotalTime = true;
            try
            {
                var nodePath = Djikstra(
                    Matrix.DefaultMatrix,
                    startNode,
                    Convert.ToInt32(Math.Sqrt(Matrix.DefaultMatrix.Length)));

                for (int i = 0; i < nodePath.Count-1; i++)
                {
                    for (int j = i+1; j < nodePath.Count; j++)
                    {
                        if(nodePath[i].NodeB == nodePath[j].NodeB)
                        {
                            if (nodePath[i].Egde <= nodePath[j].Egde)
                                nodePath.RemoveAt(j);
                            else
                                nodePath.RemoveAt(i);
                        }
                    }
                }
                for (int i = 0; i < nodePath.Count; i++)
                {
                    if (nodePath[i].NodeB == Matrix.DefaultNodes[endNode])
                        totalTime += nodePath[i].Egde;
                }

                path = FindAllNodesInShortestPath(nodePath, path, startNode, Matrix.DefaultNodes[endNode]);

                path.Reverse();

                foreach (var item in path)
                {
                    Console.Write(item + " ");
                }

                if (startNodeEndNode.Count > 2)
                {
                    Console.Write(" - DETOUR STOP - ");
                    printTotalTime = false;
                }
 
                startNodeEndNode.Remove(startNode);
                if (startNodeEndNode.Count >= 2)
                { 
                    RunMatrix(startNodeEndNode, totalTime); 
                }
                if (printTotalTime)
                    
                    Console.WriteLine("\n\nTotal time: " + totalTime);
            }
            catch (Exception ex)
            {
                ExceptionThrown(ex);
            }
        }
        //This recursion is to build a list of all the nodes visited in the shortest path.
        //First we look for the element where NodeB == endNode and add this to our list.
        //NodeA is the previous node in our path.
        //If NodeA is same a startNode, we have a direct connection between
        //startNode and endNode and can return that value. If not, then we change the value of endNode
        //to NodeA, and call the funciton again until we find NodeA == startNode.
        //Recursion is a good way to do this, since we only have to use one loop and get a lower ORDO.
        //And we use the recusion when we find what we are looking for, so we don't have to
        //look through the whole loop.
        public static List<char> FindAllNodesInShortestPath(List<Node> node, List<char> path, int startNode, char endNode)
        {
            for (int i = 0; i < node.Count; i++)
            {              
                if (node[i].NodeB == endNode)
                {
                    path.Add(node[i].NodeB);

                    if (node[i].NodeA == Matrix.DefaultNodes[startNode])
                    {

                        path.Add(Matrix.DefaultNodes[startNode]);
                      
                        return path;
                    }

                        endNode = node[i].NodeA;
                        return FindAllNodesInShortestPath(node, path, startNode, endNode);

                }
            }
            return  new List<char>(); 
        }
        public static List<Node> ShortestPath(
            int[] edges,
            bool[] visited,
            int[,] matrix,
            int numberOfNodes,
            List<Node> nodePath)
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
                //If no edge is shorter than shortestDistance and all nodes are visited
                //returns the array with info about shortest path between nodes
                if (shortestIndex == -1) return nodePath;

                CalculateShortestPath(edges,
                                      visited,
                                      matrix,
                                      numberOfNodes,
                                      shortestIndex,
                                      nodePath);
            }
            catch (Exception ex)
            {
                ExceptionThrown(ex);
            }
            //Calls the method again with updated props (recursion)
            return ShortestPath(edges,
                                visited,
                                matrix,
                                numberOfNodes,
                                nodePath);
        }
        //checks if input is a correct given int between max and min value

        public static int Invalid_input_check(int min, int max)
        {
            int parseOK;

            while (!int.TryParse(Console.ReadLine(), out parseOK) || parseOK < min || parseOK >= max)

            {
                Console.WriteLine("Invalid input");
            }
            return parseOK;
        }
    }
}