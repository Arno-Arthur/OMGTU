using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Меню Array" + "\n" + "Введите размерность массива: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Console.WriteLine("Введите массив: ");

            for (int i = 0; i < size; i++)
            {
                Console.Write("Элемент " + (i + 1) + " = ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Ваш массив: ");
            foreach (var num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Выберите метод:" + "\n" + "1 - Count" + "\n" + "2 - BinSearch" + "\n" + "3 - Copy" +
                "\n" + "4 - Find" + "\n" + "5 - FindLast" + "\n" + "6 - IndexOf" +
                "\n" + "7 - Reverse" + "\n" + "8 - Resize" + "\n" + "9 - Sort");
            Console.Write("Ваш метод: ");
            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:
                     Console.Write("Введите искомый элемент: ");
                    int element = int.Parse(Console.ReadLine());
                    int element_count = array.Count(x => x == element);
                    Console.WriteLine("Количество элементов: " + element_count);
                    break;

                case 2:
                    Console.Write("Введите искомый элемент: ");
                    int target = int.Parse(Console.ReadLine());
                    int index = Array.BinarySearch(array, target);
                    if (index >= 0) Console.WriteLine("Элемент " + target + " найден в массиве на позиции " + index);
                    else Console.WriteLine("Элемент не найден");
                    break;

                case 3:
                    int[] copy_array = new int[array.Length];
                    array.CopyTo(copy_array, 0);
                    Console.WriteLine("Скопированный массив: " + string.Join(" ", copy_array));
                    break;

                case 4:
                    Console.Write("Начальное число: ");
                    int find = int.Parse(Console.ReadLine());

                    int result_min = Array.Find(array, x => x < find);
                    if (result_min != 0) Console.WriteLine("Первое число, меньшее чем " + find + ", " + result_min);
                    else Console.WriteLine("Таких чисел нет или оно равно 0");

                    int result_max = Array.Find(array, x => x > find);
                    if (result_max != 0) Console.WriteLine("Первое число, большее чем " + find + ", " + result_max);
                    else Console.WriteLine("Таких чисел нет");
                    break;

                case 5:
                    Console.Write("Начальное число: ");
                    int find_last = int.Parse(Console.ReadLine());

                    int result_min_last = Array.FindLast(array, x => x < find_last);
                    if (result_min_last != 0) Console.WriteLine("Последнее число, меньшее чем " + find_last + ", " + result_min_last);
                    else Console.WriteLine("Таких чисел нет или оно равно 0");

                    int result_max_last = Array.FindLast(array, x => x > find_last);
                    if (result_max_last != 0) Console.WriteLine("Последнее число, большее чем " + find_last + ", " + result_max_last);
                    else Console.WriteLine("Таких чисел нет");
                    break;

                case 6:
                    Console.Write("Искомое число: ");
                    int search_element = int.Parse(Console.ReadLine());

                    int indexOF = Array.IndexOf(array, search_element);
                    if (indexOF != -1) Console.WriteLine("Элемент " + search_element + " найден в массиве на позиции " + indexOF);
                    break;
                    
                case 7:
                    Array.Reverse(array);
                    Console.WriteLine("Массив-reverse: " + string.Join(" ", array));
                    break;
                    
                case 8:
                    Console.Write("Введите больший размер массива: ");
                    int re_size = int.Parse(Console.ReadLine());
                    Array.Resize(ref array, re_size);
                    Console.WriteLine("Массив-resize: " + string.Join(" ", array));
                    break;
                    
                case 9:
                    Array.Sort(array);
                    Console.WriteLine("Массив-sort: " + string.Join(" ", array));
                    break;
            }
        }
    }
}
