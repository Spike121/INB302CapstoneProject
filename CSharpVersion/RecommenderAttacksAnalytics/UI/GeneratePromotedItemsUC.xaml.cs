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
using RecommenderAttacksAnalytics.Output;
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
                    AllItems = new List<Item>(RatingsLookupTable.Instance.getItems().OrderBy(x => x.getId()));
                }
            }
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            var promotedItems = m_itemSelectionListBox.SelectedItems.Cast<Item>().ToList();
            m_fakeProfilesGenerator.generateFakeProfiles(GeneratedFakeProfilesCount, promotedItems, FillingMethod == FillingMethodEnum.RANDOM);
            if(saveFakeProfiles.IsChecked == true) 
                Output.FakeProfilesToTextfile.CreateFakeProfilesTextfile();
            changePageTo(MainWindow.AppPage.SELECT_USERS_PAGE);
        }

        private void selectRandomItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nbOfItemsToSelect = Int32.Parse(m_selectRandomItemsTextBox.Text);
                const int minNumberOfItems = 0;
                int maxNumberOfItems = AllItems.Count;

                if (nbOfItemsToSelect > maxNumberOfItems)
                    nbOfItemsToSelect = maxNumberOfItems;

                if (nbOfItemsToSelect < 0)
                    nbOfItemsToSelect = minNumberOfItems;

                m_selectRandomItemsTextBox.Text = nbOfItemsToSelect.ToString();
                m_itemSelectionListBox.SelectedItems.Clear();
                
                while (m_itemSelectionListBox.SelectedItems.Count != nbOfItemsToSelect)
                {
                    var item = m_itemSelectionListBox.Items.GetItemAt(new Random().Next(minNumberOfItems, maxNumberOfItems));
                    if (!m_itemSelectionListBox.SelectedItems.Contains(item))
                        m_itemSelectionListBox.SelectedItems.Add(item);
                }


            }
            catch (FormatException)
            {
                // TODO: Proper exception handling
            }
            catch (OverflowException)
            {
                // TODO: Proper exception handling 
            }
            

        }

        private void saveFakeProfiles_Click(object sender, RoutedEventArgs e) {
            saveFakeProfiles.IsChecked = true;
        }
    }
}
