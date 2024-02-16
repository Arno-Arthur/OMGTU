public class SquareEquation
{
    public static List<double> Solve(double a, double b, double c)
    {
        double e = Math.Pow(10, -7);
        Console.WriteLine("Ваше уравнение: " + a + "x^2 + " + b + "x +" + c);
        if (Math.Abs(a) < e) throw new ArgumentException("Не квадратное уравнение");

        List<double> w = new List<double>();

        double discr = (b * b) - 4 * a * c;
        Console.WriteLine("Дискриминант: " + discr);

        if (discr > 0)
        {
            w.Add((b * (-1) - Math.Sqrt(discr)) / 2 * a);
            w.Add((b * (-1) + Math.Sqrt(discr)) / 2 * a);
        }
        else if (discr == 0)
        {

            w.Add((b * (-1) + Math.Sqrt(discr)) / 2 * a);
        }
        else if (discr < 0) throw new ArgumentException("Не имеет действительных корней");

        return w;
    }
}
