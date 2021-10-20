using System;

namespace HomeWork_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            string convStr = "";
            Console.WriteLine("Введите строку. Для окончания ввода нажмите Enter.");

            str = Console.ReadLine();
            foreach (char elem in str)
            {
                if (char.IsLower(elem))
                {
                    convStr += char.ToUpper(elem);
                }
                else
                {
                    convStr += char.ToLower(elem);
                }
            }

            Console.WriteLine("\nКонвертированная строка: \n" + convStr);
        }
    }
}
