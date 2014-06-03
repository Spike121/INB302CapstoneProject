using System.Linq;
using System.Windows;
using System.Windows.Data;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using System.Collections.ObjectModel;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for SelectItemsUC.xaml
    /// </summary>
    public partial class SelectItemsUC : AbstractAppPageUC
    {
        public ObservableCollection<Item> Items
        {
            get { return (ObservableCollection<Item>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public ObservableCollection<Item> PromotedItems
        {
            get { return (ObservableCollection<Item>)GetValue(PromotedItemsProperty); }
            set { SetValue(PromotedItemsProperty, value); }
        }

        public CompositeCollection CombinedItems
        {
            get { return (CompositeCollection)GetValue(CombinedItemsProperty); }
            set { SetValue(CombinedItemsProperty, value); }
        }

        public static readonly DependencyProperty CombinedItemsProperty =
            DependencyProperty.Register("CombinedItems", typeof(CompositeCollection), typeof(SelectItemsUC));

        public static readonly DependencyProperty PromotedItemsProperty =
            DependencyProperty.Register("PromotedItems", typeof(ObservableCollection<Item>), typeof(SelectItemsUC), new UIPropertyMetadata(new ObservableCollection<Item>()));

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<Item>), typeof(SelectItemsUC), new UIPropertyMetadata(new ObservableCollection<Item>()));

        private User m_selectedUser;
        public User SelectedUser 
        { 
            get { return m_selectedUser; }
        }

        public SelectItemsUC()
            : base(MainWindow.AppPage.SELECT_ITEMS_PAGE)
        {
            InitializeComponent();
        }

        public override void activate(BasePageChangeParameters p)
        {
            if (isCurrentPageValidationDifferenFromPreviousPage(p))
            {
                if (p is FromSelectUsersPageChangeParameters)
                {
                    var parameters = p as FromSelectUsersPageChangeParameters;
                    m_selectedUser = parameters.SelectedUser;
                }

                var unsortedPromotedItems = RatingsLookupTable.Instance.FakeProfilesTable.getPromotedItems();
                var unsortedItems = RatingsLookupTable.Instance.getItems().Where(x => !unsortedPromotedItems.Contains(x));

                PromotedItems = new ObservableCollection<Item>(unsortedPromotedItems.OrderBy(x => x.getId()));
                Items = new ObservableCollection<Item>(unsortedItems.OrderBy(x => x.getId()));

                CombinedItems = new CompositeCollection
                {
                    new CollectionContainer {Collection = PromotedItems},
                    new CollectionContainer {Collection = Items}
                };

            }
        }

        protected override void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedRegularItems = m_itemsSelector.SelectedItems.Cast<Item>().Where(x => !x.IsPromoted);
            var selectedPromotedItems = m_itemsSelector.SelectedItems.Cast<Item>().Where(x => x.IsPromoted);

            goToNextPage(new FromSelectItemsPageChangeParameters(m_pageValidationGuid, m_selectedUser, selectedRegularItems, selectedPromotedItems));
        }
    }
}
