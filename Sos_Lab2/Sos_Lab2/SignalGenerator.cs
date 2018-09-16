using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace Sos_Lab2
{
    public class SignalGenerator
    {
        public static PlotReadyValues GenerateSignal(int N, Func<double, double, double, double> func, double fi)
        {
            var K = N / 4;
            var task2APoints = GetTask2APoints(N, func, K, fi);
            var task2BPoints = GetTask2BPoints(N, func, K, fi);
            var amplPoints = GetTask2AmplPoints(N, func, K, fi);
            return new PlotReadyValues
            {
                AxisLegends = new List<string> { "Task2A", "Task2B" , "Amplitude"},
                AxisToDraw = new List<List<Point>>
                {
                    task2APoints,
                    task2BPoints,
                    amplPoints
                },
                PlotTitle = "Title"               
            };
        }

        private static List<Point> GetTask2AmplPoints(int N, Func<double, double, double, double> func, int K, double fi)
        {
            var result = new List<Point>();            
            for (int M = K; M <= 2 * N; M++)
            {
                var tempResult = new List<Point>();
                for (int n = 0; n < M; n++)
                {
                    tempResult.Add(new Point(n, func(n,N, fi)));
                }

                result.Add(new Point(M, 1 - GetAmplitude(tempResult, M)));
            }

            return result;
        }

        private static double GetAmplitude(List<Point> tempResult, int M)
        {
            var result = Math.Sqrt(Math.Pow(GetSinus(tempResult, M), 2) + Math.Pow(GetCosinus(tempResult, M), 2));
            return result;
        }

        private static double GetCosinus(List<Point> tempResult, int M)
        {
            double cosSum = 0;
            foreach (var point in tempResult)
            {
                cosSum += point.Y * Math.Cos(2 * Math.PI * point.X / M);
            }
            return 2 * cosSum / M;
            
        }

        private static double GetSinus(List<Point> tempResult, int M)
        {
            double sinSum = 0;
            foreach (var point in tempResult)
            {
                sinSum += point.Y * Math.Sin(2 * Math.PI * point.X / M);
            }

            return 2 * sinSum / M;
        }

        private static List<Point> GetTask2BPoints(int N, Func<double, double, double, double> func, int K, double fi)
        {
            var result = new List<Point>();
            for (int M = K; M <= 2 * N; M++)
            {
                double meanSquare1 = 0;
                double meanSquare2 = 0;
                for (int n = 0; n < M; n++)
                {
                    meanSquare1 = meanSquare1 + Math.Pow(func(n, N, fi), 2);
                    meanSquare2 = meanSquare2 + func(n, N, fi);
                }
                meanSquare1 = meanSquare1 * ((double)1 / (M + 1));
                meanSquare2 = Math.Pow((double)1 / (M + 1) * meanSquare2 , 2);
                var meanSquare = Math.Sqrt(meanSquare1 - meanSquare2);
                var error = 0.707 - meanSquare;
                result.Add(new Point(M, error));
            }

            return result;
        }

        private static List<Point> GetTask2APoints(int N, Func<double, double, double , double> func, int K , double fi)
        {
            var result = new List<Point>();
            for (int M = K; M <= 2 * N; M++)
            {
                double meanSquare = 0;
                for (int n = 0; n < M; n++)
                {
                    meanSquare = meanSquare + Math.Pow(func(n, N , fi), 2);
                }

                meanSquare = Math.Sqrt(meanSquare * ((double)1 / (M + 1)));
                var error = 0.707 - meanSquare;
                result.Add(new Point(M, error));
            }

            return result;
        }
    }
}