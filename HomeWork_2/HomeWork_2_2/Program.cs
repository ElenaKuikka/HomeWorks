using System;

namespace HomeWork_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strTicket;
            bool digit = false;
            Console.WriteLine("Введите номер трамвайного билета. Номер является шестизначным целым числом.");

            try
            {
                strTicket = Console.ReadLine();

                if (strTicket.Length != 6)
                {
                    throw new ArgumentException("Номер трамвайного билета должен быть шестизначным числом.");
                }

                foreach (char elem in strTicket)
                {
                    digit = char.IsDigit(elem);
                    if (!digit)
                    {
                        throw new ArgumentException("В номере билета допустимы только цифры.");
                    }
                }

                int sumOne = 0;
                int sumTwo = 0;
                for (int i = 0; i < strTicket.Length; i++)
                {
                    if (i <= 2)
                    {
                        sumOne += Convert.ToInt32(strTicket[i]);
                    }
                    else
                    {
                        sumTwo += Convert.ToInt32(strTicket[i]);
                    }
                }

                if (sumOne == sumTwo)
                {
                    Console.WriteLine("\nБилет " + strTicket + " является счастливым!");
                }
                else
                {
                    Console.WriteLine("\nБилет " + strTicket + " не является счастливым!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
