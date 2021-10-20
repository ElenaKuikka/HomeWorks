using System;

namespace HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку. Для окончания ввода нажмите '.' или Enter. \nБудет посчитано количество пробелов в введенной строке.\n");
            string resStr = "";
            int numSpaces = 0;
            ConsoleKeyInfo i;
            while (true)
            {
                i = Console.ReadKey();
                resStr = resStr + i.KeyChar;
                if (i.Key == ConsoleKey.Spacebar)
                {
                    numSpaces++;
                }
                if (i.Key == ConsoleKey.Enter || i.KeyChar == '.')
                {
                    break;
                }
            }
            Console.WriteLine("\n\nВведенная строка: " + resStr);
            Console.WriteLine("Количество пробелов: " + numSpaces);
        }
    }
}
