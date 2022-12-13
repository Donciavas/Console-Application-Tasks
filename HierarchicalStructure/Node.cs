namespace HierarchicalStructure
{
    public class Node
    {
        public int data;
        public Node left, middle, right;
        public Node(int item)
        {
            data = item;
            left = middle = right = null;
        }
    }
}
