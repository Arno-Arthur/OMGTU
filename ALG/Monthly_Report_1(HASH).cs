using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Queue dataQueue = new Queue(); 

        dataQueue.Enqueue(new CallData("123456789", new DateTime(2022, 1, 1), new TimeSpan(9, 0, 0), 30));
        dataQueue.Enqueue(new CallData("987654321", new DateTime(2022, 1, 1), new TimeSpan(10, 0, 0), 45));
        dataQueue.Enqueue(new CallData("123456789", new DateTime(2022, 1, 2), new TimeSpan(8, 0, 0), 20));
        

        Hashtable callMinutes = new Hashtable();

        while (dataQueue.Count > 0)
        {
            CallData call = (CallData)dataQueue.Dequeue();
            string phoneNumber = call.PhoneNumber;
            int callDuration = call.Duration;

            if (callMinutes.ContainsKey(phoneNumber)) callMinutes[phoneNumber] = (int)callMinutes[phoneNumber] + callDuration;
            else callMinutes.Add(phoneNumber, callDuration);

        }

        Console.WriteLine("Месячный отчёт по общей сумме разговора каждой даты:");
        foreach (DictionaryEntry entry in callMinutes)
        {
            Console.WriteLine("Номер телефона: {0}, Общее количество минут: {1}", entry.Key, entry.Value);
        }
    }
}

class CallData
{
    public string PhoneNumber { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public int Duration { get; private set; }

    public CallData(string phoneNumber, DateTime date, TimeSpan startTime, int duration)
    {
        PhoneNumber = phoneNumber;
        Date = date;
        StartTime = startTime;
        Duration = duration;
    }
}
