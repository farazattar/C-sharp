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
using Microsoft.Win32;

namespace ReadModListGuiDesign
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
        string InputFile = "";
        string OutputFile = "";
        string UnitNumber = "";
        private void ShowOptinClicked(object sender, RoutedEventArgs e)
        {
            RadioButton li = (sender as RadioButton);
            MessageBox.Show("You clicked " + li.Content.ToString() + ".");
            UnitNumber = li.Content.ToString();
        }
        private void ButtonOpenInputFile_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show(openFileDialog.FileName);
                InputFile = openFileDialog.FileName;
            }
        }
        private void ButtonOpenOutputFile_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show(openFileDialog.FileName);
                OutputFile = openFileDialog.FileName;
            }
        }
        private void RunButton_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked!");
            MessageBox.Show(InputFile);
            MessageBox.Show(OutputFile);
            MessageBox.Show(UnitNumber);
        }

    }
}
