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
using SinecToRealDateTime.Utility;

namespace SinecToRealDateTime
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
        private void ConvertButton_Clicked(object sender, RoutedEventArgs e)
        {            
            string SinecDateHex = SinecDateBox.Text;
            string SinecTimeHex = SinecTimeBox.Text;
            DateTime DateTimeResult = Sinec2Real.ConvertSinecToDateTime(SinecDateHex, SinecTimeHex);
            string Result = DateTimeResult.ToString("dd-MM-yyyy  HH:mm:ss.fff");            
            ResultBlock.Text = Result;
        }
        private void SinecDateBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "e.g. 3340")
            {
                textBox.Text = string.Empty;                
            }
        }
        private void SinecDateBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "e.g. 3340";
            }
        }
        private void SinecTimeBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "e.g. 030be07a")
            {
                textBox.Text = string.Empty;
            }
        }
        private void SinecTimeBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "e.g. 030be07a";
            }
        }
    }
}
