string[] numbers = File.ReadAllLines("900.txt");
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
Console.WriteLine($"Количество пар элементов, произведение которых нечетное: {oddProductPairsCount}");
