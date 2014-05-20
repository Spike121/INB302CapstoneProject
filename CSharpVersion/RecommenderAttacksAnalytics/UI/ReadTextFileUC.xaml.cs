using System;
using System.Windows;
using System.Windows.Data;
using Microsoft.Win32;
using RecommenderAttacksAnalytics.Converters;
using RecommenderAttacksAnalytics.Input;


namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for ReadTextFileUC.xaml
    /// </summary>
    public partial class ReadTextFileUC : AbstractDataUploadUC
    {

        private readonly TextFileReader m_textFileReader = new TextFileReader(false);
        private readonly TextFileReader m_fakeProfilesTextFileReader = new TextFileReader(true);
        
        public TextFileReader TextFileReader { get { return m_textFileReader; }}
        public TextFileReader FakeProfilesTextFileReader { get { return m_fakeProfilesTextFileReader; }}

        private readonly OpenFileDialog m_fileDialog = new OpenFileDialog();

        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        public string FakeProfilesFilePath
        {
            get { return (string)GetValue(FakeProfilesFilePathProperty); }
            set { SetValue(FakeProfilesFilePathProperty, value); }
        }

        public static readonly DependencyProperty FakeProfilesFilePathProperty =
            DependencyProperty.Register("FakeProfilesFilePath", typeof(string), typeof(ReadTextFileUC));

        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(ReadTextFileUC));

        public ReadTextFileUC()
        {
            InitializeComponent();
            initializeBindings();

            m_textFileReader.ReaderStateChangeEvent += OnReaderStateChange;
            m_textFileReader.ReportProgressEvent += onReaderReportProgress;

            m_fakeProfilesTextFileReader.ReaderStateChangeEvent += OnReaderStateChange;
            m_fakeProfilesTextFileReader.ReportProgressEvent += onReaderReportProgress;
            

            var isProcessingMultiBinding = new MultiBinding()
            {
                Converter = new BooleanOrToBoolConverter(),
                Bindings =
                {
                    new Binding {Source = TextFileReader, Path = new PropertyPath(TextFileReader.IsReaderProcessingProperty.Name)},
                    new Binding {Source = FakeProfilesTextFileReader, Path = new PropertyPath(TextFileReader.IsReaderProcessingProperty.Name)}
                }
            };

            var isDataValidMutliBinding = new MultiBinding()
            {
                Converter = new BooleanAndToBoolConverter()
            };

            isDataValidMutliBinding.Bindings.Add(new Binding {Source = TextFileReader, Path = new PropertyPath(TextFileReader.IsReaderDataValidProperty.Name)});
            if(HasFakeProfiles)
                isDataValidMutliBinding.Bindings.Add(new Binding { Source = FakeProfilesTextFileReader, Path = new PropertyPath(TextFileReader.IsReaderDataValidProperty.Name) });

            SetBinding(IsProcessingProperty, isProcessingMultiBinding);
            SetBinding(IsDataValidProperty, isDataValidMutliBinding);

            m_fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            m_fileDialog.DefaultExt = ".txt";
            //dlg.InitialDirectory = Environment.SpecialFolder.MyDocuments;
            m_fileDialog.InitialDirectory = Environment.CurrentDirectory;
            m_fileDialog.RestoreDirectory = false;

            FilePath = Properties.Settings.Default.lastUsedTextFilePath;
            FakeProfilesFilePath = Properties.Settings.Default.lastUsedFakeProfilesTextFilePath;
        }

        private void openFileSelectDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = m_fileDialog.ShowDialog();
            if (result.Value)
                FilePath = m_fileDialog.FileName;
        }

        private void openFakeProfileFileSelectDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = m_fileDialog.ShowDialog();
            if (result.Value)
                FakeProfilesFilePath = m_fileDialog.FileName;
        }

        private void startLoadFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            //IsDataValid = false;

            if (m_textFileReader.readFromFile(FilePath))
            {
                Properties.Settings.Default.lastUsedTextFilePath = FilePath;
            }

            if (HasFakeProfiles && m_fakeProfilesTextFileReader.readFromFile(FakeProfilesFilePath))
            {
                Properties.Settings.Default.lastUsedFakeProfilesTextFilePath = FakeProfilesFilePath;
            }

            Properties.Settings.Default.Save();
        }

        private void OnReaderStateChange(TextFileReader.TextFileReaderState state)
        {
            outputToTextbox(state.Message);
        }

        private void onReaderReportProgress(int percentage)
        {
            m_completionProgressBar.Value = (m_textFileReader.getCompletionPercentage() + m_fakeProfilesTextFileReader.getCompletionPercentage() )/2;
            //m_completionProgressBar.Value = percentage;
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
