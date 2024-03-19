using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

class StringExperiment
{
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string str = "1234567890";
        for (int i = 0; i < 1000000; i++)
        {
            char randomChar = (char)new Random().Next(0x0000, 0xFFFF + 1);
            int index = i % 10;
            str = str.Remove(index, 1).Insert(index, randomChar.ToString());
        }

        stopwatch.Stop();
        Console.WriteLine($"Время: {stopwatch.ElapsedMilliseconds} мс");

        Stopwatch stopwatchSB = new Stopwatch();
        stopwatchSB.Start();

        StringBuilder sb = new StringBuilder("1234567890");
        for (int i = 0; i < 1000000; i++)
        {
            char randomChar = (char)new Random().Next(0x0000, 0xFFFF + 1);
            int index = i % 10;
            sb[index] = randomChar;
        }

        stopwatchSB.Stop();
        Console.WriteLine($"Время StringBuilder: {stopwatchSB.ElapsedMilliseconds} мс");
    }
}
