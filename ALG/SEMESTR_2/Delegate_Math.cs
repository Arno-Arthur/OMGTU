namespace MathOperations
{
    public delegate double MathOperation(double a, double b);

    public interface IMathOperations
    {
        MathOperation Add { get; }
        MathOperation Subtract { get; }
        MathOperation Multiply { get; }
        MathOperation Divide { get; }
        MathOperation SquareRoot { get; }
        MathOperation Sin { get; }
        MathOperation Cos { get; }
    }

    public class Calculator : IMathOperations
    {
        public MathOperation Add => (a, b) => a + b;
        public MathOperation Subtract => (a, b) => a - b;
        public MathOperation Multiply => (a, b) => a * b;
        public MathOperation Divide => (a, b) => 
            {
                try
                {
                    return b != 0 ? a / b : throw new DivideByZeroException("Ошибка: деление на 0");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    return double.NaN; 
                }
            };
        public MathOperation SquareRoot => (a, b) => Math.Sqrt(a);
        public MathOperation Sin => (a, _) => Math.Sin(a);
        public MathOperation Cos => (a, _) => Math.Cos(a);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine("Математика" + "\n");
            Console.WriteLine("Выберите операцию:" + "\n" + "1 - Сложение" + "\n" + "2 - Вычитание" +
                                "\n" + "3 - Умножение" + "\n" + "4 - Деление" + "\n" + "5 - Корень" +
                                "\n" + "6 - Синус" + "\n" + "7 - Косинус" + "\n" + "8 - Выход" + "\n");

            while (true)
            {
                Console.Write("Ваш выбор: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 8)
                {
                    Console.WriteLine("Неправильный выбор операции");
                    continue;
                }

                if (choice == 8)
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                MathOperation operation = null;

                switch (choice)
                {
                    case 1:
                        operation = calculator.Add;
                        break;

                    case 2:
                        operation = calculator.Subtract;
                        break;

                    case 3:
                        operation = calculator.Multiply;
                        break;

                    case 4:
                        operation = calculator.Divide;
                        break;

                    case 5:
                        operation = calculator.SquareRoot;
                        break;

                    case 6:
                        operation = calculator.Sin;
                        break;

                    case 7:
                        operation = calculator.Cos;
                        break;
                }

                Console.Write("Введите число: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Ошибка - введите число в правильном формате.");
                    continue;
                }

                double result = 0;
                if (operation != null)
                {
                    if (choice != 5 && choice != 6 && choice != 7)
                    {
                        Console.Write("Введите второе число: ");
                        if (!double.TryParse(Console.ReadLine(), out double num2))
                        {
                            Console.WriteLine("Ошибка - введите число в правильном формате.");
                            continue;
                        }
                        result = operation(num1, num2);
                    }
                    else result = operation(num1, 0);

                    Console.WriteLine($"Результат операции: {result}" + "\n");
                }
            }
        }
    }
}
