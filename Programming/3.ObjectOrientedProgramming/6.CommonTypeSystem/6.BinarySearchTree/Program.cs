using System;

class Program
{
    static void Main()
    {
        BinarySearchTree<int> tree1 = new BinarySearchTree<int>();

        for (int i = 1; i < 10; i++)
            tree1.Add(i);

        //BinarySearchTree<int> tree2 = new BinarySearchTree<int>();

        //for (int i = 0; i < 10; i++)
        //    tree2.Add(i);

        Console.WriteLine(tree1);
        Console.WriteLine(tree1.Find(11));

        Console.WriteLine(tree1.Clone());
    }
}
