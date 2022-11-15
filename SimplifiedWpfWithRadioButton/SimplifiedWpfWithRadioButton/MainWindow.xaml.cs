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

namespace SimplifiedWpfWithRadioButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowOptinClicked(object sender, RoutedEventArgs e)
        {
            RadioButton li = (sender as RadioButton);
            MessageBox.Show("You clicked " + li.Content.ToString() + ".");
            if(NUnit1.IsChecked == true)
                MessageBox.Show("You are right!");
        }
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked!");
            if (NUnit1.IsChecked == true)
                MessageBox.Show("Unit 1 is selected!");
            if((NUnit1.IsChecked == false) && (NUnit2.IsChecked == false) && (NUnit3.IsChecked == false) && (NUnit4.IsChecked == false))
                MessageBox.Show("Error Occured: You must specify one unit!!!");
        }
    }
}
