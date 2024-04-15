using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = "test-dq@gasa.11";
        var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$");
        var matches = regex.Matches(input).Cast<Match>().Select(x => x.Value);
        foreach (var match in matches) Console.WriteLine($"Найденный email: {match}");
    }
}
