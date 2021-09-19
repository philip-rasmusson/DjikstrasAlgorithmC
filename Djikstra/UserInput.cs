using System;
using System.Collections.Generic;

namespace Djikstra
{
    public static class UserInput
    {
        //Method to get user input
        public static List<int> GetUserInput()
        {
            List<int> nodeQueue = new();
            var nodes = Matrix.DefaultNodes;
            var whileLoop = true;
            var detour = false;
            //Lists all nodes to user with name and number
            for (int i = 0; i < nodes.Length; i++)
            {
                Console.WriteLine($"Node {nodes[i]} = {i}");
            }
            //Adds start node to list
            Console.WriteLine("Select start node (number): ");
            nodeQueue.Add(Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
            //Asks if user wants to add a detour
            while (whileLoop)
            {
                Console.WriteLine("Do you want to add a detour?");
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
            //If user want to add a detour, adds detour node to list
            while (detour)
            {
                Console.WriteLine("Select detour node (number): ");
                var tempInput = (Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
                //Checks if detour node is same as start node (not allowed)
                if (!nodeQueue.Contains(tempInput))
                {
                    nodeQueue.Add(tempInput);
                    detour = false;
                }
                else
                {
                    Console.WriteLine("This node is already selected, please check another");
                }
            }
            //Asks user for end node
            whileLoop = true;
            while (whileLoop)
            {
                Console.WriteLine("Select end node (number): ");

                var tempInput = (Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
                //Checks if end node is same as start node or detour node (not allowed)
                if (!nodeQueue.Contains(tempInput))
                {
                    nodeQueue.Add(tempInput);
                    whileLoop = false;
                }
                else
                {
                    Console.WriteLine("This node is already selected, please check another");
                }
            }
            Console.Clear();
            //Returns a list of eiter start node and end node (2 elements)
            //or start node, detour node and end node (3 elements)
            return nodeQueue;
        }

        public static void NewSearchQuery()
        {
            Console.WriteLine("\nNew search? [Y]es or [N]o");
            var newSearchQuery = Console.ReadLine();
            if (string.Equals(newSearchQuery, "y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Program.Main();
            }
            else if (string.Equals(newSearchQuery, "n", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}