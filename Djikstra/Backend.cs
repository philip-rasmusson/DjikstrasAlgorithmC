using System;
using System.Collections.Generic;

namespace Djikstra
{
    public static class Backend
    {
        //Creates a var for max value
        public const int maxValue = int.MaxValue;

        //Finds the shortest path from start node to all other unvisited nodes
        public static void CalculateShortestPath(
            int[] edges,
            bool[] visited,
            int[,] matrix,
            int numberOfNodes,
            int shortestIndex,
            List<Node> nodePath)
        {
            for (int i = 0; i < numberOfNodes; i++)            //O(n)
            {
                IfMatrixIsNotZero(edges,
                                  matrix,
                                  shortestIndex,
                                  i,
                                  nodePath);
                //Sets node to visited
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
            for (int i = 0; i < numberOfNodes; i++)            //O(n)
            {
                FindNearestEdgeWithoutVisitingNodesTwice(edges,
                                                         visited,
                                                         ref shortestDistance,
                                                         ref shortestIndex,
                                                         i);
            }
        }

        //Sets all edges to inifnity, then sets starting edge to zero
        //Returns the result of ShortestPath
        public static List<Node> Djikstra(
            int[,] matrix,
            int startNode,
            int numberOfNodes)
        {
            var edges = new int[numberOfNodes];
            //Sets all edges to infinity
            for (int i = 0; i < numberOfNodes; i++)            //O(n)
            {
                edges[i] = maxValue;
            }
            //Sets start edge to 0
            edges[startNode] = 0;
            //Calls on ShortestPath with starting edge set to 0
            //Returns a List of shortest edges from starting node to all other nodes
            return ShortestPath(edges,
                                new bool[numberOfNodes],
                                matrix,
                                numberOfNodes,
                                new List<Node>());
        }

        public static void ExceptionThrown(Exception ex)
        {
            Console.WriteLine("Error: " + ex);
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
        public static List<char> FindAllNodesInShortestPath(
            List<Node> node,
            List<char> path,
            int startNode,
            char endNode)
        {
            foreach (var item in node)
            {
                if (item.NodeB == endNode)
                {
                    path.Add(item.NodeB);
                    if (item.NodeA == Matrix.DefaultNodes[startNode])
                    {
                        path.Add(Matrix.DefaultNodes[startNode]);            //O(n^2)
                        return path;
                    }
                    endNode = item.NodeA;
                    return FindAllNodesInShortestPath(node,
                                                      path,
                                                      startNode,
                                                      endNode);
                }
            }
            return new List<char>();
        }

        //Finding shortest edge in all unvisited nodes
        public static void FindNearestEdgeWithoutVisitingNodesTwice(
            int[] edges,
            bool[] visited,
            ref int shortestDistance,
            ref int shortestIndex,
            int i)
        {
            if (edges[i] < shortestDistance            //O(n)
                && !visited[i])
            {
                shortestDistance = edges[i];
                shortestIndex = i;
            }
        }

        //Finds the shortest edge to all nodes
        //Adds info about NodeA, NodeB and edge to node-list
        public static void IfMatrixIsNotZero(
            int[] edges,
            int[,] matrix,
            int shortestIndex,
            int i,
            List<Node> nodePath)
        {
            if (!(matrix[i, shortestIndex] == 0 ||
                edges[i] <= edges[shortestIndex] + matrix[i, shortestIndex]))            //O(n)
            {
                edges[i] = edges[shortestIndex] + matrix[i, shortestIndex];
                nodePath.Add(new Node(Matrix.DefaultNodes[shortestIndex],
                                      Matrix.DefaultNodes[i],
                                      edges[i]));
            }
        }

        //checks if input is a correct given int between max and min value
        public static int Invalid_input_check(int min, int max)
        {
            int parseOK;

            while (!int.TryParse(Console.ReadLine(), out parseOK) || parseOK < min || parseOK >= max)             //O(n)
            {
                Console.WriteLine("Invalid input");
            }
            return parseOK;
        }

        //Main method to find the shortest path between two nodes. Prints the result to console
        public static void RunMatrix(
            List<int> startNodeEndNode,
            int totalTime)
        {
            var path = new List<char>();
            var printTotalTime = true;
            try
            {
                var nodePath = Djikstra(
                    Matrix.DefaultMatrix,
                    startNodeEndNode[0],
                    Convert.ToInt32(Math.Sqrt(Matrix.DefaultMatrix.Length)));
                //*Temporary loop to remove alternative, longer path*
                //TODO: Check all methods to find out why sometimes alternative
                //(not shortest) paths is added to nodePath
                for (int i = 0; i < nodePath.Count - 1; i++)
                {
                    for (int j = i + 1; j < nodePath.Count; j++)
                    {
                        if (nodePath[i].NodeB == nodePath[j].NodeB)
                        {
                            if (nodePath[i].Edge <= nodePath[j].Edge)            //O(n^4)
                            {
                                nodePath.RemoveAt(j);
                            }
                            else
                            {
                                nodePath.RemoveAt(i);
                            }
                        }
                    }
                }
                //Adds the total time to totalTime var
                foreach (var item in nodePath)
                {
                    if (item.NodeB == Matrix.DefaultNodes[startNodeEndNode[1]])            //O(n^1)
                    {
                        totalTime += item.Edge;
                    }
                }
                //Tracks all nodes in shortest path from end node to start node
                try
                {
                    path = FindAllNodesInShortestPath(nodePath,
                                                      path,
                                                      startNodeEndNode[0],
                                                      Matrix.DefaultNodes[startNodeEndNode[1]]);
                    //Makes path correct order
                    path.Reverse();
                    //Prints all nodes in shortest path to console
                    var node = path.GetEnumerator();
                    {
                        while (node.MoveNext())
                        {
                            Console.Write(node.Current + " ");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionThrown(ex);
                }
                //If a detour node is added, print message to console
                if (startNodeEndNode.Count > 2)            //O(n)
                {
                    Console.Write(" - DETOUR STOP - ");
                    printTotalTime = false;
                }
                //If a detour is added, rund the method again to
                //find the shortest path with detour node set as start node,
                //and end node as new end node
                startNodeEndNode.Remove(startNodeEndNode[0]);
                if (startNodeEndNode.Count >= 2)            //O(n)
                {
                    RunMatrix(startNodeEndNode, totalTime);
                }
                //Prints total time from start node to end node
                if (printTotalTime)            //O(n)
                {
                    Console.WriteLine($"\n\nTotal time: {totalTime}");
                    UserInput.AskUserForNewSearch();
                }
            }
            catch (Exception ex)
            {
                ExceptionThrown(ex);
            }
        }

        //Method to find shortest path to all nodes from starting node
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
    }
}