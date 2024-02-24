using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            Console.Write("Меню ArrayList" + "\n");
            do
            {
                Console.Write("Введите размерность массива: ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 1) break;
                else Console.WriteLine("Введите целое число, большее или равное 1");
            }
            while (true);

            ArrayList arrayList = new ArrayList();
            Console.WriteLine("\n" + "Введите объекты листа");


            for (int i = 0; i < size; i++)
            {
                Console.Write("Элемент {0}: ", i + 1);
                var value = Console.ReadLine();
                arrayList.Add(value);
            }

            Console.WriteLine("\n" + "Ваш лист: ");
            PrintArrayList(arrayList);

            while (flag)
            {
                Console.WriteLine("Выберите метод:" + "\n" + "1 - Count" + "\n" + "2 - BinSearch" + "\n" + "3 - Copy" +
                "\n" + "4 - IndexOf" + "\n" + "5 - Insert" + "\n" + "6 - Reverse" +
                "\n" + "7 - Sort" + "\n" + "8 - Add" + "\n" + "9 - Exit");

                do
                {
                    Console.Write("\n" + "Ваш метод: ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9) break;
                    else Console.WriteLine("Введите целое число от 1 до 9");
                }

                while (true);

                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Количество элементов: " + arrayList.Count + "\n");

                        break;


                    case 2:
                        Console.Write("Введите искомый элемент: ");
                        var target = Console.ReadLine();
                        var index = arrayList.BinarySearch(target);
                        if (index >= 0) Console.WriteLine("Элемент " + target + " найден в листе на позиции " + index + "\n");
                        else Console.WriteLine("Элемент не найден" + "\n");
                        break;


                    case 3:
                        object[] copy_array = new object[arrayList.Count];
                        arrayList.CopyTo(copy_array);
                        Console.WriteLine("Скопированный массив: " + string.Join(" ", copy_array) + "\n");
                        break;


                    case 4:
                        Console.Write("Искомый элемент: ");
                        var find = Console.ReadLine();
                        var indexOf = arrayList.IndexOf(find);
                        if (indexOf >= 0) Console.WriteLine("Индекс элемента " + find + " в ArrayList: " + indexOf + "\n");
                        else Console.WriteLine("Элемент не найден" + "\n");
                        break;


                    case 5:
                        Console.Write("Новый элемент: ");
                        var new_element = Console.ReadLine();
                        int index_new;
                        do
                        {
                            Console.Write("Его индекс: ");
                            if (int.TryParse(Console.ReadLine(), out index_new) && index_new >= 0) break;
                            else Console.WriteLine("Введите неотрицательное число");
                        }
                        while (true);
                        Console.WriteLine("Ваш обновленный лист: ");
                        arrayList.Insert(index_new, new_element);
                        PrintArrayList(arrayList);
                        break;


                    case 6:
                        arrayList.Reverse();
                        Console.WriteLine("Полученный reverse-лист: ");
                        PrintArrayList(arrayList);
                        break;


                    case 7:
                        arrayList.Sort();
                        Console.WriteLine("Полученный sort-лист: ");
                        PrintArrayList(arrayList);
                        break;


                    case 8:
                        Console.Write("Введите добавляемый элемент: ");
                        var add = Console.ReadLine();
                        arrayList.Add(add);
                        PrintArrayList(arrayList);
                        break;

                    case 9:
                        Console.WriteLine("Конец");
                        flag = false;
                        break;
                }
            }

        }


        static void PrintArrayList(ArrayList arrayList)
        {
            foreach (var item in arrayList) { Console.WriteLine(item); }
            Console.WriteLine();
        }
    }
}
