using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public static class UserInput
    {
        public static int[] GetUserInput(string message1, string message2)
        {
            int[] startNodeEndNode = new int[2];
            var nodes = Matrix.DefaultNodes;


            for (int i = 0; i < nodes.Length; i++)
            {
                Console.WriteLine($"Node {nodes[i]} = {i}");
            }

            Console.WriteLine();
            Console.WriteLine(message1);
            startNodeEndNode[0] = Backend.Invalid_input_check();

            Console.WriteLine(message2);
            startNodeEndNode[1] = Backend.Invalid_input_check();

            return startNodeEndNode;
        }
        
    }
}
