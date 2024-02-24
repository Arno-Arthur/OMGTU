using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            int size;
            int choice;

            Console.Write("Меню Array" + "\n");

            do
            {
                Console.Write("Введите размерность массива: ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 1) break;
                else Console.WriteLine("Введите целое число, большее или равное 1");
            }
            while (true);

            int[] array = new int[size];
            Console.WriteLine();
            Console.WriteLine("Введите массив: ");

            for (int i = 0; i < size; i++)
            {
                do
                {
                    Console.Write("Элемент " + (i + 1) + " = ");
                    if (int.TryParse(Console.ReadLine(), out array[i])) break;
                    else Console.WriteLine("Введите целое число");
                }
                while (true);
            }
            
            Console.Write("\n" + "Ваш массив: ");
            foreach (var num in array)
            {
                Console.Write(num + " ");
            }
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
                        int element;

                        do
                        {
                            Console.Write("Введите искомый элемент: ");
                            if (int.TryParse(Console.ReadLine(), out element)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        int element_count = array.Count(x => x == element);
                        Console.WriteLine("Количество элементов: " + element_count + "\n ");
                        break;


                    case 2:
                        int target;
                        Array.Sort(array);
                        Console.WriteLine("Массив-sort: " + string.Join(" ", array));

                        do
                        {
                            Console.Write("Введите искомый элемент: ");
                            if (int.TryParse(Console.ReadLine(), out target)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        int index = Array.BinarySearch(array, target);
                        if (index >= 0) Console.WriteLine("Элемент " + target + " найден в массиве на позиции " + index + "\n ");
                        else Console.WriteLine("Элемент не найден" + "\n ");
                        break;


                    case 3:
                        int[] copy_array = new int[array.Length];
                        array.CopyTo(copy_array, 0);
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

                        int result_min = Array.Find(array, x => x < find);
                        if (result_min != 0) Console.WriteLine("Первое число, меньшее чем " + find + ", " + result_min );
                        else Console.WriteLine("Таких чисел нет или оно равно 0");

                        int result_max = Array.Find(array, x => x > find);
                        if (result_max != 0) Console.WriteLine("Первое число, большее чем " + find + ", " + result_max );
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

                        int result_min_last = Array.FindLast(array, x => x < find_last);
                        if (result_min_last != 0) Console.WriteLine("Последнее число, меньшее чем " + find_last + ", " + result_min_last);
                        else Console.WriteLine("Таких чисел нет или оно равно 0");

                        int result_max_last = Array.FindLast(array, x => x > find_last);
                        if (result_max_last != 0) Console.WriteLine("Последнее число, большее чем " + find_last + ", " + result_max_last);
                        else Console.WriteLine("Таких чисел нет или оно равно 0");
                        Console.WriteLine("\n");
                        break;


                    case 6:
                        int search_element;
  
                        do
                        {
                            Console.Write("Искомое число: ");
                            if (int.TryParse(Console.ReadLine(), out search_element)) break;
                            else Console.WriteLine("Введите целое число");
                        }
                        while (true);

                        int indexOF = Array.IndexOf(array, search_element);
                        if (indexOF != -1) Console.WriteLine("Элемент " + search_element + " найден в массиве на позиции " + indexOF + "\n ");
                        break;


                    case 7:
                        Array.Reverse(array);
                        Console.WriteLine("Массив-reverse: " + string.Join(" ", array) + "\n ");
                        break;


                    case 8:
                        int re_size;

                        do
                        {
                            Console.Write("Введите больший размер массива: ");
                            if (int.TryParse(Console.ReadLine(), out re_size) && re_size >= 1) break;
                            else Console.WriteLine("Введите целое число, большее или равное 1");
                        }
                        while (true);
                        
                        Array.Resize(ref array, array.Length + re_size);
                        Console.WriteLine("Массив-resize: " + string.Join(" ", array) + "\n ");
                        break;


                    case 9:
                        Array.Sort(array);
                        Console.WriteLine("Массив-sort: " + string.Join(" ", array) + "\n ");
                        break;


                    case 10:
                        Console.WriteLine("Конец");
                        flag = false;
                        break;
                }

            }
            
        }
    }
}
