using System;

class Program
{
    static void Main()
    {
        GenericList<int> intList = new GenericList<int>();

        for (int i = 0; i < 20; i++)
        {
            intList.Add(i);

            Console.WriteLine(intList);
            Console.WriteLine();
        }

        //while (intList.Count != 0)
        //{
        //    intList.Remove(intList.Count - 1);

        //    Console.WriteLine(intList);
        //    Console.WriteLine();
        //}

        Console.WriteLine(intList.Min());
        Console.WriteLine(intList.Max());

        //Console.WriteLine("# Remove element");
        //intList.Remove(1);

        //Console.WriteLine(intList);
        //Console.WriteLine();


        //Console.WriteLine("# Add element");
        
        //intList.Insert(0, 4);
        
        //Console.WriteLine(intList);
        //Console.WriteLine();

        //Console.WriteLine("# Clear");
        //intList.Clear();
        //intList.Add(1);

        //Console.WriteLine(intList);
        //Console.WriteLine();

        //Console.WriteLine("# Index of");
        //Console.WriteLine(intList.IndexOf(1));
    }
}
