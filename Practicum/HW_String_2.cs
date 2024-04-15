using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = "The time is 12:30";
        var regex = new Regex(@"\b(?:[01][0-9]|2[0-3]):[0-5][0-9]\b");
        var matches = regex.Matches(input).Cast<Match>().Select(x => x.Value);
        foreach (var match in matches)
        {
            Console.Write($"Найденное время: {match}");
        }
    }
}
