
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApptest1
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public RelayCommand CloseCommand { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}