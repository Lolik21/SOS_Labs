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
            var points = builder.GetNoise(PointsBuilder.TFilterType.None, 256, 1);
            _mainViewModel.UpdateModel(PlotModelGenerator.GeneratePlotModel(points));
            points = builder.GetAmplSpectre(PointsBuilder.TFilterType.None, 256, 1);
            _mainViewModel.UpdateAmplModel(PlotModelGenerator.GenerateBarPlotModel(points));
            points = builder.GetPhaseSpectre(PointsBuilder.TFilterType.None, 256, 1);
            _mainViewModel.UpdatePhaseModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetNoise(PointsBuilder.TFilterType.Mediana, 256, 1);
            _mainViewModel.UpdateModel(PlotModelGenerator.GeneratePlotModel(points));
            points = builder.GetAmplSpectre(PointsBuilder.TFilterType.Mediana, 256, 1);
            _mainViewModel.UpdateAmplModel(PlotModelGenerator.GenerateBarPlotModel(points));
            points = builder.GetPhaseSpectre(PointsBuilder.TFilterType.Mediana, 256, 1);
            _mainViewModel.UpdatePhaseModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetNoise(PointsBuilder.TFilterType.Parabolic, 256, 1);
            _mainViewModel.UpdateModel(PlotModelGenerator.GeneratePlotModel(points));
            points = builder.GetAmplSpectre(PointsBuilder.TFilterType.Parabolic, 256, 1);
            _mainViewModel.UpdateAmplModel(PlotModelGenerator.GenerateBarPlotModel(points));
            points = builder.GetPhaseSpectre(PointsBuilder.TFilterType.Parabolic, 256, 1);
            _mainViewModel.UpdatePhaseModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PointsBuilder builder = new PointsBuilder();
            var points = builder.GetNoise(PointsBuilder.TFilterType.SlidingAverage, 256, 1);
            _mainViewModel.UpdateModel(PlotModelGenerator.GeneratePlotModel(points));
            points = builder.GetAmplSpectre(PointsBuilder.TFilterType.SlidingAverage, 256, 1);
            _mainViewModel.UpdateAmplModel(PlotModelGenerator.GenerateBarPlotModel(points));
            points = builder.GetPhaseSpectre(PointsBuilder.TFilterType.SlidingAverage, 256, 1);
            _mainViewModel.UpdatePhaseModel(PlotModelGenerator.GenerateBarPlotModel(points));
        }
    }
}
