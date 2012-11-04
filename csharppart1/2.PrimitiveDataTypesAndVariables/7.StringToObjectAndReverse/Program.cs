using System;

class Program
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object HelloWorldObject = hello + " " + world;
        string HelloWorldString = (string)HelloWorldObject;
        Console.WriteLine(HelloWorldString);
    }
}
