namespace HierarchicalStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Branch structure = new Branch();
            structure.root = new Node(1);
            structure.root.left = new Node(2);
            structure.root.right = new Node(3);
            structure.root.middle = new Node(4);
            structure.root.left.left = new Node(5);
            structure.root.left.right = new Node(6);
            structure.root.right.left = new Node(7);
            structure.root.right.right = new Node(8);
            structure.root.middle.left = new Node(9);
            structure.root.left.left.right = new Node(10);
            structure.root.middle.left.left = new Node(11);
            structure.root.middle.left.right = new Node(12);
            structure.root.middle.left.left.right = new Node(13);
            structure.root.middle.left.left.right.middle = new Node(14);
            Console.WriteLine("Depth of structure is "
                              + structure.maxDepth(structure.root));
        }
    }
}