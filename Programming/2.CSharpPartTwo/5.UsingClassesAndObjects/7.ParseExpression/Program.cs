using System;
using System.Collections.Generic;

class Program
{
    // Evaluate a postfix expression
    static double EvaluateExpression(string output)
    {
        var tokens = output.Split(' ');
        var stack = new Stack<double>();

        double number = 0;
        foreach (string token in tokens)
            if (double.TryParse(token, out number)) stack.Push(number);
            else if (token == "+")    stack.Push(stack.Pop() + stack.Pop());
            else if (token == "-")    stack.Push(-stack.Pop() + stack.Pop());
            else if (token == "*")    stack.Push(stack.Pop() * stack.Pop());
            else if (token == "/")    stack.Push(1 / stack.Pop() * stack.Pop());
            else if (token == "ln")   stack.Push(Math.Log(stack.Pop(), Math.E));
            else if (token == "sqrt") stack.Push(Math.Sqrt(stack.Pop()));
            else if (token == "pow")  stack.Push(Math.Pow(y: stack.Pop(), x: stack.Pop())); // x ^ y

        return stack.Pop();
    }

    // TODO: Parse an infix expression to postfix
    static double ParseExpression(string input)
    {
        string output = "3 5.3 + 2.7 * 22 ln 2.2 -1.7 pow / -";

        return EvaluateExpression(output);
    }


    static void Main()
    {
        Console.WriteLine(ParseExpression("(3 + 5.3) * 2.7 - ln(22) / pow(2.2, -1.7)"));
    }
}
