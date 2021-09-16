namespace Djikstra
{
    public class Node
    {
        public char NodeA { get; set; }
        public char NodeB { get; set; }
        public int Edge { get; set; }

        public Node(char nodeA, char nodeB, int edge)
        {
            this.NodeA = nodeA;
            this.NodeB = nodeB;
            this.Edge = edge;
        }
    }
}