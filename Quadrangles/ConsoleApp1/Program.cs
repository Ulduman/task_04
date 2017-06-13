using Quadrangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Quadrangle q = new Quadrangle();
            double[] x;
            string[] str;
            Console.Write("Введите координаты четырехугольника через пробел:\n");
            str = Console.ReadLine().Split(' ');
            x = new double[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                x[i] = Convert.ToDouble(str[i]);
            }
            Console.WriteLine("Периметр: {0:f} Площадь: {1:f}",q.CalcPerimetrQuad(x), q.CalcAreaQuad(x));
            Console.ReadKey();
        }
    }
}
