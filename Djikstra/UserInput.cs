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
            List<int> nodeQueue = new List<int>();
            var nodes = Matrix.DefaultNodes;
            var whileLoop = true;
            var delmal = false;


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

            var delmalInput = Console.ReadLine();

                if(delmalInput.ToLower() == "y") {
                    delmal = true;
                    whileLoop = false;
                }
                else if(delmalInput.ToLower() == "n") {
                    whileLoop = false;
                }
            }

            if(delmal)
            {
                Console.WriteLine("Select delmal node (number): ");
                nodeQueue.Add(Backend.Invalid_input_check());
            }

            Console.WriteLine("Select end node (number): ");
            nodeQueue.Add(Backend.Invalid_input_check());

            return nodeQueue;
        }
        
    }
}
