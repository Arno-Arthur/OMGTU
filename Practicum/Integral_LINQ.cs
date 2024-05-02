public static double CalculateIntegral(Func<double, double> func, double intervalStart, double intervalEnd, double dx)
{
    if (Math.Abs(dx) < Math.Pow(10, -7)) throw new Exception("dx близок к машинному нулю");
    if (!double.IsNormal(intervalStart)) throw new Exception("Начало интервала не является числом");
    if (!double.IsNormal(intervalEnd)) throw new Exception("Конец интервала не является числом");
    if (intervalStart > intervalEnd) throw new Exception("Неверно заданы границы интервала");

    int intervals = (int)((intervalEnd - intervalStart) / dx);

    double result = Enumerable.Range(0, intervals) // Метод Enumerable.Range создает последовательность целых чисел от 0 до intervals-1
                               .Select(i => // Метод Select применяет заданную операцию к каждому элементу этой последовательности. 
                               {
                                   double x1 = intervalStart + i * dx;
                                   double x2 = intervalStart + (i + 1) * dx;
                                   double area = Math.Abs((func(x1) + func(x2)) / 2 * dx);
                                   return area;
                               })
                               .Sum(); // Метод для суммирования

    return result;
}
--------------------------------------------------------------
try
{
    double result = CalculateIntegral((double x) => -x * x + 9, -3, 3, 0.1);
    Console.WriteLine(result);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
