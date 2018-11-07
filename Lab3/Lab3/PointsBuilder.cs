using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    class PointsBuilder
    {
        private int[] A = new int[7] { 1, 5, 7, 8, 9, 10, 17 };
        private double[] fi = new double[6] { Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2, 3 * Math.PI / 4, Math.PI };
        private Random rnd = new Random();
        private List<Point> TSPoints = null;
        private List<Point> PHPoints = null;

        private double TestSignalPoint(int i, int N)
        {
            return 50 * Math.Cos(2 * Math.PI * i / N - Math.PI / 3);
        }
        private double HarmonicPoint(int A, double fi, int i, int j, int N)
        {
            return A * Math.Cos(2 * Math.PI * i * j / N - fi);
        }

        private List<Point> GetHarmonicPoints(int j, int N, int PeriodsNum)
        {
            var tempPoints = new List<Point>();

            var _A = A[rnd.Next(7)];
            var _fi = fi[rnd.Next(6)];

            for (int i = 0; i < N * PeriodsNum; i++)
            {
                tempPoints.Add(new Point(i, HarmonicPoint(_A, _fi, i, j, N)));
            }
            return tempPoints;
        }

        private List<Point> GetPolyharmonicPoints(int N, int PeriodsNum)
        {
            var harmonics = new List<List<Point>>();
            var tempPoints = new List<Point>();

            for (int j = 0; j < 30; j++)
            {
                harmonics.Add(GetHarmonicPoints(j, N, PeriodsNum));
            }

            for (int i = 0; i < N * PeriodsNum; i++)
            {
                double res = 0;
                foreach (var harmonic in harmonics)
                {
                    res += harmonic[i].Y;
                }
                tempPoints.Add(new Point(i, res));
            }

            return tempPoints;
        }
        private List<Point> GetRestoredPHPoints(List<Point> PHPoints, int N = 1024, int PeriodsNum = 5)
        {
            return SignalRestorer.RestorePH(PHPoints, N, PeriodsNum);
        }
        private List<Point> GetRestoredPHNFPoints(List<Point> PHPoints, int N = 1024, int PeriodsNum = 5)
        {
            return SignalRestorer.RestorePH_NF(PHPoints, N, PeriodsNum);
        }

        private List<Point> GetTSPoints(int N, int PeriodsNum)
        {
            var tempPoints = new List<Point>();
            for (int i = 0; i <= N * PeriodsNum; i++)
            {
                tempPoints.Add(new Point(i, TestSignalPoint(i, N)));
            }
            return tempPoints;
        }
        private List<Point> GetRestoredTSPoints(List<Point> TSPoints, int N = 1024, int PeriodsNum = 5)
        {
            return SignalRestorer.RestoreSignal(TSPoints, N, PeriodsNum);
        }

        public Dictionary<String, List<Point>> GetTSSet(int N = 1024, int PeriodsNum = 5)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (TSPoints == null)
            {
                TSPoints = GetTSPoints(N, PeriodsNum);
            }

            tempSets.Add("Test Signal", TSPoints);
            tempSets.Add("Restored Test Signal", GetRestoredTSPoints(TSPoints, N, PeriodsNum));

            return tempSets;
        }
        public Dictionary<String, List<Point>> GetTSAmplSpectre(int N = 1024, int PeriodsNum = 5)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (TSPoints == null)
            {
                TSPoints = GetTSPoints(N, PeriodsNum);
            }

            tempSets.Add("Test Signal Amplitude Spectre", SignalRestorer.GetAmplSpectre(TSPoints, N));

            return tempSets;
        }
        public Dictionary<String, List<Point>> GetTSPhaseSpectre(int N = 1024, int PeriodsNum = 5)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (TSPoints == null)
            {
                TSPoints = GetTSPoints(N, PeriodsNum);
            }

            tempSets.Add("Test Signal Phase Spectre", SignalRestorer.GetPhaseSpectre(TSPoints, N));

            return tempSets;
        }

        public Dictionary<String, List<Point>> GetPHSet(int N = 1024, int PeriodsNum = 5)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (PHPoints == null)
            {
                PHPoints = GetPolyharmonicPoints(N, PeriodsNum);
            }

            tempSets.Add("Polyharmonic Signal", PHPoints);
            tempSets.Add("Polyharmonic (Restored)", GetRestoredPHPoints(PHPoints, N, PeriodsNum));
            tempSets.Add("Polyharmonic (Restored, No Phase)", GetRestoredPHNFPoints(PHPoints, N, PeriodsNum));

            return tempSets;
        }
        public Dictionary<String, List<Point>> GetPHAmplSpectre(int N = 1024, int PeriodsNum = 5)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (PHPoints == null)
            {
                PHPoints = GetPolyharmonicPoints(N, PeriodsNum);
            }

            tempSets.Add("Polyharmonic Amplitude Spectre", SignalRestorer.GetAmplSpectre(PHPoints, N));

            return tempSets;
        }
        public Dictionary<String, List<Point>> GetPHPhaseSpectre(int N = 1024, int PeriodsNum = 5)
        {
            var tempSets = new Dictionary<String, List<Point>>();

            if (PHPoints == null)
            {
                PHPoints = GetPolyharmonicPoints(N, PeriodsNum);
            }

            tempSets.Add("Polyharmonic Amplitude Spectre", SignalRestorer.GetPhaseSpectre(PHPoints, N));

            return tempSets;
        }
    }
}