using System.ComponentModel;
using System.Runtime.CompilerServices;
using OxyPlot;
using SOS_Lab1.Annotations;

namespace SOS_Lab1
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}