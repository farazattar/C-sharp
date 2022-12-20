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
using System.ComponentModel;
using ReadModListSimpleConverter.Utility;

namespace ReadModListSimpleConverter.View
{
    /// <summary>
    /// Interaction logic for PleaseWait.xaml
    /// </summary>
    public partial class PleaseWait : Window
    {
        public PleaseWait()
        {
            InitializeComponent();
            m_BackgroundWorker.WorkerReportsProgress = true;
            m_BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            m_BackgroundWorker.ProgressChanged +=
            BackgroundWorker_ProgressChanged;
            m_BackgroundWorker.RunWorkerCompleted +=
            BackgroundWorker_RunWorkerCompleted;
        }
        public string InputFile = "";
        public string OutputFile = "";
        public string UnitDataBase = "";
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value); 
        BackgroundWorker m_BackgroundWorker = new BackgroundWorker();
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
                string MessageBoxMessage = "The MOD List exctracted from:\n" + InputFile +
                    "\nis writed into this file:\n" + OutputFile;
                string MessageBoxTitle = "The program is successfully finished";
                MessageBox.Show(MessageBoxMessage, MessageBoxTitle);
            }
        }
        public void RunTheProgram()
        {
            m_BackgroundWorker.RunWorkerAsync();
        }
        private void BackgroundWorker_DoWork(Object sender, DoWorkEventArgs e)
        {
            MainFunction();
        }
        private void BackgroundWorker_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            PleaseWaitProgressBar.Value = e.ProgressPercentage;
        }
        private void BackgroundWorker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
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
                System.Threading.Thread.Sleep(12);
            }
            PleaseWaitProgressBar.Value = PleaseWaitProgressBar.Maximum;
        }
    }
}
