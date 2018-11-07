using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    public static class SignalRestorer
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

        //private static double GetAmplSpectrum(List<Point> harmonic)
        //{
        //    return Math.Sqrt(Math.Pow(sineSp[j], 2) + Math.Pow(cosineSp[j], 2));
        //}

        //private static double GetPhaseSpectrum(List<Point> harmonic)
        //{
        //    return Math.Atan(sineSp[j] / cosineSp[j]);
        //}

        public static List<Point> RestoreSignal(List<Point> x, int N = 1024, int PeriodsNum = 5)
        {
            var resPoints = new List<Point>();

            //var _Acj = Acj(x, 1, N);
            //var _Asj = Asj(x, 1, N);
            //var _Aj = Aj(_Acj, _Asj);
            //var _FIj = FIj(_Acj, _Asj);

            for (int i = 0; i < N * PeriodsNum; i++)
            {
                double y = 0;
                for (int j = 0; j < N / 2 - 1; j++)
                {
                    var _Acj = Acj(x, j, N);
                    var _Asj = Asj(x, j, N);
                    var _Aj = Aj(_Acj, _Asj);
                    var _FIj = FIj(_Acj, _Asj);

                    y += _Aj * Math.Cos(2 * Math.PI * i / N - _FIj);
                }

                resPoints.Add(new Point(i, y));
            }

            return resPoints;
        }

        public static List<Point> RestorePH(List<Point> x, int N = 1024, int PeriodsNum = 5)
        {
            var resPoints = new List<Point>();

            var A0 = Aj(Acj(x, 0, N), Asj(x, 0, N));

            for (int i = 0; i < N * PeriodsNum; i++)
            {
                double y = 0;
                for (int j = 1; j < N / 2 - 1; j++)
                {
                    var _Acj = Acj(x, j, N);
                    var _Asj = Asj(x, j, N);
                    var _Aj = Aj(_Acj, _Asj);
                    var _FIj = FIj(_Acj, _Asj);

                    y += _Aj * Math.Cos(2 * Math.PI * i * j / N - _FIj);
                }

                resPoints.Add(new Point(i, (A0 / 2) + y));
            }

            return resPoints;
        }

        public static List<Point> RestorePH_NF(List<Point> x, int N = 1024, int PeriodsNum = 5)
        {
            var resPoints = new List<Point>();

            var A0 = Aj(Acj(x, 0, N), Asj(x, 0, N));

            for (int i = 0; i < N * PeriodsNum; i++)
            {
                double y = 0;
                for (int j = 1; j < N / 2 - 1; j++)
                {
                    var _Aj = Aj(Acj(x, j, N), Asj(x, j, N));

                    y += _Aj * Math.Cos(2 * Math.PI * i * j / N);
                }

                resPoints.Add(new Point(i, (A0 / 2) + y));
            }

            return resPoints;
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