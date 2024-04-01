namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            int size;
            int choice;
            int number;

            Console.Write("Меню Array" + "\n");

            do
            {
                Console.Write("Введите размерность массива: ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 1) break;
                else Console.WriteLine("Введите целое число, большее или равное 1");
            }
            while (true);

            Array myArray = Array.CreateInstance(typeof(Int32), size);
            Console.WriteLine();
            Console.WriteLine("Введите массив: ");

            for (int i = 0; i < size; i++)
            {
                do
                {
                    Console.Write("Элемент {0} = ", i + 1);
                    if (int.TryParse(Console.ReadLine(), out number)) break;
                    else Console.WriteLine("Введите целое число");
                }
                while (true);
                myArray.SetValue(number, i);

            }

            Console.Write("\n" + "Ваш массив: ");
            PrintArray(myArray);
            

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
                        int element;
                        int count = 0;

                        do
                        {
                            Console.Write("Введите искомый элемент: ");
                            if (int.TryParse(Console.ReadLine(), out element)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        Console.WriteLine("Количество элементов: " + ((int[])myArray).Count(x => x == element) + "\n");
                        break;


                    case 2:
                        int target;
                        Array.Sort(myArray);
                        Console.Write("Массив-sort: ");
                        PrintArray(myArray);

                        do
                        {
                            Console.Write("Введите искомый элемент: ");
                            if (int.TryParse(Console.ReadLine(), out target)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        int index = Array.BinarySearch(myArray, target);
                        if (index >= 0) Console.WriteLine("Элемент " + target + " найден в массиве на позиции " + index + "\n ");
                        else Console.WriteLine("Элемент не найден" + "\n ");
                        break;


                    case 3:
                        int[] copy_array = new int[myArray.Length];
                        myArray.CopyTo(copy_array, 0);
                        Console.WriteLine("Скопированный массив: " + string.Join(" ", copy_array) + "\n ");
                        break;


                    case 4:
                        int find;
                        do
                        {
                            Console.Write("Начальное число: ");
                            if (int.TryParse(Console.ReadLine(), out find)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        int result_min = Array.Find((int[])myArray, x => x < find);
                        if (result_min != 0) Console.WriteLine("Первое число, меньшее чем " + find + ", " + result_min);
                        else Console.WriteLine("Таких чисел нет или оно равно 0");

                        int result_max = Array.Find((int[])myArray, x => x > find);
                        if (result_max != 0) Console.WriteLine("Первое число, большее чем " + find + ", " + result_max);
                        else Console.WriteLine("Таких чисел нет или оно равно 0");
                        Console.WriteLine("\n");
                        break;


                    case 5:
                        int find_last;

                        do
                        {
                            Console.Write("Начальное число: ");
                            if (int.TryParse(Console.ReadLine(), out find_last)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        int result_min_last = Array.FindLast((int[])myArray, x => x < find_last);
                        if (result_min_last != 0) Console.WriteLine("Последнее число, меньшее чем " + find_last + ", " + result_min_last);
                        else Console.WriteLine("Таких чисел нет или оно равно 0");

                        int result_max_last = Array.FindLast((int[])myArray, x => x > find_last);
                        if (result_max_last != 0) Console.WriteLine("Последнее число, большее чем " + find_last + ", " + result_max_last);
                        else Console.WriteLine("Таких чисел нет или оно равно 0");
                        Console.WriteLine("\n");
                        break;


                    case 6:
                        int search;

                        do
                        {
                            Console.Write("Искомое число: ");
                            if (int.TryParse(Console.ReadLine(), out search)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        int indexOF = Array.IndexOf(myArray, search);
                        if (indexOF != -1) Console.WriteLine("Элемент " + search + " найден в массиве на позиции " + indexOF + "\n ");
                        break;


                    case 7:
                        Array.Reverse(myArray);
                        Console.WriteLine("Массив-reverse: ");
                        PrintArray(myArray);
                        break;


                    case 8:
                        int re_size;

                        do
                        {
                            Console.Write("Введите новый размер массива: ");
                            if (int.TryParse(Console.ReadLine(), out re_size) && re_size >= 1) break;
                            else Console.WriteLine("Введите целое число, большее или равное 1");
                        }
                        while (true);

                        
                        int[] array = (int[])myArray;
                        Array.Resize(ref array, re_size);
                        Console.Write("Массив-resize: ");
                        PrintArray(array);
                        break;


                    case 9:
                        Array.Sort(myArray);
                        Console.WriteLine("Массив-sort: ");
                        PrintArray(myArray);
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
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine("\n");
        }
    }
}
