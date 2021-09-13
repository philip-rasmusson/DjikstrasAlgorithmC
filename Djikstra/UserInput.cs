using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            nodeQueue.Add(Backend.Invalid_input_check());

            while (whileLoop)
            {
            Console.WriteLine("Do you want to add a delmål?");
            Console.WriteLine("[Y]es / [N]o");

            var detourInput = Console.ReadLine();

                if(detourInput.ToLower() == "y") {
                    detour = true;
                    whileLoop = false;
                }
                else if(detourInput.ToLower() == "n") {
                    whileLoop = false;
                }
            }

            if(detour)
            {
                Console.WriteLine("Select detour node (number): ");
                nodeQueue.Add(Backend.Invalid_input_check());
            }

            Console.WriteLine("Select end node (number): ");
            nodeQueue.Add(Backend.Invalid_input_check());

            return nodeQueue;
        }
        
    }
}
