var visualizer = new BTreeVisualizer();
var tree = new BTree(2);
tree.Insert(1);
tree.Insert(2);
tree.Insert(3);
tree.Insert(4);
tree.Insert(5);
tree.Insert(6);
tree.Insert(7);
tree.Insert(8);
tree.Insert(9);
tree.Insert(10);
tree.Insert(11);
tree.Insert(12);
tree.Insert(13);
tree.Insert(14);
tree.Insert(15);
visualizer.PrintTree(tree.root);

public class BTreeVisualizer
{
    public void PrintTree(BTreeNode node, int level = 0)
    {
        if (node == null) return;

        // Indentation based on the tree depth
        Console.Write(new string(' ', level * 4));

        // Print keys inside brackets
        Console.WriteLine("[ " + string.Join(", ", node.Keys[..node.KeyCount]) + " ]");

        if (!node.IsLeaf)
        {
            for (int i = 0; i <= node.KeyCount; i++)
            {
                PrintTree(node.Children[i], level + 1);
            }
        }
    }
}
/// <summary>
/// BTree is a balanced-tree. Not a binary tree. Binary tree has only two children. BTree has more than two children.
/// </summary>
public class BTreeNode
{
    public int[] Keys { get; set; }
    public BTreeNode[] Children { get; set; }
    public bool IsLeaf { get; set; }
    public int Degree { get; set; }
    public int KeyCount { get; set; }

    public BTreeNode(int degree, bool isLeaf)
    {
        Degree = degree;
        IsLeaf = isLeaf;
        Keys = new int[2 * degree - 1];
        Children = new BTreeNode[2 * degree];
        KeyCount = 0;
    }
}

public class BTree
{
    public BTreeNode root;
    private int degree;

    public BTree(int degree)
    {
        this.degree = degree;
        root = new BTreeNode(degree, true);
    }

    public void Insert(int key)
    {
        BTreeNode r = root;
        if (r.KeyCount == 2 * degree - 1)
        {
            BTreeNode s = new BTreeNode(degree, false);
            root = s;
            s.Children[0] = r;
            SplitChild(s, 0, r);
            InsertNonFull(s, key);
        }
        else
        {
            InsertNonFull(r, key);
        }
    }

    private void SplitChild(BTreeNode parent, int index, BTreeNode nodeToSplit)
    {
        BTreeNode newNode = new BTreeNode(nodeToSplit.Degree, nodeToSplit.IsLeaf);
        newNode.KeyCount = degree - 1;

        for (int j = 0; j < degree - 1; j++)
        {
            newNode.Keys[j] = nodeToSplit.Keys[j + degree];
        }

        if (!nodeToSplit.IsLeaf)
        {
            for (int j = 0; j < degree; j++)
            {
                newNode.Children[j] = nodeToSplit.Children[j + degree];
            }
        }

        nodeToSplit.KeyCount = degree - 1;

        for (int j = parent.KeyCount; j >= index + 1; j--)
        {
            parent.Children[j + 1] = parent.Children[j];
        }

        parent.Children[index + 1] = newNode;

        for (int j = parent.KeyCount - 1; j >= index; j--)
        {
            parent.Keys[j + 1] = parent.Keys[j];
        }

        parent.Keys[index] = nodeToSplit.Keys[degree - 1];
        parent.KeyCount++;
    }

    private void InsertNonFull(BTreeNode node, int key)
    {
        int i = node.KeyCount - 1;

        if (node.IsLeaf)
        {
            while (i >= 0 && key < node.Keys[i])
            {
                node.Keys[i + 1] = node.Keys[i];
                i--;
            }
            node.Keys[i + 1] = key;
            node.KeyCount++;
        }
        else
        {
            while (i >= 0 && key < node.Keys[i])
            {
                i--;
            }
            i++;
            if (node.Children[i].KeyCount == 2 * degree - 1)
            {
                SplitChild(node, i, node.Children[i]);
                if (key > node.Keys[i])
                {
                    i++;
                }
            }
            InsertNonFull(node.Children[i], key);
        }
    }

    public void Print()
    {
        PrintTree(root);
    }

    private void PrintTree(BTreeNode node)
    {
        for (int i = 0; i < node.KeyCount; i++)
        {
            if (!node.IsLeaf)
            {
                PrintTree(node.Children[i]);
            }
            Console.Write(node.Keys[i] + " ");
        }

        if (!node.IsLeaf)
        {
            PrintTree(node.Children[node.KeyCount]);
        }
    }
}