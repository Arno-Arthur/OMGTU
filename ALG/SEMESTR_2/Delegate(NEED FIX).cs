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
        public MathOperation Divide => (a, b) => b != 0 ? a / b : throw new ArgumentException("Ошибка - деление на 0");
        public MathOperation SquareRoot => (a, _) => Math.Sqrt(a);
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
                                "\n" + "6 - Синус" + "\n" + "7 - Косинус" + "\n");

            Console.Write("Ваш выбор: ");
            int choice = int.Parse(Console.ReadLine());
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

                default:
                    Console.WriteLine("Неправильный выбор операции");
                    return;
            }

            Console.Write("Введите число: ");
            double num1 = double.Parse(Console.ReadLine());

            double result = 0;
            if (operation != null)
            {
                if (choice != 5 && choice != 6 && choice != 7)
                {
                    Console.Write("Введите второе число: ");
                    double num2 = double.Parse(Console.ReadLine());
                    result = operation(num1, num2);
                }
                else result = operation(num1, 0);

                Console.WriteLine($"Результат операции: {result}");
            }
        }
    }
}
