using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    public class PlotReadyValues
    {
        public List<List<Point>> AxisToDraw { get; set; }
        public List<string> AxisLegends { get; set; }
        public string PlotTitle { get; set; }
    }
}