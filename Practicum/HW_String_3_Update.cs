using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "exam@mple.com, 123_-456@arno.org, и test_dq@gasa.1";
        
        var regex = new Regex(@"\b[\w-\.]+@([\w-]+\.)+[\w-]{2,}\b");
        var matches = regex.Matches(text);
        
        Console.WriteLine("Найденные email'ы:");
        foreach (Match match in matches) Console.WriteLine(match.Value);
    }
}
