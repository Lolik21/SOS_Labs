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

namespace SOS_Lab1
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
            DataContext = _mainViewModel;
        }

        private void UpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UpDownForN.ValueChanged -= UpDown_ValueChanged;
            try
            {
                checked
                {
                    if ((int)e.NewValue > (int)e.OldValue)
                    {
                        UpDownForN.Value = (int)e.OldValue * 2;
                    }

                    if ((int) e.NewValue < (int) e.OldValue)
                    {
                        var newValue = (int)e.OldValue / 2;
                        if (newValue >= 512)
                        {
                            UpDownForN.Value = newValue;
                        }
                        else
                        {
                            UpDownForN.Value = (int) e.OldValue;
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }
            UpDownForN.ValueChanged += UpDown_ValueChanged;
        }

        private void BtnTask2A_Click(object sender, RoutedEventArgs e)
        {
            BuildHarmonicSignal(SignalGenerator.GenerateHarmonicSignalWithDifferentFrequency);
        }

        private void BtnTask2B_Click(object sender, RoutedEventArgs e)
        {
            BuildHarmonicSignal(SignalGenerator.GenerateHarmonicSignalWithDifferentFValue);
        }

        private void BtnTask2C_Click(object sender, RoutedEventArgs e)
        {
            BuildHarmonicSignal(SignalGenerator.GenerateHarmonicSignalWithDifferentAValue);
        }

        private void BtnTask3_Click(object sender, RoutedEventArgs e)
        {
            BuildHarmonicSignal(SignalGenerator.GeneratePolyHarmonicSignalWithDifferentFrequency);
        }

        private void BuildHarmonicSignal(Func<double, PlotReadyValues> func)
        {
            var N = UpDownForN.Value;
            if (N != null)
            {
                var plotValues = func((double)N);
                var plotModel = PlotModelGenerator.GeneratePlotModel(plotValues);
                _mainViewModel.UpdateModel(plotModel);
            }
        }

        private void BtnTask4_Click(object sender, RoutedEventArgs e)
        {
            BuildHarmonicSignal(SignalGenerator.GenerateHarmonicSignalWithDifferentLinerValues);
        }
    }
}
