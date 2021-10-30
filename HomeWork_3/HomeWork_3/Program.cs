using System;

namespace HomeWork_3
{
    class Program
    {
        static void Print(int[] arr, string str)
        {
            Console.WriteLine("Массив " + str + ".");
            foreach (int elem in arr)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите целое положительное число, не равное нулю, размер первого массива.");
                int sizeOne = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите целое положительное число, не равное нулю, размер второго массива.");
                int sizeTwo = int.Parse(Console.ReadLine());

                if (sizeOne <= 0 || sizeTwo <= 0)
                {
                    throw new ArgumentException("Размер массива должен быть целым положительным числом, не равным нулю");
                }

                int sizeThree;
                if (sizeOne >= sizeTwo)
                {
                    sizeThree = sizeTwo;
                }
                else
                {
                    sizeThree = sizeOne;
                }

                int[] arrOne = new int[sizeOne];
                int[] arrTwo = new int[sizeTwo];
                int[] resArr = new int[sizeThree];

                Random rand = new Random();

                for (int i = 0; i < sizeOne; i++)
                {
                    arrOne[i] = rand.Next(10);
                }
                for (int i = 0; i < sizeTwo; i++)
                {
                    arrTwo[i] = rand.Next(10);
                }

                int count = 0;
                for (int j = 0; j < sizeOne; j++)
                {
                    for (int k = 0; k < sizeTwo; k++)
                    {
                        if (arrOne[j] == arrTwo[k])
                        {
                            resArr[count] = arrOne[j];
                            for (int r = 0; r < count; r++)
                            {
                                if (resArr[count] == resArr[r])
                                {
                                    resArr[count] = 0;
                                    count--;
                                    break;
                                }
                            }
                            count++;
                            break;
                        }
                    }
                }

                Array.Resize(ref resArr, count);

                Print(arrOne, "один");
                Print(arrTwo, "два");
                Print(resArr, "с общими элементами из двух массивов");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
