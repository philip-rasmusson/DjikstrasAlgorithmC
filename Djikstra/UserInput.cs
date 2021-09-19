using System;
using System.Collections.Generic;

namespace Djikstra
{
    public static class UserInput
    {
        /// <summary>
        /// Gives the user the option to make a new search without restarting the program
        /// </summary>
        public static void AskUserForNewSearch()
        {
            Console.WriteLine("\n\nDo you want to make a new search? [Y]es or [N]o");
            var newSearch = Console.ReadLine();

            if (string.Equals(newSearch, "y", StringComparison.OrdinalIgnoreCase))            //O(n)
            {
                Console.Clear();
                Program.Main();
            }
            else if (string.Equals(newSearch, "n", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Asks if user wants to do a detour
        /// </summary>
        /// <param name="whileLoop">
        /// </param>
        /// <param name="detour">
        /// </param>
        public static void AskUserIfDetour(ref bool whileLoop, ref bool detour)
        {
            var detourInput = Console.ReadLine();

            if (string.Equals(detourInput, "y", StringComparison.OrdinalIgnoreCase))            //O(n)
            {
                detour = true;
                whileLoop = false;
            }
            else if (string.Equals(detourInput, "n", StringComparison.OrdinalIgnoreCase))
            {
                whileLoop = false;
            }
        }

        /// <summary>
        /// Asks for input if user choose detour
        /// </summary>
        /// <param name="nodeQueue">
        /// </param>
        /// <param name="detour">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool Detour(List<int> nodeQueue, bool detour)
        {
            Console.WriteLine("Select detour node (number): ");
            var tempInput = (Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
            //Checks if detour node is same as start node (not allowed)
            if (!nodeQueue.Contains(tempInput))            //O(n)
            {
                nodeQueue.Add(tempInput);
                detour = false;
            }
            else
            {
                Console.WriteLine("This node is already selected, please check another");
            }

            return detour;
        }

        /// <summary>
        /// Asks for input for End node
        /// </summary>
        /// <param name="nodeQueue">
        /// </param>
        /// <param name="whileLoop">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool EndNode(List<int> nodeQueue, bool whileLoop)
        {
            Console.WriteLine("Select end node (number): ");

            var tempInput = (Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
            //Checks if end node is same as start node or detour node (not allowed)
            if (!nodeQueue.Contains(tempInput))            //O(n)
            {
                nodeQueue.Add(tempInput);
                whileLoop = false;
            }
            else
            {
                Console.WriteLine("This node is already selected, please check another");
            }

            return whileLoop;
        }

        //Method to get user input
        public static List<int> GetUserInput()
        {
            List<int> nodeQueue = new();
            var whileLoop = true;
            var detour = false;

            //Lists all nodes to user with name and number
            ListNodesNameAndNumber();

            //Adds start node to list
            Console.WriteLine("Select start node (number): ");
            nodeQueue.Add(Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));

            //Asks if user wants to add a detour
            while (whileLoop)
            {
                Console.WriteLine("Do you want to add a detour?");
                Console.WriteLine("[Y]es / [N]o");
                AskUserIfDetour(ref whileLoop, ref detour);
            }

            //If user want to add a detour, adds detour node to list
            while (detour)
            {
                detour = Detour(nodeQueue, detour);
            }

            //Asks user for end node
            whileLoop = true;
            while (whileLoop)
            {
                whileLoop = EndNode(nodeQueue, whileLoop);
            }

            Console.Clear();

            //Returns a list of eiter start node and end node (2 elements)
            //or start node, detour node and end node (3 elements)
            return nodeQueue;
        }

        /// <summary>
        /// Lists name and number of all nodes
        /// </summary>
        public static void ListNodesNameAndNumber()
        {
            for (int i = 0; i < Matrix.DefaultNodes.Length; i++)            //O(n)
            {
                Console.WriteLine($"Node {Matrix.DefaultNodes[i]} = {i}");
            }
        }
    }
}