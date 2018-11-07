using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    class PointsBuilder
    {
        public enum TFilterType { None, SlidingAverage, Mediana, Parabolic }

        private const double B_1 = 1;
        private const double B_2_COEF = 30;
        private const int Med_K = 9;
        private const int Sli_K = 5;

        private List<Point> noise = null;

        public void Refresh()
        {
            noise = null;
        }

        private double GetNoisePoint(double B_1, double B_2, int i, int N = 1024)
        {
            double SUMM = 0;
            Random random = new Random();

            for (int j = 50; j < 71; j++)
            {
                SUMM += Math.Pow(-1, random.Next(100000) % 2) * B_2 * Math.Sin(2 * Math.PI * i * j / N);
            }

            return B_1 * Math.Sin(2 * Math.PI * i / N) + SUMM;
        }

        private List<Point> GetNoisePoints(double B_1, double B_2, int N = 1024, int PeriodsCount = 2)
        {
            var resPoints = new List<Point>();

            for (int i = 0; i < N * PeriodsCount; i++)
            {
                resPoints.Add(new Point(i, GetNoisePoint(B_1, B_2, i, N)));
            }

            return resPoints;
        }

        public Dictionary<String, List<Point>> GetNoise(TFilterType FilterType, int N = 1024, int PeriodsCount = 2)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (noise == null)
            {
                noise = GetNoisePoints(B_1, B_1 / B_2_COEF, N, PeriodsCount);
            }

            tempSets.Add("Noise", noise);

            switch (FilterType)
            {
                case TFilterType.None:
                    break;
                case TFilterType.SlidingAverage:
                    tempSets.Add("Sliding Average Filter", Restorer.DoSlidingAverageFilter(noise, Sli_K));
                    break;
                case TFilterType.Mediana:
                    tempSets.Add("Mediana Filter", Restorer.DoMedianFilter(noise, N, Med_K));
                    break;
                case TFilterType.Parabolic:
                    tempSets.Add("Parabolic Smoothing", Restorer.DoParabolicSmoothing(noise));
                    break;
                default:
                    break;
            }

            return tempSets;
        }

        public Dictionary<String, List<Point>> GetAmplSpectre(TFilterType FilterType, int N = 1024, int PeriodsCount = 2)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (noise == null)
            {
                noise = GetNoisePoints(B_1, B_1 / B_2_COEF, N, PeriodsCount);
            }

            tempSets.Add("Noise Amplitude Spectre", FurieSpectres.GetAmplSpectre(noise, N));

            switch (FilterType)
            {
                case TFilterType.None:
                    break;
                case TFilterType.SlidingAverage:
                    var SAfiltered = Restorer.DoSlidingAverageFilter(noise, Sli_K);
                    tempSets.Add("Sliding Average Filter Amplitude Spectre", FurieSpectres.GetAmplSpectre(SAfiltered, SAfiltered.Count));
                    break;
                case TFilterType.Mediana:
                    var Mfiltered = Restorer.DoMedianFilter(noise, N, Med_K);
                    tempSets.Add("Mediana Filter Amplitude Spectre", FurieSpectres.GetAmplSpectre(Mfiltered, Mfiltered.Count));
                    break;
                case TFilterType.Parabolic:
                    var Pfiltered = Restorer.DoParabolicSmoothing(noise);
                    tempSets.Add("Parabolic Smoothing Amplitude Spectre", FurieSpectres.GetAmplSpectre(Pfiltered, Pfiltered.Count));
                    break;
                default:
                    break;
            }

            return tempSets;
        }

        public Dictionary<String, List<Point>> GetPhaseSpectre(TFilterType FilterType, int N = 1024, int PeriodsCount = 2)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (noise == null)
            {
                noise = GetNoisePoints(B_1, B_1 / B_2_COEF, N, PeriodsCount);
            }

            tempSets.Add("Noise Phase Spectre", FurieSpectres.GetPhaseSpectre(noise, N));

            switch (FilterType)
            {
                case TFilterType.None:
                    break;
                case TFilterType.SlidingAverage:
                    var SAfiltered = Restorer.DoSlidingAverageFilter(noise, Sli_K);
                    tempSets.Add("Sliding Average Filter Phase Spectre", FurieSpectres.GetPhaseSpectre(SAfiltered, SAfiltered.Count));
                    break;
                case TFilterType.Mediana:
                    var Mfiltered = Restorer.DoMedianFilter(noise, N, Med_K);
                    tempSets.Add("Mediana Filter Phase Spectre", FurieSpectres.GetPhaseSpectre(Mfiltered, Mfiltered.Count));
                    break;
                case TFilterType.Parabolic:
                    var Pfiltered = Restorer.DoParabolicSmoothing(noise);
                    tempSets.Add("Parabolic Smoothing Phase Spectre", FurieSpectres.GetPhaseSpectre(Pfiltered, Pfiltered.Count));
                    break;
                default:
                    break;
            }

            return tempSets;
        }
    }
}