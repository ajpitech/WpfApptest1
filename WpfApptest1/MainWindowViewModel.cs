using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApptest1
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string NameStr { 
            get { return nameStr; } 
            set {
                   nameStr = value;
                if (nameStr.Contains(','))
                {
                    NameStr = NameStr.Remove(NameStr.Length - 1, 1);
                    string tempName = NameStr;
                    bool check = true;
                    for (int i = 0; i < ListName.Count; i++)
                    {
                        if ((ListName[i].Name1.ToUpper()) == tempName.ToUpper())
                            check = false;
                    }

                        if (check)
                        {
                            ListName.Add(new Naming(this) { Name1 = NameStr });
                        }
                    //OnPropertyChanged(nameof(ListName));
                    NameStr = "";
                }
            } }
        private string nameStr { get; set; }
        public ObservableCollection<Naming> ListName { get; set; } = new ObservableCollection<Naming>();
        public ObservableCollection<Naming> ListName1 { get; set; } = new ObservableCollection<Naming>();
        //public RelayCommand AddCommand { get; set; }
       
        
        public MainWindowViewModel()
        {
        }
        public Naming selectedName;
        public Naming SelectedName
        {
            get
            {
                return selectedName;
            }
            set
            {
                if (value != null)
                {
                    selectedName = value;

                    ListName1 = ListName;
                    
                    for (int i = 0; i < ListName1.Count; i++)
                    {
                        string tempName = ListName1[0].Name1;
                        ListName.RemoveAt(0);

                        if (SelectedName.Name1 == tempName)
                        {
                            ListName.Add(new Naming(this) { Name1 = tempName, BorderColor = "Green" });
                        }
                        else
                        {
                            ListName.Add(new Naming(this) { Name1 = tempName, BorderColor = "Red" });

                        }

                    }
                    OnPropertyChanged(nameof(ListName));
                }
            }
        }

    }
    public class Naming : BaseViewModel
    {
        private MainWindowViewModel mainWindowViewModel;

        public string Name1 { get; set; }

        public string BorderColor { get; set; } 
       



        public Naming(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            CloseCommand = new RelayCommand(CloseCommandMethod);

        }

        public void CloseCommandMethod(object parameter)
        {
            if (mainWindowViewModel != null)
            {

                mainWindowViewModel.ListName.Remove((Naming)parameter);

            }
        }
    }
}
