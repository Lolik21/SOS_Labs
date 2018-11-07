using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Lab3
{
    public static class PlotModelGenerator
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);

        private static OxyColor GetRandomColor()
        {
            return OxyColor.FromRgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256));
        }

        public static PlotModel GeneratePlotModel(Dictionary<string, List<Point>> plotReadyValues)
        {
            var series = new List<LineSeries>();
            foreach (var key in plotReadyValues.Keys)
            {
                var lineSeries = new LineSeries
                {
                    Title = key,
                    Color = GetRandomColor(),
                };
                lineSeries.Points.AddRange(plotReadyValues[key].Select((point => new DataPoint(point.X, point.Y))));
                series.Add(lineSeries);
            }

            var model = new PlotModel
            {
                Title = "Plot",
            };

            foreach (var s in series)
            {
                model.Series.Add(s);
            }

            return model;
        }

        public static PlotModel GenerateBarPlotModel(Dictionary<string, List<Point>> points)
        {
            var series = new List<ColumnSeries>();
            foreach (var key in points.Keys)
            {
                var barSeries = new ColumnSeries()
                {
                    Title = key,
                    StrokeThickness = 1
                };
            
                foreach (var point in points[key])
                {
                    //if (point.X == 1) continue;
                    barSeries.Items.Add(new ColumnItem(point.Y));
                }

                series.Add(barSeries);
            }

            var model = new PlotModel
            {
                Title = "Plot",
            };

            model.Series.Add(series.FirstOrDefault());

            model.Axes.Add(new CategoryAxis
            {
                Position =  AxisPosition.Bottom,
                GapWidth = 0,
                ItemsSource = points.Values.SelectMany(list => list.Select(point => point.X.ToString(CultureInfo.InvariantCulture)))
            });

            return model;
        }
    }
}