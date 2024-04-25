class Program
{
    static void Main()
    {
        string path = "C:\\Users\\Admin\\source\\repos\\ConsoleApp\\ConsoleApp\\TextFile1.txt";
        
        FileInfo fileInfo = new FileInfo(path);

        if (fileInfo.Exists)
        {
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
            Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Размер: {fileInfo.Length}");
        }

        string[] numbers = File.ReadAllLines(path);
        int oddProductPairsCount = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int number1 = int.Parse(numbers[i]);
                int number2 = int.Parse(numbers[j]);

                if ((number1 * number2) % 2 != 0) oddProductPairsCount++;
            }
        }
        Console.WriteLine($"\nКоличество пар элементов, произведение которых нечетное: {oddProductPairsCount}");

        /* Файл: 
         * 2
         * 3
         * 5
         * 7
        */
    }
}
