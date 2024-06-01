class PolishNotation
{
    public void PolNotation()
    {
        Console.Write("Введите выражение записанное в обратной польской нотации.\n" +
                      "Ввод каждого символа через пробел. Пример: 3 3 + 2 *\n" +
                      "\nВаше выражение: ");
        string polNotation = Console.ReadLine();
        Stack<double> stack = new Stack<double>();
        string[] tokens = polNotation.Split(' ');
        bool notError = true;

        foreach (string token in tokens)
        {
            double number;
            if (double.TryParse(token, out number)) stack.Push(number);

            else if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                if (stack.Count < 2)
                {
                    Console.WriteLine("Ошибка: недостаточно чисел в стеке для операции.\n");
                    notError = false;
                    break;
                }

                double num1 = stack.Pop();
                double num2 = stack.Pop();
                switch (token)
                {
                    case "+": stack.Push(num2 + num1); break;
                    case "-": stack.Push(num2 - num1); break;
                    case "*": stack.Push(num2 * num1); break;
                    case "/":
                        if (num1 != 0) stack.Push(num2 / num1);
                        else
                        {
                            Console.WriteLine("Попытка деления на ноль!\n");
                            notError = false;
                            break;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Недопустимый символ: {token}\n");
                notError = false;
                break;
            }
        }
        if (notError)
        {
            if (stack.Count == 1) Console.WriteLine($"Значение выражения равно: {stack.Pop()}\n");
            else Console.WriteLine("Ошибка: в стеке остались лишние числа.\n");
        }
    }
}

class SequenceBrackets
{
    public void SB()
    {
        bool flag = false;
        Console.Write("Введите последовательность скобок.\n" +
                          "Пример: ([){)\nВаше выражение: ");
        string brackets = Console.ReadLine();
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> mapping = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        foreach (char c in brackets)
        {
            if (!mapping.ContainsValue(c) && !mapping.ContainsKey(c))
            {
                Console.WriteLine("Обнаружен недопустимый символ: " + c);
                flag = true;
                break;
            }

            if (mapping.ContainsValue(c)) stack.Push(c);
            else if (mapping.ContainsKey(c))
            {
                if (stack.Count == 0 || mapping[c] != stack.Pop())
                {
                    flag = true;
                    break;
                }
            }
        }
        if (flag || stack.Count != 0) Console.WriteLine("Последовательность скобок задана некорректно\n");
        else Console.WriteLine("Последовательность скобок задана корректно\n");
    }
}

class Menu
{
    static void Main(string[] args)
    {
        bool flag = true;
        int choice;
        int second_choice;

        while (flag)
        {
            Console.Write("Выберите пункт:\n" +
                "1 - Автор\n" +
                "2 - Подсчёт значения обратной польской записи\n" +
                "3 - Проверка скобочной последовательности на корректность\n" +
                "4 - Выход\n");
            do
            {
                Console.Write("\n" + "Ваш пункт: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4) break;
                else Console.WriteLine("Введите целое число от 1 до 4");
            }
            while (true);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n" + "Автор:\nРепин Артур Александрович\n" +
                                        "Студент ОмГТУ, ФИТиКС, 1 курс, группа ФИТ-231\n");
                    break;

                case 2:
                    while (true)
                    {
                        Console.Write("Выберите действие:\n1 - Данные о задаче\n" +
                                            "2 - Подсчёт значения выражения, предоставленного " +
                                            "в виде обратной польской записи\n" +
                                            "3 - Вернуться в главное меню\n");
                        do
                        {
                            Console.Write("\n" + "Ваш пункт: ");
                            if (int.TryParse(Console.ReadLine(), out second_choice) && second_choice >= 1 && second_choice <= 3) break;
                            else Console.WriteLine("Введите целое число от 1 до 3");
                        }
                        while (true);
                        
                        Console.Clear();

                        if (second_choice == 1)
                            Console.WriteLine("На вход подаётся выражение записанное " +
                                              "в обратной польской нотации.\n" +
                                              "Программа вычисляет значение на основе данного выражения\n");
                        else if (second_choice == 2)
                        {
                            PolishNotation polishNotation = new PolishNotation();
                            polishNotation.PolNotation();
                        }
                        else if (second_choice == 3) break;
                    }
                    break;

                case 3:
                    while (true)
                    {
                        Console.Write("Выберите действие:\n1 - Данные о задаче\n" +
                                            "2 - Проверить скобочную последовательность " +
                                            "на корректность\n" +
                                             "3 - Вернуться в главное меню\n");
                        do
                        {
                            Console.Write("\n" + "Ваш пункт: ");
                            if (int.TryParse(Console.ReadLine(), out second_choice) && second_choice >= 1 && second_choice <= 3) break;
                            else Console.WriteLine("Введите целое число от 1 до 3");
                        }
                        while (true);

                        Console.Clear();

                        if (second_choice == 1)
                            Console.WriteLine("На вход подаётся последовательность скобок\n" +
                                              "Программа выявляет корректо ли задана " +
                                              "скобочная последовательность\n");
                        else if (second_choice == 2)
                        {
                            SequenceBrackets sequenceBrackets = new SequenceBrackets();
                            sequenceBrackets.SB();
                        }
                        else if (second_choice == 3) break;
                    }
                    break;

                case 4:
                    Console.WriteLine("Выход из программы");
                    flag = false;
                    break;
            }
        }
    }
}
