using System.ComponentModel;
using System.Runtime.CompilerServices;
using OxyPlot;

namespace Lab3
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public PlotModel PlotModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateModel(PlotModel model)
        {
            PlotModel = model;
            OnPropertyChanged(nameof(PlotModel));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}