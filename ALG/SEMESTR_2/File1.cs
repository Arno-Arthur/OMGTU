class Program
    {
        static void Main()
        {
            string inputFilePath1 = "C:\\Users\\User\\Desktop\\txt\\ConsoleApplication2\\ConsoleApplication2\\1.txt"; //1-3-5-7-9
            string inputFilePath2 = "C:\\Users\\User\\Desktop\\txt\\ConsoleApplication2\\ConsoleApplication2\\2.txt"; //2-4-6-8-10
            string outputFilePath = "C:\\Users\\User\\Desktop\\txt\\ConsoleApplication2\\ConsoleApplication2\\3.txt"; //пустой

            using (StreamReader reader1 = new StreamReader(inputFilePath1))
            using (StreamReader reader2 = new StreamReader(inputFilePath2))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();

                while (line1 != null && line2 != null)
                {
                    int num1 = int.Parse(line1);
                    int num2 = int.Parse(line2);

                    if (num1 < num2)
                    {
                        writer.WriteLine(num1);
                        line1 = reader1.ReadLine();
                    }
                    else
                    {
                        writer.WriteLine(num2);
                        line2 = reader2.ReadLine();
                    }
                }

                while (line1 != null)
                {
                    int num1 = int.Parse(line1);
                    writer.WriteLine(num1);
                    line1 = reader1.ReadLine();
                }

                while (line2 != null)
                {
                    int num2 = int.Parse(line2);
                    writer.WriteLine(num2);
                    line2 = reader2.ReadLine();
                }
            }

            Console.WriteLine("Файлы успешно объединены и отсортированы в файле 3.txt"); //1-2-3-4-5-6-7-8-9-10
        }
    }
