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
using RecommenderAttacksAnalytics.Utililty;
using RecommenderAttacksAnalytics.Input;
using Microsoft.Win32;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for ReadFromDatabaseUc.xaml
    /// </summary>
    public partial class ReadFromDatabaseUc : AbstractDataUploadUC
    {
        private DatabaseInfos m_databaseInfos = new DatabaseInfos();
        public DatabaseInfos DatabaseInfos 
        {
            get { return m_databaseInfos;  } 
        }

        public ReadFromDatabaseUc()
        {
            InitializeComponent();
        }

        private void m_fetchDataBtn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseReader.FetchEntities(hostname.Text, username.Text, password.Password, Convert.ToInt32(port.Text), schema.Text);
        }

        private void m_saveAsFileBtn_Click(object sender, RoutedEventArgs e)
        {
             var dialog = new SaveFileDialog();
            var result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                var filePath = dialog.FileName;
                m_databaseInfos.saveAsXml(filePath);
            }
        }

        private void m_loadFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                var filePath = dialog.FileName;
                m_databaseInfos.loadFromFile(filePath);
            }
        }
    }
}
