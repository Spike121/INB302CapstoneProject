using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using RecommenderAttacksAnalytics.Input;
using System.Windows.Documents;
using RecommenderAttacksAnalytics.Utility;


namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for ReadTextFileUC.xaml
    /// </summary>
    public partial class ReadTextFileUC : AbstractAppUC
    {

        private TextFileReader m_textFileReader = new TextFileReader();

        public string m_filePath
        {
            get { return (string)GetValue(m_filePathProperty); }
            set { SetValue(m_filePathProperty, value); }
        }

        public int WorkCompletionPercentage
        {
            get { return (int)GetValue(WorkCompletionPercentageProperty); }
            set { SetValue(WorkCompletionPercentageProperty, value); }
        }

        public static readonly DependencyProperty m_filePathProperty =
            DependencyProperty.Register("m_filePath", typeof(string), typeof(ReadTextFileUC));


        public static readonly DependencyProperty WorkCompletionPercentageProperty =
            DependencyProperty.Register("WorkCompletionPercentage", typeof(int), typeof(ReadTextFileUC), new UIPropertyMetadata(0));

        public ReadTextFileUC()
        {
            InitializeComponent();
            m_textFileReader.LogMessage += new TextFileReader.LogMessageHandler(onReaderLogMessage);
            m_textFileReader.ReportProgress += new TextFileReader.ReportProgressHandler(onReaderReportProgress);
        }
       
        private void openFileSelectDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
            dlg.DefaultExt = ".txt";            
            //dlg.InitialDirectory = Environment.SpecialFolder.MyDocuments;
            dlg.InitialDirectory = Environment.CurrentDirectory;
            dlg.RestoreDirectory = false;

            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                m_filePath = dlg.FileName;                                
            }
        }

        private void startLoadFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            clearOutput();
            m_textFileReader.readFromFile(m_filePath);
        }


        private void onReaderLogMessage (string message) {

            outputToTextbox(message);
        }

        private void onReaderReportProgress(int percentage)
        {

            m_completionProgressBar.Value = percentage;

            /*Action action = () =>
            {
                
            };
            
            Dispatcher.BeginInvoke(action,System.Windows.Threading.DispatcherPriority.Send);
            Logger.log(percentage.ToString());*/
        }

        private void outputToTextbox(string str)
        {
            m_outputTextBox.Text += (str + System.Environment.NewLine);
            m_outputTextBoxScroller.ScrollToEnd();
        }

        private void clearOutput()
        {
            m_outputTextBox.Text = string.Empty;
        }

        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToNextPage();
        }
    }
}
