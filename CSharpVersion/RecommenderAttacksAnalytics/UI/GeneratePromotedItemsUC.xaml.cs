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
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;
using RecommenderAttacksAnalytics.Utililty;
using Remotion.Linq.Collections;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for GeneratePromotedItemsUC.xaml
    /// </summary>
    public partial class GeneratePromotedItemsUC : AbstractAppPageUC
    {
        private readonly FakeProfilesGenerator m_fakeProfilesGenerator = new FakeProfilesGenerator();
        public enum FillingMethodEnum {RANDOM, TARGETED};

        private const int DEFAULT_GENERATED_FAKE_PROFILES = 50;
        private const int MAX_GENERATED_FAKE_PROFILES = 10000;

        public int GeneratedFakeProfilesCount
        {
            get { return (int)GetValue(GeneratedFakeProfilesCountProperty); }
            set { SetValue(GeneratedFakeProfilesCountProperty, value); }
        }

        public List<Item> AllItems
        {
            get { return (List<Item>)GetValue(AllItemsProperty); }
            set { SetValue(AllItemsProperty, value); }
        }

        public FillingMethodEnum FillingMethod
        {
            get { return (FillingMethodEnum)GetValue(FillingMethodProperty); }
            set { SetValue(FillingMethodProperty, value); }
        }

        public static readonly DependencyProperty FillingMethodProperty =
            DependencyProperty.Register("FillingMethod", typeof(FillingMethodEnum), typeof(GeneratePromotedItemsUC), new UIPropertyMetadata(FillingMethodEnum.RANDOM));
        
        public static readonly DependencyProperty AllItemsProperty =
            DependencyProperty.Register("AllItems", typeof(List<Item>), typeof(GeneratePromotedItemsUC), new UIPropertyMetadata(new List<Item>()));

        public static readonly DependencyProperty GeneratedFakeProfilesCountProperty =
            DependencyProperty.Register("GeneratedFakeProfilesCount", typeof(int), typeof(GeneratePromotedItemsUC), new UIPropertyMetadata(DEFAULT_GENERATED_FAKE_PROFILES));

        public GeneratePromotedItemsUC()
            : base(MainWindow.AppPage.GENERATE_PROMOTED_ITEMS_PAGE)
        {
            InitializeComponent();
        }

        public override void activate(BasePageChangeParameters p)
        {
            if(isCurrentPageValidationDifferenFromPreviousPage(p))
            {
                var parameters = p as BasePageChangeParameters;
                if (parameters.getPreviousPageValidationGuid() != PageValidationGuid)
                {
                    //AllItems.Clear();
                    //foreach (var item in RatingsLookupTable.Instance.getItems())
                        //AllItems.Add(item);
                    AllItems = new List<Item>(RatingsLookupTable.Instance.getItems());
                }
            }
        }

        private void m_generateBtn_Click(object sender, RoutedEventArgs e)
        {
            var promotedItems = m_itemSelectionListBox.SelectedItems.Cast<Item>().ToList();
            m_fakeProfilesGenerator.generateFakeProfiles(GeneratedFakeProfilesCount, promotedItems, FillingMethod == FillingMethodEnum.RANDOM);
            changePageTo(MainWindow.AppPage.SELECT_USERS_PAGE);
        }
    }
}
