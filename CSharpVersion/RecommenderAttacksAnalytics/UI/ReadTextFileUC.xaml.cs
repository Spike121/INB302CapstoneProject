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
    public partial class ReadTextFileUC : AbstractDataUploadUC
    {

        private TextFileReader m_textFileReader = new TextFileReader();

        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        public int WorkCompletionPercentage
        {
            get { return (int)GetValue(WorkCompletionPercentageProperty); }
            set { SetValue(WorkCompletionPercentageProperty, value); }
        }

        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(ReadTextFileUC));

        public static readonly DependencyProperty WorkCompletionPercentageProperty =
            DependencyProperty.Register("WorkCompletionPercentage", typeof(int), typeof(ReadTextFileUC), new UIPropertyMetadata(0));

        public ReadTextFileUC()
        {
            InitializeComponent();
            
            m_textFileReader.LogStateEvent += new TextFileReader.LogStateHandler(onReaderLogState);
            m_textFileReader.ReportProgressEvent += new TextFileReader.ReportProgressHandler(onReaderReportProgress);
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
                FilePath = dlg.FileName;                                
            }
        }

        private void startLoadFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            setDataValidityState(false);
            m_textFileReader.readFromFile(FilePath);
        }


        private void onReaderLogState(TextFileReader.TextFileReaderState state)
        {
            setDataValidityState(state.HasValidData);
            outputToTextbox(state.Message);
        }

        private void onReaderReportProgress(int percentage)
        {
            m_completionProgressBar.Value = percentage;
        }

        private void outputToTextbox(string str)
        {
            m_outputTextBox.AppendText(str + Environment.NewLine);
            m_outputTextBoxScroller.ScrollToEnd();
        }

        private void clearOutput()
        {
            m_outputTextBox.Text = string.Empty;
        }
    }
}
