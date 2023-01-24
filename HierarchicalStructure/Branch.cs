namespace HierarchicalStructure
{
    public class Branch
    {
        public List<Branch>? branches;
        public char key;
        public static Branch NewBranch(int key)
        {
            Branch temp = new Branch();
            temp.key = (char)key;
            temp.branches = new List<Branch>();
            return temp;
        }
        public static int DepthOfTree(Branch pointer)
        {
            if (pointer == null)
                return 0;
            int maxDepth = 0;
            foreach (Branch item in pointer.branches)
                maxDepth = Math.Max(maxDepth, DepthOfTree(item));
            return maxDepth + 1;
        }
    }
}
