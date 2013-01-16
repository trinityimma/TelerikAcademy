using System;

class Program
{
    // Evaluate a postfix expression
    static double EvaluateExpression(string expression)
    {
        double[] st = new double[64]; // Stack
        int p = 0; // Stack pointer

        foreach (string token in expression.Split(' '))
            if      (token == "+"   ) st[--p - 1] += st[p];
            else if (token == "-"   ) st[--p - 1] -= st[p];
            else if (token == "*"   ) st[--p - 1] *= st[p];
            else if (token == "/"   ) st[--p - 1] /= st[p];
            else if (token == "pow" ) st[--p - 1]  = Math.Pow  (st[p - 1], st[p]);
            else if (token == "sqrt") st[  p - 1]  = Math.Sqrt (st[p - 1]);
            else if (token == "ln"  ) st[  p - 1]  = Math.Log  (st[p - 1], Math.E);
            else st[p++] = double.Parse(token);

        return st[0];
    }

    // TODO: Parse an infix expression to postfix
    static double ParseExpression(string infix)
    {
        string postfix = "3 5.3 + 2.7 * 22 ln 2.2 -1.7 pow / -";

        return EvaluateExpression(postfix);
    }


    static void Main()
    {
        Console.WriteLine(ParseExpression("(3 + 5.3) * 2.7 - ln(22) / pow(2.2, -1.7)"));
    }
}
