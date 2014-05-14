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

        public bool IsProcessing
        {
            get { return (bool)GetValue(IsProcessingProperty); }
            set { SetValue(IsProcessingProperty, value); }
        }

        public static readonly DependencyProperty IsProcessingProperty =
            DependencyProperty.Register("IsProcessing", typeof(bool), typeof(ReadTextFileUC), new UIPropertyMetadata(false));
        

        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(ReadTextFileUC));

        public ReadTextFileUC()
        {
            InitializeComponent();
            
            m_textFileReader.LogStateEvent += new TextFileReader.LogStateHandler(onReaderLogState);
            m_textFileReader.ReportProgressEvent += new TextFileReader.ReportProgressHandler(onReaderReportProgress);

            FilePath = Properties.Settings.Default.lastUsedTextFilePath;
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

            if (m_textFileReader.readFromFile(FilePath))
            {
                Properties.Settings.Default.lastUsedTextFilePath = FilePath;
                Properties.Settings.Default.Save();
            }
        }

        private void onReaderLogState(TextFileReader.TextFileReaderState state)
        {
            setDataValidityState(state.HasValidData);
            IsProcessing = state.IsProcessing;
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
