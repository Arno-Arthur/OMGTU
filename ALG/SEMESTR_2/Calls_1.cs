using System;
using System.Collections.Generic;
using System.Linq;

class Call
{
    public string CallerNumber { get; set; }
    public string ReceiverNumber { get; set; }
    public DateTime CallDate { get; set; }
    public int DurationMinutes { get; set; }
}

class Program
{
    static void Main()
    {
        List<Call> calls = new List<Call>
        {
            new Call { CallerNumber = "555-1234", ReceiverNumber = "666-5678", CallDate = new DateTime(2022, 1, 1), DurationMinutes = 10 },
            new Call { CallerNumber = "555-1234", ReceiverNumber = "777-9876", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 15 },
            new Call { CallerNumber = "555-1234", ReceiverNumber = "666-5678", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 20 },
            new Call { CallerNumber = "555-1234", ReceiverNumber = "888-2468", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 25 },
            new Call { CallerNumber = "555-1234", ReceiverNumber = "888-2468", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 25 }
        };
        
        string selectedCallerNumber = "555-1234";
        
        var mostFrequentReceiverNumbersByDate = calls.Where(c => c.CallerNumber == selectedCallerNumber)
                                                    .GroupBy(c => new { c.CallDate, c.ReceiverNumber })
                                                    .OrderByDescending(g => g.Count())
                                                    .GroupBy(g => g.Key.CallDate)
                                                    .Select(g =>
                                                    {
                                                        var mostFrequentReceiverNumber = g.FirstOrDefault()?.Key.ReceiverNumber;
                                                        return new
                                                        {
                                                            CallDate = g.Key,
                                                            CallerNumber = selectedCallerNumber,
                                                            MostFrequentReceiverNumber = mostFrequentReceiverNumber
                                                        };
                                                    });
        
        foreach (var data in mostFrequentReceiverNumbersByDate)
        {
            Console.WriteLine($"Дата: {data.CallDate}, Абонент {data.CallerNumber} чаще всего звонил на номер: {data.MostFrequentReceiverNumber}");
        }
    }
}
