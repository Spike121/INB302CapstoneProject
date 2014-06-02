using System.Windows;
using RecommenderAttacksAnalytics.InputOutput;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for DataSourceUploadContainerUC.xaml
    /// </summary>
    public partial class DataSourceUploadContainerUC
    {
        private readonly ReadTextFileUC m_textFileUploadUc = new ReadTextFileUC();
        private readonly ReadFromDatabaseUc m_databaseUploadUc = new ReadFromDatabaseUc();

        public AbstractDataUploadUC SelectedDataSourceUploadUc
        {
            get { return (AbstractDataUploadUC)GetValue(SelectedDataSourceUploadUcProperty); }
            set { SetValue(SelectedDataSourceUploadUcProperty, value); }
        }

        public bool AreFakeProfilesFromSameSource
        {
            get { return (bool)GetValue(AreFakeProfilesFromSameSourceProperty); }
            set { SetValue(AreFakeProfilesFromSameSourceProperty, value); }
        }

        public static readonly DependencyProperty AreFakeProfilesFromSameSourceProperty =
            DependencyProperty.Register("AreFakeProfilesFromSameSource", typeof(bool), typeof(DataSourceUploadContainerUC), new UIPropertyMetadata(false));

        public static readonly DependencyProperty SelectedDataSourceUploadUcProperty =
            DependencyProperty.Register("SelectedDataSourceUploadUc", typeof(AbstractDataUploadUC), typeof(DataSourceUploadContainerUC));

        public DataSourceUploadContainerUC()
            : base(MainWindow.AppPage.LOAD_DATA_PAGE)
        {
            InitializeComponent();
            
            loadTextFileUploadUc();
        }

        private void loadTextFileUploadUc()
        {
            loadUc(m_textFileUploadUc);
            m_textFileOptionRadioButton.IsChecked = true;
        }

        private void loadDatabaseUploadUc()
        {
            loadUc(m_databaseUploadUc);
            m_databaseOptionRadioButton.IsChecked = true;
        }

        private void loadUc(AbstractDataUploadUC uc)
        { 
            SelectedDataSourceUploadUc = uc;
        }

        private void saveToDbButton_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            Output.SaveToDB.SaveToDatabase();
=======
            
>>>>>>> 4e15afde64938dcbfdfb1b853566dc3e24ca721e
        }

        private void textFileOptionRadioButton_Click(object sender, RoutedEventArgs e)
        {
            loadTextFileUploadUc();
        }

        private void databaseOptionRadioButton_Click(object sender, RoutedEventArgs e)
        {
            loadDatabaseUploadUc();
        }

        protected override void nextPageBtn_Click(object sender, RoutedEventArgs e) {
            
            if(AreFakeProfilesFromSameSource) 
                base.nextPageBtn_Click(sender, e);
            else
                changePageTo(MainWindow.AppPage.GENERATE_PROMOTED_ITEMS_PAGE, new BasePageChangeParameters(m_pageValidationGuid));
        }
    }
}
