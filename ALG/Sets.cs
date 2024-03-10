using System;

class Program
{
    static void Main(string[] args)
    {
        string[] soft = { "Microsoft", "Google", "Apple", "AMD", "Xiaomi" };
        string[] hard = { "Apple", "IBM", "Samsung", "Toshiba" };
        string[] company = { "Apple", "IBM" };

        Console.WriteLine("Пересечение: ");
        var cross = soft.Intersect(hard).Intersect(company);
        foreach (string s in cross)
        {
            Console.WriteLine("\t" + s);
        }

        Console.WriteLine("\n" + "Объединение: ");
        var unity = soft.Union(hard).Union(company);       
        foreach (string s in unity)
        {
            Console.WriteLine("\t" + s);
        }

        Console.WriteLine("\n" + "Дополнение 1: ");
        var soft_add = unity.Except(soft);
        foreach (string s in soft_add)
        {
            Console.WriteLine("\t" + s);
        }

        Console.WriteLine("\n" + "Дополнение 2: ");
        var hard_add = unity.Except(hard);
        foreach (string s in hard_add)
        {
            Console.WriteLine("\t" + s);
        }

        Console.WriteLine("\n" + "Дополнение 3: ");
        var company_add = unity.Except(company);
        foreach (string s in company_add)
        {
            Console.WriteLine("\t" + s);
        }
    }
}
