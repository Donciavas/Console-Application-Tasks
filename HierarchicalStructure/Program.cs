namespace HierarchicalStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Branch root = Branch.NewBranch('R');
            (root.branches).Add(Branch.NewBranch(2));
            (root.branches).Add(Branch.NewBranch('A'));
            (root.branches).Add(Branch.NewBranch('B'));
            (root.branches).Add(Branch.NewBranch('C'));
            (root.branches[0].branches).Add(Branch.NewBranch(3));
            (root.branches[3].branches).Add(Branch.NewBranch('A'));
            (root.branches[3].branches).Add(Branch.NewBranch('B'));
            (root.branches[3].branches).Add(Branch.NewBranch('C'));
            (root.branches[0].branches[0].branches).Add(Branch.NewBranch(4));
            (root.branches[3].branches[2].branches).Add(Branch.NewBranch('A'));
            (root.branches[3].branches[2].branches[0].branches).Add(Branch.NewBranch('5'));

            Console.Write(Branch.DepthOfTree(root) + "\n");
        }
    }
}