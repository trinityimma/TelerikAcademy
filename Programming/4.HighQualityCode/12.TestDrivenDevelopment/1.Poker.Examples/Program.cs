using System;

namespace Poker.Examples
{
    class Program
    {
        static void Main()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();

            Console.WriteLine(checker.IsStraightFlush((Hand)"J♣ 10♣ 9♣ 8♣ 7♣"));
        }
    }
}
