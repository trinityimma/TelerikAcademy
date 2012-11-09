// Write a program to read your age from the console and print how old you will
// be after 10 years.

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Your age after 10 years: " + (age + 10));
    }
}
