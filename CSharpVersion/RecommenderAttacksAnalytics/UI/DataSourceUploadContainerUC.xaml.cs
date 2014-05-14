using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for DataSourceUploadContainerUC.xaml
    /// </summary>
    public partial class DataSourceUploadContainerUC : AbstractAppPageUC
    {
        private ReadTextFileUC m_textFileUploadUc = new ReadTextFileUC();
        private ReadFromDatabaseUc m_databaseUploadUc = new ReadFromDatabaseUc();

        public bool IsDataValid
        {
            get { return (bool)GetValue(IsDataValidProperty); }
            set { SetValue(IsDataValidProperty, value); }
        }

        public AbstractDataUploadUC SelectedDataSourceUploadUc
        {
            get { return (AbstractDataUploadUC)GetValue(SelectedDataSourceUploadUcProperty); }
            set { SetValue(SelectedDataSourceUploadUcProperty, value); }
        }

        public static readonly DependencyProperty IsDataValidProperty =
            DependencyProperty.Register("IsDataValid", typeof(bool), typeof(DataSourceUploadContainerUC), new UIPropertyMetadata(false));

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
            if(SelectedDataSourceUploadUc != null)
            {
                SelectedDataSourceUploadUc.DataValidityStateChangeEvent -= OnDataValidityChange;
            }

            SelectedDataSourceUploadUc = uc;
            SelectedDataSourceUploadUc.DataValidityStateChangeEvent +=new AbstractDataUploadUC.DataValidityStateChangeHandler(OnDataValidityChange);
        }

        private void OnDataValidityChange(bool isValid)
        {
            if (IsDataValid != isValid)
            {
                registerPageContentChange();
                IsDataValid = isValid;
            }
        }

        private void saveToDbButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textFileOptionRadioButton_Click(object sender, RoutedEventArgs e)
        {
            loadTextFileUploadUc();
        }

        private void databaseOptionRadioButton_Click(object sender, RoutedEventArgs e)
        {
            loadDatabaseUploadUc();
        }
    }
}
