using System;
using System.Collections.Generic;

namespace Djikstra
{
    public static class UserInput
    {
        public static List<int> GetUserInput()
        {
            List<int> nodeQueue = new();
            var nodes = Matrix.DefaultNodes;
            var whileLoop = true;
            var detour = false;

            for (int i = 0; i < nodes.Length; i++)
            {
                Console.WriteLine($"Node {nodes[i]} = {i}");
            }

            Console.WriteLine("Select start node (number): ");
            nodeQueue.Add(Backend.Invalid_input_check(0, 9));

            while (whileLoop)
            {
                Console.WriteLine("Do you want to add a delmål?");
                Console.WriteLine("[Y]es / [N]o");

                var detourInput = Console.ReadLine();

                if (string.Equals(detourInput, "y", StringComparison.OrdinalIgnoreCase))
                {
                    detour = true;
                    whileLoop = false;
                }
                else if (string.Equals(detourInput, "n", StringComparison.OrdinalIgnoreCase))
                {
                    whileLoop = false;
                }
            }

            if (detour)
            {
                Console.WriteLine("Select detour node (number): ");
                nodeQueue.Add(Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
            }

            Console.WriteLine("Select end node (number): ");
            nodeQueue.Add(Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));

            return nodeQueue;
        }
    }
}