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
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.UI {
    /// <summary>
    /// Interaction logic for GeneratePromoteItems.xaml
    /// </summary>
    public partial class GeneratePromoteItemsUC : AbstractAppPageUC {
        public GeneratePromoteItemsUC() 
        :base(MainWindow.AppPage.GENERATE_PROMOTE_ITEMS_PAGE)
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e) {
            //Call the method
            //Add ItemList (List<AbstractItem>)
            GenerateFakeProfiles.GenFakeProfiles(Convert.ToInt32(numFakeProfiles), Convert.ToInt32(numRandomItemsToPromote));
        }
    }
}
