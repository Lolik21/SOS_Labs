using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    static class Restorer
    {
        private static double GetMedianaPoint(List<Point> x, int i, int N, int K)
        {
            double SUMM = 0;

            int low = (i - (N - 1) / 2 + K) > 0 ? (i - (N - 1) / 2 + K) : 0;
            int high = (i + (N - 1) / 2 - K) < x.Count ? (i + (N - 1) / 2 - K) : x.Count;

            for (int m = low; m < high; m++)
            {
                SUMM += x[m].Y;
            }
            return 1 / (double)(N - 2 * K) * SUMM;
        }

        private static double GetSlidingAveragePoint(List<Point> x, int i, int K)
        {
            double SUMM = 0;

            int low = (i - ((K - 1) / 2) > 0) ? i - ((K - 1) / 2) : 0;
            int high = (i + ((K - 1) / 2) < x.Count) ? i + ((K - 1) / 2) : x.Count;

            for (int j = low; j < high; j++)
            {
                SUMM += x[j].Y;
            }
            return 1 / (double)K * SUMM;
        }

        //public static List<Point> DoMedianFilter(List<Point> x, int N, int K)
        //{
        //    var restoredSignal = new List<Point>();

        //    for (int i = 0; i < x.Count; i++)
        //    {
        //        restoredSignal.Add(new Point(i, GetMedianaPoint(x, i, N, K)));
        //    }

        //    return restoredSignal;
        //}

        public static List<Point> DoSlidingAverageFilter(List<Point> x, int K)
        {
            List<Point> res = new List<Point>();

            for (int i = 0; i < x.Count; i++)
            {
                res.Add(new Point(i, GetSlidingAveragePoint(x, i, K)));
            }

            return res;
        }

        public static List<Point> DoMedianFilter(List<Point> x, int N, int K)
        {
            List<Point> res = new List<Point>(x);
            List<double> window = new List<double>();
            for (int i = 0; i <= res.Count - 1 - K; i++)
            {
                window.Clear();
                for (int j = i; j <= i + K - 1; j++)
                {
                    window.Add(x[j].Y);
                }
                window.Sort();
                res[i + K / 2] = new Point(i + K / 2, window[K / 2 + 1]);
            }
            return res;
        }

        public static List<Point> DoParabolicSmoothing(List<Point> x)
        {
            var res = new List<Point>();

            for (int i = 7; i < x.Count - 8; i++)
            {
                res.Add(new Point(i, (-3 * x[i - 7].Y - 6 * x[i - 6].Y - 5 * x[i - 5].Y + 3 * x[i - 4].Y + 21 * x[i - 3].Y + 46 * x[i - 2].Y + 67 * x[i - 1].Y + 74 * x[i].Y - 3 * x[i + 7].Y - 6 * x[i + 6].Y - 5 * x[i + 5].Y + 3 * x[i + 4].Y + 21 * x[i + 3].Y + 46 * x[i + 2].Y + 67 * x[i + 1].Y) / 320));
            }
            return res;
        }

    }
}