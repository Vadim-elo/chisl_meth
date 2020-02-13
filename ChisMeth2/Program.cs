using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chm2

{
    class Program
    {
        const int a = 0, b = 2;
        const double ep = 0.000001;
        static void Main(string[] args)
        {
            Prav();
            Centr();
            Trapec();
            Simp();
            Ga();
        }
        public static double Func(double x) 
        {
            return (2 / Math.Sqrt(Math.PI)) * Math.Pow(Math.E, -1 * x * x);
        }

        static double FuntT(double x)
        {
            double a = x, s = 0;
            int n = 0;

            while (Math.Abs(a) > ep)
            {
                s += a;
                a *= ((-1) * (x * x) * (2 * n + 1) / ((n + 1) * (2 * n + 3)));
                n++;
            }
            return (2 / Math.Sqrt(Math.PI) * s);
        }

        static void Prav()
        {
            double h = 0.2,sn,s2n;
            int n = 1024, c = n;

            Console.WriteLine("Квадратурная формула правых треугольников:");
            Console.WriteLine("x\t T(x)\t\t erf(x)\t\t |d|\t\t\t n");

            for (double x = a; x < b; x += h)
            {
                sn = PravFun(x, n);

                s2n = PravFun(x, (n * 2));

                if (Math.Abs(sn - s2n) > ep)
                    Console.WriteLine("{0:f1}\t {1:f8}\t {2:f8}\t {3:f15}\t {4}", x, FuntT(x), PravFun(x, c), Math.Abs(FuntT(x) - PravFun(x, c)), c);

            }

        }

        public static double PravFun(double x, int n)

        {

            int a = 0;

            double h = (x - a) / n;

            double[] masx = new double[n + 1];

            masx[0] = a;

            masx[n] = x;

            for (int i = 1; i < n; i++)

                masx[i] = masx[i - 1] + h;

            double sum = 0;

            for (int i = 1; i <= n; i++)

                sum += Func(masx[i]);

            return sum * h;

        }

        static void Centr()

        {

            double h = 0.2;

            int n = 2;

            double yn;

            double y2n;

            int count = n;

            Console.WriteLine("Квадратурная формула центральных прямоугольников:");

            Console.WriteLine("x\t T(x)\t\t erf(x)\t\t |d|\t\t\t n");

            for (double x = a; x < b; x += h)

            {

                if (x != 0)

                {

                    do

                    {

                        yn = Center(x, n);

                        y2n = Center(x, (n * 2));

                        n = n * 2;

                    }

                    while (Math.Abs(yn - y2n) > ep);

                    count = n / 2;

                    Console.WriteLine("{0:f1}\t {1:f8}\t {2:f8}\t {3:f15}\t {4}", x, FuntT(x), Center(x, count), Math.Abs(FuntT(x) - Center(x, count)), count);

                    n = 2;

                    yn = 0;

                    y2n = 0;

                }

            }

        }

        public static double Center(double x, int n)

        {

            int a = 0;

            double h = (x - a) / n;

            double[] masx = new double[n + 1];

            masx[0] = a;

            masx[n] = x;

            for (int i = 1; i < n; i++)

                masx[i] = masx[i - 1] + h;

            double Sum = 0;

            for (int i = 1; i <= n; i++)

                Sum += Func((masx[i] + masx[i - 1]) / 2);

            return Sum * h;
        }

        static void Trapec()

        {

            double h = 0.2;

            int n = 2;

            double yn;

            double y2n;

            int count = n;

            Console.WriteLine("Квадратурная формула трапеции:");

            Console.WriteLine("x\t T(x)\t\t erf(x)\t\t |d|\t\t\t n");

            for (double x = a; x < b; x += h)

            {

                if (x != 0)

                {

                    do

                    {

                        yn = Trapecia(x, n);

                        y2n = Trapecia(x, (n * 2));

                        n = n * 2;

                    }

                    while (Math.Abs(yn - y2n) > ep);

                    count = n / 2;

                    Console.WriteLine("{0:f1}\t {1:f8}\t {2:f8}\t {3:f15}\t {4}", x, FuntT(x), Trapecia(x, count), Math.Abs(FuntT(x) - Trapecia(x, count)), count);

                    n = 2;

                    yn = 0;

                    y2n = 0;

                }

            }

        }

        public static double Trapecia(double x, int n)

        {

            int a = 0;

            double h = (x - a) / n;

            double[] masx = new double[n + 1];

            masx[0] = a;

            masx[n] = x;

            for (int i = 1; i < n; i++)

                masx[i] = masx[i - 1] + h;

            double Sum = 0;

            for (int i = 1; i <= n; i++)

                Sum += Func(masx[i]) + Func(masx[i - 1]);

            return Sum * (h / 2);

        }

        static void Simp()

        {

            double h = 0.2;

            int n = 2;

            double yn;

            double y2n;

            int count = n;

            Console.WriteLine("Квадратурная формула Cимпсона:");

            Console.WriteLine("x\t T(x)\t\t erf(x)\t\t |d|\t\t\t n");

            for (double x = a; x < b; x += h)

            {

                if (x != 0)

                {

                    do

                    {

                        yn = Simpson(x, n);

                        y2n = Simpson(x, (n * 2));

                        n = n * 2;
                    }

                    while (Math.Abs(yn - y2n) > ep);

                    count = n / 2;

                    Console.WriteLine("{0:f1}\t {1:f8}\t {2:f8}\t {3:f15}\t {4}", x, FuntT(x), Simpson(x, count), Math.Abs(FuntT(x) - Simpson(x, count)), count);

                    n = 2;

                    yn = 0;

                    y2n = 0;
                }
            }
        }

        public static double Simpson(double x, int n)

        {

            int a = 0;

            double h = (x - a) / n;

            double[] masx = new double[n + 1];

            masx[0] = a;

            masx[n] = x;

            for (int i = 1; i < n; i++)

                masx[i] = masx[i - 1] + h;

            double Sum = 0;

            for (int i = 1; i <= n; i++)

                Sum += Func(masx[i]) + (4 * Func((masx[i] + masx[i - 1]) / 2)) + Func(masx[i - 1]);

            return Sum * (h / 6);

        }

        static void Ga()

        {

            double h = 0.2;

            int n = 2;

            double yn;

            double y2n;

            int count = n;

            Console.WriteLine("Квадратурная формула Гаусса:");

            Console.WriteLine("x\t T(x)\t\t erf(x)\t\t |d|\t\t\t n");

            for (double x = a; x < b; x += h)

            {

                if (x != 0)

                {

                    do

                    {

                        yn = Gauss(x, n);

                        y2n = Gauss(x, (n * 2));

                        n = n * 2;

                    }

                    while (Math.Abs(yn - y2n) > ep);

                    count = n / 2;

                    Console.WriteLine("{0:f1}\t {1:f8}\t {2:f8}\t {3:f15}\t {4}", x, FuntT(x), Gauss(x, count), Math.Abs(FuntT(x) - Gauss(x, count)), count);

                    n = 2;

                    yn = 0;

                    y2n = 0;
                }
            }
        }

        public static double Gauss(double x, int n)

        {

            int a = 0;

            double h = (x - a) / n, x1 = 0, x2 = 0, Sum = 0;

            double[] masx = new double[n + 1];

            masx[0] = a;
            masx[n] = x;

            for (int i = 1; i < n; i++)
                masx[i] = masx[i - 1] + h;

            for (int i = 1; i <= n; i++)

            {
                x1 = masx[i - 1] + ((h / 2) * (1 - 1 / Math.Sqrt(3)));
                x2 = masx[i - 1] + ((h / 2) * (1 + 1 / Math.Sqrt(3)));
                Sum += Func(x1) + Func(x2);
            }

            return Sum * (h / 2);

        }

    }

}