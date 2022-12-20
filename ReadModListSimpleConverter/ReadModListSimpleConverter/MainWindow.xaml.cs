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
using ReadModListSimpleConverter.Utility;
using ReadModListSimpleConverter.ConsoleView;
using ReadModListSimpleConverter.View;

namespace ReadModListSimpleConverter
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
        string UnitDataBase = "";
        private void ShowOptinClicked(object sender, RoutedEventArgs e)
        {
            RadioButton li = (sender as RadioButton);
            UnitNumber = li.Content.ToString();
        }
        private void ButtonOpenInputFile_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:";
            if (openFileDialog.ShowDialog() == true)
                InputFile = openFileDialog.FileName;
            TextBlockSelectedInputFileShow.Text = InputFile;
        }
        private void ButtonSaveOutputFile_Clicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.InitialDirectory = @"D:";
            if (saveFileDialog.ShowDialog() == true)
                OutputFile = saveFileDialog.FileName;
            TextBlockSelectedOutputFileShow.Text = OutputFile;
        }
        private void RunButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (UnitNumber == "Unit1")
                UnitDataBase = Globals.Unit1DataBase;
            if (UnitNumber == "Unit2")
                UnitDataBase = Globals.Unit2DataBase;
            if (UnitNumber == "Unit3")
                UnitDataBase = Globals.Unit3DataBase;
            if (UnitNumber == "Unit4")
                UnitDataBase = Globals.Unit4DataBase;
            FileFunctions.CheckInputFile(InputFile);
            FileFunctions.CreateOutputfile(OutputFile);
/*
            try
            {
                DataBaseFunctions DbFunctions = new DataBaseFunctions();
                DbFunctions.ConnectToDb(Globals.ConnectionString);
                DbFunctions.TruncateDb(UnitDataBase);
                DbFunctions.DisconnectFromDb();
            }
            catch (Exception err)
            {
                ExceptionHandling.ExecptionOutput(err);
            }
*/
            PleaseWait pleaseWait = new PleaseWait();
            pleaseWait.InputFile = InputFile;
            pleaseWait.OutputFile = OutputFile;
            pleaseWait.UnitDataBase = UnitDataBase;
            pleaseWait.Show();
            pleaseWait.RunTheProgram();
            pleaseWait.ProgressBarUpdate();
            Close();
        }
    }
}
