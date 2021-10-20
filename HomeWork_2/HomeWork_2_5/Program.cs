using System;
using System.Web.UI;

namespace HomeWork_2_5
{
    class Program
    {
        static double triangleSide(Pair crdOne, Pair crdTwo)
        {
           return Math.Sqrt(Math.Pow(((double)crdTwo.First - (double)crdOne.First),2) + Math.Pow((double)crdTwo.Second - (double)crdOne.Second,2));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Для вычисления периметра и площади треугольника введите координаты трех вершин треугольника.");

            try
            {
                Console.WriteLine("\nВведите первую координату (x1, y1), разделяя значения клавишей Enter. ");
                Pair coordOne = new Pair(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                Console.WriteLine("\nВведите вторую координату (x2, y2)");
                Pair coordTwo = new Pair(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                Console.WriteLine("\nВведите перкую координату (x3, y3)");
                Pair coordThree = new Pair(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            
                double sideOne = triangleSide(coordOne, coordTwo);
                double sideTwo = triangleSide(coordTwo, coordThree);
                double sideThree = triangleSide(coordThree, coordOne);

                double perimeter = sideOne + sideTwo + sideThree;
                Console.WriteLine(String.Format("\nПериметр треугольника равен {0:F2}.", perimeter));

                double semiPerimeter = perimeter / 2;
                double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideOne) * (semiPerimeter - sideTwo) * (semiPerimeter - sideThree));

                Console.WriteLine(String.Format("Площадь треугольника равна {0:F2}.", area));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
