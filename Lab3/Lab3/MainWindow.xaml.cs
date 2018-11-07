using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            this.DataContext = _mainViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetTSSet(256, 1);
            PlotReadyValues plotReadyValues = new PlotReadyValues();
            plotReadyValues.AxisToDraw = new List<List<Point>>();
            _mainViewModel.UpdateModel(PlotModelGenerator.GeneratePlotModel(points));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetTSAmplSpectre(256, 1);
            PlotReadyValues plotReadyValues = new PlotReadyValues();
            plotReadyValues.AxisToDraw = new List<List<Point>>();
            _mainViewModel.UpdateModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetTSPhaseSpectre(256, 1);
            PlotReadyValues plotReadyValues = new PlotReadyValues();
            plotReadyValues.AxisToDraw = new List<List<Point>>();
            _mainViewModel.UpdateModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetPHSet(256, 1);
            PlotReadyValues plotReadyValues = new PlotReadyValues();
            plotReadyValues.AxisToDraw = new List<List<Point>>();
            _mainViewModel.UpdateModel(PlotModelGenerator.GeneratePlotModel(points));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetPHAmplSpectre(256, 1);
            PlotReadyValues plotReadyValues = new PlotReadyValues();
            plotReadyValues.AxisToDraw = new List<List<Point>>();
            _mainViewModel.UpdateModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetPHPhaseSpectre(256, 1);
            PlotReadyValues plotReadyValues = new PlotReadyValues();
            plotReadyValues.AxisToDraw = new List<List<Point>>();
            _mainViewModel.UpdateModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }
    }
}
