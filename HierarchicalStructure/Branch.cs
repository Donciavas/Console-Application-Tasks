namespace HierarchicalStructure
{
    public class Branch
    {
        public Node? root;
        public int maxDepth(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                int lDepth = maxDepth(node.left);
                int mDepth = maxDepth(node.middle);
                int rDepth = maxDepth(node.right);
                if (lDepth > rDepth && lDepth > mDepth)
                    return (lDepth + 1);
                else if (mDepth > lDepth && mDepth > rDepth)
                    return (mDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
    }
}
