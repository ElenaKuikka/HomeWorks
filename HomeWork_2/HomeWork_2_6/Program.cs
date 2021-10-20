using System;

namespace HomeWork_2_6
{
    class Program
    {
        static string hundreds(char elem)
        {
            switch (elem) {
                case '1':
                    return "сто";
                case '2':
                    return "двести";
                case '3':
                    return "триста";
                case '4':
                    return "четыреста";
                case '5':
                    return "пятьсот";
                case '6':
                    return "шестьсот";
                case '7':
                    return "семьсот";
                case '8':
                    return "восемьсот";
                case '9':
                    return "девятьсот";
                default:
                    return "";
            }
        }

        static string tens(char elem)
        {
            switch (elem)
            {
                case '2':
                    return "двадцать";
                case '3':
                    return "тридцать";
                case '4':
                    return "сорок";
                case '5':
                    return "пятьдесят";
                case '6':
                    return "шестьдесят";
                case '7':
                    return "семьдесят";
                case '8':
                    return "восемьдесят";
                case '9':
                    return "девяносто";
                default:
                    return "";
            }
        }

        static string units(char elem)
        {
            switch (elem)
            {
                case '1':
                    return "один";
                case '2':
                    return "два";
                case '3':
                    return "три";
                case '4':
                    return "четыре";
                case '5':
                    return "пять";
                case '6':
                    return "шесть";
                case '7':
                    return "семь";
                case '8':
                    return "восемь";
                case '9':
                    return "девять";
                default:
                    return "";
            }
        }

        static string tensForOne(char elem)
        {
            switch (elem)
            {
                case '0':
                    return "десять";
                case '1':
                    return "одиннадцать";
                case '2':
                    return "двенадцать";
                case '3':
                    return "тринадцать";
                case '4':
                    return "четырнадцать";
                case '5':
                    return "пятнадцать";
                case '6':
                    return "шестнадцать";
                case '7':
                    return "семнадцать";
                case '8':
                    return "восемнадцать";
                case '9':
                    return "девятнадцать";
                default:
                    return "";
            }
        }

        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Введите целое число от 100 до 999.");
                int num = int.Parse(Console.ReadLine());
                if(num < 100 || num > 999)
                {
                    throw new ArgumentException("Число должно находиться в диапазоне от 100 до 999.");
                }

                string numStr = Convert.ToString(num);
                string result = "";
                
                for(int i = 0; i < numStr.Length; i++)
                {
                    if(i == 0)
                    {
                        result += hundreds(numStr[i]) + " ";
                    }
                    if(i == 1)
                    {
                        if (numStr[i] == '1')
                        {
                            result += tensForOne(numStr[i+1]);
                            break;
                        }
                        else
                        {
                            if(tens(numStr[i]) == "")
                            {
                                result += tens(numStr[i]);
                            }
                            else
                            {
                                result += tens(numStr[i]) + " ";
                            }
                        }
                    }
                    if(i == 2)
                    {
                        result += units(numStr[i]);
                    }
                }

                Console.WriteLine(numStr + " - " + result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
