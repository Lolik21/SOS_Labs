using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;

namespace Sos_Lab2
{
    public static class PlotModelGenerator
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        public static PlotModel GeneratePlotModel(PlotReadyValues plotReadyValues)
        {
            var series = new List<LineSeries>();
            var counter = 0;
            foreach (var points in plotReadyValues.AxisToDraw)
            {
                var lineSeries = new LineSeries
                {
                    Title = plotReadyValues.AxisLegends[counter],
                    Color = GetRandomColor(),
                };
                lineSeries.Points.AddRange(points.Select((point => new DataPoint(point.X, point.Y))));
                series.Add(lineSeries);
                counter++;
            }

            var model = new PlotModel
            {
                Title = plotReadyValues.PlotTitle,
            };

            foreach (var s in series)
            {
                model.Series.Add(s);
            }

            return model;
        }

        private static OxyColor GetRandomColor()
        {
            return OxyColor.FromRgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256));
        }

    }
}