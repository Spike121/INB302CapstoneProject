using System;
using System.Windows;
using System.Windows.Data;
using Microsoft.Win32;
using RecommenderAttacksAnalytics.Converters;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.InputOutput;


namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for ReadTextFileUC.xaml
    /// </summary>
    public partial class ReadTextFileUC : AbstractDataUploadUC
    {

        public TextFileDataIO TextFileReader { get { return m_normalDataIoModule as TextFileDataIO; }}
        public TextFileDataIO FakeProfilesTextFileReader { get { return m_fakeProfilesDataIoModule as TextFileDataIO; }}

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
            : base(new TextFileDataIO(false),new TextFileDataIO(true)) 
        {
            InitializeComponent();
            initializeBindings();

            TextFileReader.ReaderStateChangeEvent += OnReaderStateChange;
            TextFileReader.ReportProgressEvent += onReaderReportProgress;

            FakeProfilesTextFileReader.ReaderStateChangeEvent += OnReaderStateChange;
            FakeProfilesTextFileReader.ReportProgressEvent += onReaderReportProgress;

            m_fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            m_fileDialog.DefaultExt = ".txt";
            //dlg.InitialDirectory = Environment.SpecialFolder.MyDocuments;
            m_fileDialog.InitialDirectory = Environment.CurrentDirectory;
            m_fileDialog.RestoreDirectory = false;

            FilePath = Properties.Settings.Default.lastUsedTextFilePath;
            FakeProfilesFilePath = Properties.Settings.Default.lastUsedFakeProfilesTextFilePath;
        }

        //protected override void initializeIsProcessingBindings()
        //{
        //    var isProcessingMultiBinding = new MultiBinding()
        //    {
        //        Converter = new BooleanOrToBoolConverter(),
        //        Bindings =
        //        {
        //            new Binding {Source = TextFileReader, Path = new PropertyPath(TextFileDataIO.IsProcessingProperty.Name)},
        //            new Binding {Source = FakeProfilesTextFileReader, Path = new PropertyPath(TextFileDataIO.IsProcessingProperty.Name)}
        //        }
        //    };

        //    SetBinding(IsProcessingProperty, isProcessingMultiBinding);
        //}

        protected override void initializeIsDataValidBindings()
        {
            var doBothReadersHaveValidInputInput = new MultiBinding()
            {
                Converter = new BooleanAndToBoolConverter(),
                Bindings = { new Binding { Source = TextFileReader, Path = new PropertyPath(AbstractDataIO.IsDataValidProperty.Name) } }
            };

            if (HasFakeProfiles)
                doBothReadersHaveValidInputInput.Bindings.Add(new Binding { Source = FakeProfilesTextFileReader, Path = new PropertyPath(AbstractDataIO.IsDataValidProperty.Name) });


            //var isDataValidMutliBinding = new MultiBinding()
            //{
            //    Converter = new BooleanOrToBoolConverter(),
            //    Bindings =
            //    {   doBothReadersHaveValidInputInput,
            //        new Binding {  Source = RatingsLookupTable.Instance, Path = new PropertyPath(RatingsLookupTable.HasDataProperty.Name)},
            //    }
            //};

            SetBinding(IsDataValidProperty, doBothReadersHaveValidInputInput);
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
            RatingsLookupTable.Instance.clearAllData();

            if (TextFileReader.readFromFile(FilePath))
            {
                Properties.Settings.Default.lastUsedTextFilePath = FilePath;
            }

            if (HasFakeProfiles && FakeProfilesTextFileReader.readFromFile(FakeProfilesFilePath))
            {
                Properties.Settings.Default.lastUsedFakeProfilesTextFilePath = FakeProfilesFilePath;
            }

            Properties.Settings.Default.Save();
        }

        private void OnReaderStateChange(TextFileDataIO.TextFileReaderState state)
        {
            outputToTextbox(state.Message);
        }

        private void onReaderReportProgress(int percentage)
        {
            m_completionProgressBar.Value = (m_normalDataIoModule.getCompletionPercentage() + m_fakeProfilesDataIoModule.getCompletionPercentage() )/2;
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
