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
            if (IsNumber(item))
            {
                stack.Push(double.Parse(item));
            }
            else if (item.Length == 1 && operators.ContainsKey(item[0]))
            {
                if (stack.Count < 2)
                {
                    Console.WriteLine("Error: Недостаточно для вычисления");
                    return double.MinValue;
                }
                else
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();

                    // Проверка деления на ноль
                    if (operand2 == 0 && item[0] == '/')
                    {
                        Console.WriteLine("Error: деление на 0");
                        return double.MinValue;
                    }

                    double result = operators[item[0]](operand1, operand2);
                    stack.Push(result);
                }
            }
            else
            {
                Console.WriteLine("Error: неверный ввод");
                return double.MinValue;
            }
        }

        if (stack.Count == 1)
        {
            return stack.Peek();
        }
        else
        {
            Console.WriteLine("Error: неверный ввод");
            return double.MinValue;
        }
    }


    static void Main()
    {
        Console.Write("Введите 1-ое число: ");
        string A = Console.ReadLine();

        Console.Write("Введите 2-ое число: ");
        string B = Console.ReadLine();

        List<string> rpnExpression = new List<string> {A, B, "+", "3", "/"};
        double result = EvaluateRPN(rpnExpression);

        if (result.Equals(double.MinValue)) Console.WriteLine("Error: неверное выражение");
        else Console.WriteLine("Ответ: " + result);

    }
}
