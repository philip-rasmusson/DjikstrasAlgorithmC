﻿using System;
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

            nodeQueue.Add(Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));

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

            while(detour)
            {
                Console.WriteLine("Select detour node (number): ");
                var tempInput = (Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
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
            whileLoop = true;

            while (whileLoop)
            {
            Console.WriteLine("Select end node (number): ");

                var tempInput = (Backend.Invalid_input_check(0, Matrix.DefaultNodes.Length));
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
            return nodeQueue;
        }
    }
}