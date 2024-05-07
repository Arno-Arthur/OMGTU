//Входной файл:
//aa aaa
//ab c aaa
//a a
//a a a
//ab
// 
// a
// Результат: 'a'
class Program
{
    static void Main()
    {
        string filename = "C:\\Users\\User\\Desktop\\txt\\ConsoleApplication2\\ConsoleApplication2\\1.txt"; 
        Console.WriteLine($"Строка с наименьшей подпоследовательностью 'a': {FindShortestASequence(filename)}");
    }

    static string FindShortestASequence(string filename)
    {
        int shortestLength = int.MaxValue;
        string lineWithShortestASequence = string.Empty;

        foreach (var line in File.ReadLines(filename))
        {
            var sequences = line.Replace(" ", "").Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                                .Where(seq => seq.All(c => c == 'a'));
            
            if (string.IsNullOrWhiteSpace(line) || !sequences.Any()) continue;


            
            foreach (var seq in sequences)
            {
                if (seq.Length < shortestLength)
                {
                    shortestLength = seq.Length;
                    lineWithShortestASequence = line;
                }
            }
        }

        return string.IsNullOrEmpty(lineWithShortestASequence) ? "Нет подходящих строк" : lineWithShortestASequence;
    }
}
