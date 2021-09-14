//using System;
//using System.Collections.Generic;

//namespace Djikstra
//{
//        class Backend2
//    {
//        public const int maxValue = int.MaxValue;

//        static public int[,] Djikstra(int[,] graph, int startNode, int endNode)
//        {

//            Queue<Node> queue = new();

//            int numberOfNodes = Convert.ToInt32(Math.Sqrt(Matrix.DefaultMatrix.Length));

//            var visited = new bool[numberOfNodes];

//            int[,] distances = new int[numberOfNodes, numberOfNodes];

//            for (int i = 0; i < numberOfNodes; i++)
//            {
//                for (int j = 0; j < numberOfNodes; j++)
//                {
//                    distances[i, j] = maxValue;
//                }
//            }
//            distances[startNode, startNode] = 0;

//            while (true)
//            {
//                var shortestDistance = maxValue;
//                var shortestIndex = -1;

//                for (int i = 0; i < numberOfNodes; i++)
//                {
//                    for (int j = 0; j < numberOfNodes; j++)
//                    {
//                       if( distances[i, j] < shortestDistance && !visited[i])
//                        {
//                            shortestDistance = distances[i, j];
//                            shortestIndex = i;
//                        }
//                    }
//                }

//                //foreach (var item in queue)
//                //{
//                //    if (item.NodeName == Matrix.DefaultNodes[endNode])
//                //        shortestIndex = -1;
//                //}

//                if(shortestIndex == -1)
//                {
//                    return distances;
//                }

//                for (int i = 0; i < numberOfNodes; i++)
//                {
//                    if(graph[shortestIndex,i] != 0 && distances[i, shortestIndex] > distances[shortestIndex, i] + graph[i, shortestIndex])
//                    {
//                        distances[i, shortestIndex] = distances[shortestIndex, i] + graph[i, shortestIndex];
//                       // var node = new Node($"From {Matrix.DefaultNodes[shortestIndex]} to {Matrix.DefaultNodes[i]} ", graph[i, shortestIndex]);
//                       // queue.Enqueue(node);
//                    }
//                } 
//                visited[shortestIndex] = true;
        

//            }
//        }

//                        //if (graph[i, j] != 0)
//                        //{
//                        //    var node = new Node(Matrix.DefaultNodes[j], graph[i, j]);
//                        //    queue.Enqueue(node);
//                        //    // Console.WriteLine($"From {Matrix.DefaultNodes[i]} to {Matrix.DefaultNodes[j]} is {graph[i,j]}");
//                        //}

//                //foreach (var item in queue)
//                //{
//                //    if (item.NodeName == Matrix.DefaultNodes[endNode])
//                //    {
//                //        loop = false;
//                //    }
//                //    // Console.WriteLine("Node " + item.NodeName + " has an edge of " + item.Edge);
//                //}
//        //{
//        //    int numberOfNodes = Convert.ToInt32(Math.Sqrt(matrix.Length));
//        //    int[] edges = new int[numberOfNodes];
//        //    bool[] visited = new bool[numberOfNodes];
//        //    for (int i = 0; i < numberOfNodes; i++)
//        //    {
//        //        edges[i] = (int.MaxValue);
//        //    }
//        //    edges[startNode] = 0;
//        //    return ShortestPath(edges, visited, matrix, numberOfNodes);

//        //}
//        //private static Array ShortestPath(int[] edges, bool[] visited, int[,] matrix, int numberOfNodes)
//        //{
//        //    var shortestDistance = int.MaxValue;
//        //    var shortestIndex = -1;

//        //    for (int i = 0; i < numberOfNodes; i++)
//        //    {
//        //        if (edges[i] < shortestDistance && !visited[i])
//        //        {
//        //            shortestDistance = edges[i];
//        //            shortestIndex = i;
//        //        }
//        //    }

//        //    if (shortestIndex == -1) return edges;

//        //    for (int i = 0; i < numberOfNodes; i++)
//        //    {
//        //        if (matrix[shortestIndex, i] != 0 && edges[i] > edges[shortestIndex] + matrix[shortestIndex, i])
//        //        {
//        //            edges[i] = edges[shortestIndex] + matrix[shortestIndex, i];
//        //        }
//        //        visited[shortestIndex] = true;
//        //    }

//        //    return ShortestPath(edges, visited, matrix, numberOfNodes);
//        //}
//    }
//}

