using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    public static class FurieSpectres
    {
        private static double Acj(List<Point> x, int j, int N)
        {
            double result = 0;
            for (int i = 0; i < N; i++)
            {
                result += x[i].Y * Math.Cos(2 * Math.PI * j * i / N);
            }
            return 2 * result / N;
        }

        private static double Asj(List<Point> x, int j, int N)
        {
            double result = 0;
            for (int i = 0; i < N; i++)
            {
                result += x[i].Y * Math.Sin(2 * Math.PI * j * i / N);
            }
            return 2 * result / N;
        }

        private static double Aj(double Acj, double Asj)
        {
            return Math.Sqrt(Math.Pow(Acj, 2) + Math.Pow(Asj, 2));
        }

        private static double FIj(double Acj, double Asj)
        {
            return Math.Atan(Asj / Acj);
        }

        public static List<Point> GetAmplSpectre(List<Point> x, int N = 1024)
        {
            List<Point> result = new List<Point>();

            for (int j = 0; j < N / 2 - 1; j++)
            {
                var _Acj = Acj(x, j, N);
                var _Asj = Asj(x, j, N);
                var _Aj = Aj(_Acj, _Asj);
                result.Add(new Point(j, _Aj));
            }

            return result;
        }

        public static List<Point> GetPhaseSpectre(List<Point> x, int N = 1024)
        {
            List<Point> result = new List<Point>();

            for (int j = 0; j < N / 2 - 1; j++)
            {
                var _Acj = Acj(x, j, N);
                var _Asj = Asj(x, j, N);
                var _FIj = FIj(_Acj, _Asj);
                result.Add(new Point(j, _FIj));
            }

            return result;
        }
    }
}