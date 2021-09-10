namespace Djikstra
{
    public static class Program
    {
        public static void Main()
        {
            Backend.RunMatrix();
        }
        //    var edges = Djikstra(GetMatrix(), 0, Convert.ToInt32(Math.Sqrt(GetMatrix().Length)));

        //    foreach (var item in edges)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //private static int[,] GetMatrix()
        //{
        //    int[,] matrix = new int[,] {                
        //        {0, 4, 7, 0, 7, 0, 0, 0, 0, 0 },
        //        {4, 0, 3, 12, 0, 0, 0, 5, 0, 0 }, 
        //        {7, 3, 0, 0, 0, 0, 4, 0, 12, 0}, 
        //        {0, 12, 0, 0, 0, 0, 0, 7, 3, 0},  
        //        {7, 0, 0, 0, 0, 3, 5, 0, 0, 0},  
        //        {0, 0, 0, 0, 3, 0, 5, 0, 0, 0},    
        //        {0, 0, 4, 0, 5, 5, 0, 8, 13, 8},  
        //        {0, 5, 0, 7, 0, 0, 8, 0, 0, 9},  
        //        {0, 0, 12, 3, 0, 0, 13, 0, 0, 7},  
        //        {0, 0, 0, 0, 0, 0, 8, 9, 7, 0}
        //     };

        //    return matrix;
        //}

        //static public Array Djikstra(int[,] matrix, int startNode, int numberOfNodes)
        //{
        //    int[] edges = new int[numberOfNodes];
        //    bool[] visited = new bool[numberOfNodes];

        //    for (int i = 0; i < numberOfNodes; i++)
        //    {               
        //            edges[i] = (int.MaxValue);
        //    }
    }
}

        //    edges[startNode] = 0;

        //    return ShortestPath(edges, visited, matrix, numberOfNodes);

        //    }

        //private static Array ShortestPath(int[] edges, bool[] visited, int[,] matrix, int numberOfNodes)
        //{
        //    //Sets shortestDistance closest to infinity and shortest index to -1
        //    //since no node is yet visited
        //    var shortestDistance = int.MaxValue;
        //    var shortestIndex = -1;
        //    //Finds the starting node and sets its edge to 0 and shortestIndex to that index
        //    //After staring node is set, looks for shortest edge in unvisited nodes
        //    for (int i = 0; i < numberOfNodes; i++)
        //    {
        //        if (edges[i] < shortestDistance && !visited[i])
        //        {
        //            shortestDistance = edges[i];
        //            shortestIndex = i;
        //        }
        //    }
        //    //If no edge is shorter that shortestDistance and all nodes are visited
        //    //returns the array with info about shortest path between nodes
        //    if (shortestIndex == -1) return edges;
        //    //Checks if current edge is more than 0 (0 means no path between nodes)
        //    //and if it's shorter than 
        //    for (int i = 0; i < numberOfNodes; i++)
        //    {
        //        if (matrix[i, shortestIndex] != 0 && edges[i] > (edges[shortestIndex] + matrix[i, shortestIndex]))
        //        {
        //            edges[i] = edges[shortestIndex] + matrix[i, shortestIndex];
        //        }
        //        visited[shortestIndex] = true;
        //    }
        //    //Calls the method again with updated props (recursion)
        //    return ShortestPath(edges, visited, matrix, numberOfNodes);
        //    }

       // }
   // }

            //    while (true)
            //    {
            //        var shortestDistance = int.MaxValue;
            //        var shortestIndex = -1;
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
//                if (matrix[i, shortestIndex] != 0 && edges[i] > edges[shortestIndex] + matrix[i, shortestIndex])
//                {
//                    edges[i] = edges[shortestIndex] + matrix[i, shortestIndex];
//                }
//            visited[shortestIndex] = true;
//        }
//    }