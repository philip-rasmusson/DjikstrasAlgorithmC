namespace Djikstra
{
    public static class Program
    {
        public static void Main()
        {
            Backend.RunMatrix();
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
//                if (matrix[i, shortestIndex] != 0 && edges[i] > edges[shortestIndex] + matrix[i, shortestIndex])
//                {
//                    edges[i] = edges[shortestIndex] + matrix[i, shortestIndex];
//                }
//            visited[shortestIndex] = true;
//        }
//    }