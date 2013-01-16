using System;
using System.Collections.Generic;

class Program
{
    // Evaluates a Reverse polish notation expression
    static double EvaluateExpression(string output)
    {
        var tokens = output.Split(' ');
        var stack = new Stack<double>();

        double number = 0;
        foreach (string token in tokens)
            if (double.TryParse(token, out number)) stack.Push(number);
            else if (token == "+") stack.Push(stack.Pop() + stack.Pop());
            else if (token == "-") stack.Push(-stack.Pop() + stack.Pop());
            else if (token == "*") stack.Push(stack.Pop() * stack.Pop());
            else if (token == "/") stack.Push(1 / stack.Pop() * stack.Pop());
            else if (token == "ln") stack.Push(Math.Log(stack.Pop(), Math.E));
            else if (token == "sqrt") stack.Push(Math.Sqrt(stack.Pop()));
            else if (token == "pow") stack.Push(Math.Pow(y: stack.Pop(), x: stack.Pop()));

        return stack.Pop();
    }

    // Parse infix to RPN
    static double ParseExpression(string input)
    {
        string output = "3 5.3 + 2.7 * 22 ln 2.2 -1.7 pow / -";

        // TODO

        return EvaluateExpression(output);
    }


    static void Main()
    {
        Console.WriteLine(ParseExpression("(3 + 5.3) * 2.7 - ln(22) / pow(2.2, -1.7)")); // 10.6
        // Console.WriteLine(ParseExpression("pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)")); // 21.22
    }
}
