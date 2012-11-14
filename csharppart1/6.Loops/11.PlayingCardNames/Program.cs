using System;

class Program
{
    static void Main()
    {
        string[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        string[] suits = { "spades", "diamonds", "hearts", "clubs" };
        for (int i = 0; i < 52; i++) Console.WriteLine(names[i % 13] + " of " + suits[i % 4]);
    }
}
