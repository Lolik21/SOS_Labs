using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace SOS_Lab1
{
    public static class SignalGenerator
    {
        public static PlotReadyValues GenerateHarmonicSignalWithDifferentFrequency(double N)
        {
            var PI = Math.PI;
            var taskValues = new TaskValuesConstants.Task2AValues();
            var result = new List<List<Point>>();
            foreach (var phi in taskValues.Phis)
            {
                result.Add(new List<Point>());
                var newList = result.Last();
                for (var n = 0; n < N; n++)
                {
                    var value = taskValues.A * Math.Sin(2 * PI * taskValues.f * n / N + phi);
                    newList.Add(new Point(n, value));
                }
            }
            return new PlotReadyValues
            {
                AxisToDraw = result,
                AxisLegends = taskValues.Legends,
                PlotTitle = taskValues.Title
            };
        }
        public static PlotReadyValues GenerateHarmonicSignalWithDifferentFValue(double N)
        {
            var PI = Math.PI;
            var taskValues = new TaskValuesConstants.Task2BValues();
            var result = new List<List<Point>>();
            foreach (var f in taskValues.fs)
            { 
                result.Add(new List<Point>());
                var newList = result.Last();
                for (var n = 0; n < N; n++)
                {
                    var value = taskValues.A * Math.Sin(2 * PI * f * n / N + taskValues.Phi);
                    newList.Add(new Point(n, value));
                }
            }
            return new PlotReadyValues
            {
                AxisToDraw = result,
                AxisLegends = taskValues.Legends,
                PlotTitle = taskValues.Title
            };
        }

        public static PlotReadyValues GenerateHarmonicSignalWithDifferentAValue(double N)
        {
            var PI = Math.PI;
            var taskValues = new TaskValuesConstants.Task2CValues();
            var result = new List<List<Point>>();
            foreach (var A in taskValues.As)
            {
                result.Add(new List<Point>());
                var newList = result.Last();
                for (var n = 0; n < N; n++)
                {
                    var value = A * Math.Sin(2 * PI * taskValues.f * n / N + taskValues.Phi);
                    newList.Add(new Point(n, value));
                }
            }
            return new PlotReadyValues
            {
                AxisToDraw = result,
                AxisLegends = taskValues.Legends,
                PlotTitle = taskValues.Title
            };
        }

        public static PlotReadyValues GeneratePolyHarmonicSignalWithDifferentFrequency(double N)
        {
            var PI = Math.PI;
            var taskValues = new TaskValuesConstants.Task3Values();
            var result = new List<List<Point>>();
            var legends = new List<string>();

            foreach (var phis in taskValues.Phis)
            {
                result.Add(new List<Point>());
                var newList = result.Last();
                for (var n = 0; n < N; n++)
                {
                    var sum = 0.0;
                    for (int j = 0; j < taskValues.JCount; j++)
                    {
                        sum = sum + (taskValues.Aj[j] * Math.Sin(2 * PI * taskValues.fj[j] * n / N + phis[j]));
                    }
                    newList.Add(new Point(n, sum));
                }

                var str = string.Empty;
                foreach (var phi in phis)
                {
                    str = str + Math.Round(phi * 57.3 ,1).ToString(CultureInfo.InvariantCulture) + " | ";
                }
                legends.Add(str);
            }         

            return new PlotReadyValues
            {
                AxisToDraw = result,
                AxisLegends = legends,
                PlotTitle = "PolyHarmonic Lines"
            };
        }

        public static PlotReadyValues GenerateHarmonicSignalWithDifferentLinerValues(double N)
        {
            var PI = Math.PI;
            var taskValues = new TaskValuesConstants.Task4Values();
            var result = new List<List<Point>>();

            result.Add(new List<Point>());
            var newList = result.Last();
            for (var n = 0; n < N * 3; n++)
            {
                var sum = 0.0;           
                for (var j = 0; j < taskValues.JCount; j++)
                {
                    var A = taskValues.Aj[j] + (n / N * taskValues.Aj[j]);
                    var f = taskValues.fj[j] + (n / N * taskValues.fj[j]);
                    var phi = taskValues.Phis[j] + (n / N * taskValues.Phis[j]);
                    sum = sum + A * Math.Sin(2 * PI * f * n / N + phi);
                }
                newList.Add(new Point(n, sum));
            }
                
            return new PlotReadyValues
            {
                AxisToDraw = result,
                AxisLegends = new List<string>{"Task 4 line"},
                PlotTitle = "Task 4"
            };
        }
    }
}