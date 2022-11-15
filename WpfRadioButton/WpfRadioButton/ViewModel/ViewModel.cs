using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfRadioButton.Command;


namespace WpfRadioButton.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
                public ICommand MyCommand { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChange("Name");
            }
        }
        

        public ViewModel()
        {
            MyCommand = new RelayCommand(executemethod, canexecutemethod);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyname)
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }



        private bool canexecutemethod(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void executemethod(object parameter)
        {
            Name = (string)parameter;
        }
    }
}

