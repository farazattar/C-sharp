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
using System.Windows.Shapes;
using System.Windows.Threading;
using ReadModListWithGuiAndProgressBar.Utility;

namespace ReadModListWithGuiAndProgressBar.View
{
    /// <summary>
    /// Interaction logic for PleaseWait.xaml
    /// </summary>
    public partial class PleaseWait : Window
    {
        public PleaseWait()
        {
            InitializeComponent();
        }
        public string InputFile = "";
        public string OutputFile = "";
        public string UnitDataBase = "";
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value);
        public void MainFunction()
        {
            try
            {
                StructReader.ReadStruct(InputFile, OutputFile, UnitDataBase, Globals.ModIndexStart);
            }
            catch (Exception err)
            {
                ExceptionHandling.ExecptionOutput(err);
            }
            finally
            {
                MessageBox.Show("The MOD List exctracted from:\n"+ InputFile +
                "\nis successfully inserted into the following database:\n" + UnitDataBase +
                "\nIn addition, the MOD List is writed into this file:\n" + OutputFile);
                Close();
            }
        }
        private void ButtonContinue_Clicked(object sender, RoutedEventArgs e)
        {
            UpdateProgressBarDelegate updateProgressBar = new UpdateProgressBarDelegate(PleaseWaitProgressBar.SetValue);
            PleaseWaitProgressBar.Minimum = 0;
            PleaseWaitProgressBar.Maximum = 800;
            PleaseWaitProgressBar.Value = 0;
            for (double i = 0; i < PleaseWaitProgressBar.Maximum; i++)
            {
                Dispatcher.Invoke(updateProgressBar,
                DispatcherPriority.Background,
                new object[] { ProgressBar.ValueProperty, i });
                System.Threading.Thread.Sleep(10);
            }
            PleaseWaitProgressBar.Value = PleaseWaitProgressBar.Maximum;
            MainFunction();
        }
    }
}
