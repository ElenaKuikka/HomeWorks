using System;

namespace HomeWork_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Введите температуру в градусах Фаренгейта.");
                float tempF;
                float tempC;

                tempF = float.Parse(Console.ReadLine());
                tempC = (tempF - 32) * 5 / 9;

                Console.WriteLine(String.Format("\n{0:F2} в градусах Фаренгейта равно {1:F2} в градусах Цельсия.", tempF, tempC));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
