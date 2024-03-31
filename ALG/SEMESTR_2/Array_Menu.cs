namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            int size, choice;

            Console.Write("Меню Array" + "\n");

            do
            {
                Console.Write("Введите размерность массива: ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 1) break;
                else Console.WriteLine("Введите целое число, большее или равное 1");
            }
            while (true);

            Array myArray = Array.CreateInstance(typeof(object), size);
            Console.WriteLine("\n" + "Введите массив: ");

            for (int i = 0; i < size; i++)
            {
                Console.Write("Элемент {0} = ", i + 1);
                myArray.SetValue(Console.ReadLine(), i);
            }

            Console.Write("\n" + "Ваш массив: ");
            PrintArray(myArray);
            Console.WriteLine("\n");

            while (flag)
            {
                Console.WriteLine("Выберите метод:" + "\n" + "1 - Count" + "\n" + "2 - BinSearch" + "\n" + "3 - Copy" +
                "\n" + "4 - Find" + "\n" + "5 - FindLast" + "\n" + "6 - IndexOf" +
                "\n" + "7 - Reverse" + "\n" + "8 - Resize" + "\n" + "9 - Sort" + "\n" + "10 - Exit");

                do
                {
                    Console.Write("\n" + "Ваш метод: ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1) break;
                    else Console.WriteLine("Введите целое число от 1 до 10");
                }
                while (true);

                switch (choice)
                {

                    case 1:
                        int count = 0;

                        Console.Write("Введите искомый элемент: ");
                        object search_element = Console.ReadLine();

                        foreach (var item in myArray)
                        {
                            if (item.Equals(search_element)) count++;
                        }
                        Console.WriteLine(@"Количество элементов: {0}" + "\n", count);
                        break;


                    case 10:
                        Console.WriteLine("Конец");
                        flag = false;
                        break;
                }
            }
        }

        public static void PrintArray(Array array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    } 
}
