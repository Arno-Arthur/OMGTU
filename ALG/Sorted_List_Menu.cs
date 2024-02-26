using System;
using System.Collections;
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
            bool flag = true;
            int size;
            int choice;

            Console.Write("Меню SortedList" + "\n");
            do
            {
                Console.Write("Введите размерность листа: ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= 1) break;
                else Console.WriteLine("Введите целое число, большее или равное 1");
            }
            while (true);

            SortedList mySL = new SortedList();
            Console.WriteLine("\n" + "Введите ключи-значения листа: ");

            for (int i = 0; i < size; i++)
            {
                do
                {
                    Console.Write("Введите ключ: ");
                    string user_key = Console.ReadLine();
                    Console.Write("Введите значение: ");
                    string user_value = Console.ReadLine();

                    if (!mySL.ContainsKey(user_key))
                    {
                        mySL.Add(user_key, user_value);
                        break;
                    }
                    else Console.WriteLine("Этот ключ уже существует, введите новый" + "\n");
                }
                while (true);
            }

            Console.WriteLine("\n" + "Ваш SortedList: ");
            DisplaySortedList(mySL);

            while (flag)
            {
                Console.WriteLine("\n" + "Выберите метод:" + "\n" + "1 - Add" + "\n" + "2 - IndexOfKey" + "\n" + "3 - IndexOfValue" +
                "\n" + "4 - ContainsKey" + "\n" + "5 - ContainsValue" + "\n" + "6 - Exit");

                do
                {
                    Console.Write("\n" + "Ваш метод: ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 6) break;
                    else Console.WriteLine("Введите целое число от 1 до 6");
                }
                while (true);


                switch (choice)
                {

                    case 1:

                        do
                        {
                            Console.Write("Введите ключ: ");
                            string user_key = Console.ReadLine();
                            Console.Write("Введите значение: ");
                            string user_value = Console.ReadLine();

                            if (!mySL.ContainsKey(user_key))
                            {
                                mySL.Add(user_key, user_value);
                                break;
                            }
                            else Console.WriteLine("Этот ключ уже существует, введите новый" + "\n");
                        }
                        while (true);

                        Console.WriteLine("\n" + "Ваш SortedList: ");
                        DisplaySortedList(mySL);
                        break;


                    case 2:

                        Console.Write("Введите ключ: ");
                        string key = Console.ReadLine();

                        int id = mySL.IndexOfKey(key);

                        if (id >= 0) Console.WriteLine("Ключ \"{0}\" лежит по индексу {1}.", key, id);
                        else Console.WriteLine("Такого элемента нет");
                        break;


                    case 3:

                        Console.Write("Введите значение: ");
                        string value = Console.ReadLine();

                        int id_value = mySL.IndexOfValue(value);

                        if (id_value >= 0) Console.WriteLine("Значение \"{0}\" лежит по индексу {1}.", value, id_value);
                        else Console.WriteLine("Такого элемента нет");
                        break;


                    case 4:
                        
                        Console.Write("Введите ключ: ");
                        string search_key = Console.ReadLine();

                        if (mySL.ContainsKey(search_key)) Console.WriteLine($"Значение по ключу: {mySL[search_key]}");
                        else Console.WriteLine("Такого ключа нет");
                        break;


                    case 5:
                        
                        Console.Write("Введите значение: ");
                        string search_value = Console.ReadLine();

                        if (mySL.ContainsValue(search_value))
                        {
                            foreach (DictionaryEntry entry in mySL)
                            {
                                if (entry.Value.Equals(search_value))
                                {
                                    Console.WriteLine("Ключ по значению: " + entry.Key); break;
                                }
                            }
                        }
                        else Console.WriteLine("Такого значения нет");
                        break;


                    case 6:

                        Console.WriteLine("Конец");
                        flag = false;
                        break;
                }
            }
        }


        static void DisplaySortedList(SortedList sortedList)
        {
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine($"Ключ: {entry.Key}, Значение: {entry.Value}");
            }
        }
    }
}
