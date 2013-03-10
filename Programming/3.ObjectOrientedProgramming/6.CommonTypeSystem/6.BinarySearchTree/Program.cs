using System;

class Program
{
    static void Main()
    {
        BinarySearchTree<int> tree1 = new BinarySearchTree<int>();

        for (int i = 1; i < 10; i++)
            tree1.Add(i);

        tree1.Add(-5);

        //BinarySearchTree<int> tree2 = new BinarySearchTree<int>();

        //for (int i = 0; i < tree1.Count; i++)
        //    tree2.Add(i);

        Console.WriteLine(tree1);
        //Console.WriteLine(tree1.Contains(11));

        Console.WriteLine((tree1.Clone() as BinarySearchTree<int>) == tree1);
    }
}
