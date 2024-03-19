using System;
using System.Collections.Immutable;

class Program
{
    static void Main(string[] args)
    {
        /*SortedSet используется вместо HashSet для удобства перечисления элементов множества*/
        SortedSet<int> numbers1 = new SortedSet<int>();
        SortedSet<int> numbers2 = new SortedSet<int>();
        SortedSet<int> numbers3 = new SortedSet<int>();

        for (int i = 0; i < 13; i++)
        {
            numbers1.Add(i * 2);
            numbers2.Add(i * 3);
            numbers3.Add(i * 4);
        }

        PrintSet(numbers1, "1 множество: ");
        PrintSet(numbers2, "2 множество: ");
        PrintSet(numbers3, "3 множество: ");

        SortedSet<int> universalSet = new SortedSet<int>();
        universalSet.UnionWith(numbers1);
        universalSet.UnionWith(numbers2);
        universalSet.UnionWith(numbers3);
        PrintSet(universalSet, "Объединение: ");

        SortedSet<int> complement1 = new SortedSet<int>(universalSet);
        complement1.ExceptWith(numbers1);

        SortedSet<int> complement2 = new SortedSet<int>(universalSet);
        complement2.ExceptWith(numbers2);

        SortedSet<int> complement3 = new SortedSet<int>(universalSet);
        complement3.ExceptWith(numbers3);


        universalSet.IntersectWith(numbers1);
        universalSet.IntersectWith(numbers2);
        universalSet.IntersectWith(numbers3);
        PrintSet(universalSet, "Пересечение: ");

        PrintSet(complement1, "Дополнение 1: ");
        PrintSet(complement2, "Дополнение 2: ");
        PrintSet(complement3, "Дополнение 3: ");

    }
    static void PrintSet(SortedSet<int> set, string s)
    {
        Console.Write(s);
        foreach (int num in set)
            Console.Write(num + " ");
        Console.WriteLine("\n");
    }
}
