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

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for GeneratePromotedItemsUC.xaml
    /// </summary>
    public partial class GeneratePromotedItemsUC : AbstractAppPageUC
    {
        private FakeProfilesGenerator m_fakeProfilesGenerator = new FakeProfilesGenerator();

        public GeneratePromotedItemsUC()
            : base(MainWindow.AppPage.GENERATE_PROMOTED_ITEMS_PAGE)
        {
            InitializeComponent();
        }

        private void m_generateBtn_Click(object sender, RoutedEventArgs e)
        {
            //m_fakeProfilesGenerator.generateFakeProfiles();
        }
    }
}
