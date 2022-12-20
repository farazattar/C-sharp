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
using System.Windows.Threading;

namespace WpfProgressBarPercentage
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
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value);
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ProgressBarUpdate();
        }
        public void ProgressBarUpdate()
        {
            UpdateProgressBarDelegate updateProgressBar = new UpdateProgressBarDelegate(PleaseWaitProgressBar.SetValue);
            PleaseWaitProgressBar.Minimum = 0;
            PleaseWaitProgressBar.Maximum = 100;
            PleaseWaitProgressBar.Value = 0;
            for (double i = 0; i < PleaseWaitProgressBar.Maximum; i++)
            {
                Dispatcher.Invoke(updateProgressBar,
                    DispatcherPriority.Background,
                    new object[] { ProgressBar.ValueProperty, i });
                System.Threading.Thread.Sleep(100);
            }
            PleaseWaitProgressBar.Value = PleaseWaitProgressBar.Maximum;
        }
    }
}
