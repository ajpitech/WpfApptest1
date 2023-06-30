using System;
using System.Windows.Input;

namespace WpfApptest1
{
    public class RelayCommand : ICommand
    {
       
        public event EventHandler CanExecuteChanged;

        Action<object> vm;
        Action vm1;

        public RelayCommand(Action<object> _vm)
        {
            vm = _vm;
        }

        public RelayCommand(Action _vm)
        {
            vm1 = _vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // vm?.Invoke(parameter):??vm1.Invoke(parameter);
            if (vm != null)
            {
                vm(parameter);
            }
            else
            {
                vm1();
            }
        }
    }
}
