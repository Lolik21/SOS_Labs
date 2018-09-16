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

namespace Sos_Lab2
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

                    if ((int)e.NewValue < (int)e.OldValue)
                    {
                        var newValue = (int)e.OldValue / 2;
                        if (newValue >= 64)
                        {
                            UpDownForN.Value = newValue;
                        }
                        else
                        {
                            UpDownForN.Value = (int)e.OldValue;
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

        private void ButtonTask2_Click(object sender, RoutedEventArgs e)
        {
            var nValue = UpDownForN.Value;
            if (nValue != null)
            {
                var fi = 0;
                var signal = SignalGenerator.GenerateSignal(nValue.Value, FuncTask2A, fi);
                var model = PlotModelGenerator.GeneratePlotModel(signal);
                _mainViewModel.UpdateModel(model);
            }
        }

        private double FuncTask2A(double n, double N, double fi)
        {
            return Math.Sin(2 * Math.PI * n / N + fi);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nValue = UpDownForN.Value;
            if (nValue != null)
            {
                var fi = Math.PI / 2;
                var signal = SignalGenerator.GenerateSignal(nValue.Value, FuncTask2A, fi);
                var model = PlotModelGenerator.GeneratePlotModel(signal);
                _mainViewModel.UpdateModel(model);
            }
        }
    }
}
