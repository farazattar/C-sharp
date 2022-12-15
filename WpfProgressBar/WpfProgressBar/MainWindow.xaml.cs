using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfProgressBar
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
/*
        private void ScanFolders(string path)
        {
            UpdateProgressBarDelegate updateProgressBar1 = new UpdateProgressBarDelegate(progressBarScan1.SetValue);
            //Get all sub folders by using GetDirectories method 
            String[] folders = Directory.GetDirectories(path);
            progressBarScan1.Minimum = 0;
            progressBarScan1.Value = 0;
            //Set Maximum property is number of files in each folder 
            progressBarScan1.Maximum = folders.Count();
            for (double j = 0; j < folders.Count(); j++)
            {
                textBlock1.Text = folders[(int)j];
                Dispatcher.Invoke(updateProgressBar1,
                DispatcherPriority.Background,
                new object[] { ProgressBar.ValueProperty, j });
                //Suspend 1 milisecond before go next action 
                System.Threading.Thread.Sleep(15);
                ScanFolders(textBlock1.Text);
            }
            progressBarScan1.Value = progressBarScan1.Maximum;
        }
        private delegate void UpdateTextBlockDelegate(DependencyProperty dp, Object title);
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value);
        private void buttonScan_Click(object sender, RoutedEventArgs e)
        {
            string path = @"D:\Faraz\Documents\C#";
            //Call ScanFolders method with specific path 
            ScanFolders(path);
        }
*/

        private delegate void UpdateTextBlockDelegate( DependencyProperty dp, Object title); 
        private delegate void UpdateProgressBarDelegate( DependencyProperty dp, Object value); 
        private void buttonScan_Click (object sender, RoutedEventArgs e) 
        {
            string path = @"D:\Faraz\Documents\C#";
            //Call ScanFiles method with specific path 
            ScanFiles(path);
            //Call ScanFolders method with specific path 
            ScanFolders(path); 
        }
        private void ScanFiles(string path) 
        {
            //CallGetFiles method with specific path and get name of all files 
            FileInfo[] fileInfos = new DirectoryInfo (path).GetFiles(); 
            progressBarScan2.Maximum = fileInfos.Count(); 
            progressBarScan2.Minimum = 0; 
            progressBarScan2.Value = 0; 
            UpdateProgressBarDelegate updateProgressBar2 = new UpdateProgressBarDelegate(progressBarScan2.SetValue); 
            for (double i = 0; i < progressBarScan2.Maximum; i++) 
            { 
                textBlock2.Text = fileInfos [(int)i]. Name;
                //Call Invoke method with specific ProgressBar control 
                    Dispatcher.Invoke(updateProgressBar2, 
                    DispatcherPriority.Background, 
                    new object [] {ProgressBar.ValueProperty, i });
                //Suspend 15 milisecond before loop 
                System.Threading.Thread.Sleep (15); 
            } 
            progressBarScan2.Value = progressBarScan2.Maximum; 
        }
        private void ScanFolders(string path) 
        {
            //Call ScanFiles method with specific path 
            ScanFiles(path);
            //Initializes deligate with argument is specific ProgressBar control 
            UpdateProgressBarDelegate updateProgressBar1 = new UpdateProgressBarDelegate(progressBarScan1.SetValue);
            //Call GetDirectories method with specific path to get all sub folders 
            String [] folders = Directory.GetDirectories(path); progressBarScan1.Minimum = 0; 
            progressBarScan1.Value = 0; 
            progressBarScan1.Maximum = folders.Count ();
            //Loop on all sub folder 
            for (double j = 0; j < folders.Count (); j++) 
            { 
                textBlock1.Text = folders[(int)j]; 
                Dispatcher.Invoke(updateProgressBar1, 
                    DispatcherPriority.Background, 
                    new object [] {ProgressBar.ValueProperty, j});
                //Suspend 15 milisecond before loop 
                System.Threading.Thread.Sleep (15); 
                ScanFolders(textBlock1.Text); 
            } 
            progressBarScan1.Value = progressBarScan1.Maximum; 
        }
    }
}
