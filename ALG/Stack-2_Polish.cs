using System;
using System.Collections.Generic;

class Program
{
    static bool IsNumber(string item)
    {
        double value;
        return double.TryParse(item, out value);
    }

    static double EvaluateRPN(List<string> rpnList)
    {
        Stack<double> stack = new Stack<double>();
        Dictionary<char, Func<double, double, double>> operators = new Dictionary<char, Func<double, double, double>>
        {
            {'+', (x, y) => x + y },
            {'-', (x, y) => x - y },
            {'*', (x, y) => x * y },
            {'/', (x, y) => x / y }
        };

        foreach (string item in rpnList)
        {
            if (IsNumber(item)) stack.Push(double.Parse(item));           
            else if (operators.ContainsKey(item[0]))
            {
                if (stack.Count < 2) return double.MinValue;
                else
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    double result = operators[item[0]](operand1, operand2);
                    stack.Push(result);
                }
            }
            else return double.MinValue;
        }

        if (stack.Count == 1) return stack.Peek();
        else return double.MinValue;
    }

    static void Main()
    {
        List<string> rpnExpression = new List<string> { "-A", "0", "+", "2", "*" };
        double result = EvaluateRPN(rpnExpression);
        Console.WriteLine(result);
    }
}
