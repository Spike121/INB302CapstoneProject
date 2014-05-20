using System.Linq;
using System.Windows;
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



        public ObservableCollection<Item> FakeItems
        {
            get { return (ObservableCollection<Item>)GetValue(FakeItemsProperty); }
            set { SetValue(FakeItemsProperty, value); }
        }

        public static readonly DependencyProperty FakeItemsProperty =
            DependencyProperty.Register("FakeItems", typeof(ObservableCollection<Item>), typeof(SelectItemsUC), new UIPropertyMetadata(new ObservableCollection<Item>()));

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

        public override void  activate(IPageChangeParameters p)
        {
            if (p is FromSelectUsersPageChangeParameters)
            {
                var parameters = p as FromSelectUsersPageChangeParameters;
                m_selectedUser = parameters.SelectedUser;
            }

            Items = new ObservableCollection<Item>(RatingsLookupTable.Instance.getItems());
            FakeItems = new ObservableCollection<Item>(RatingsLookupTable.Instance.FakeProfilesTable.getItems());
        }

        protected override void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = m_itemsSelector.SelectedItems.Cast<Item>();
            //var selectedFakeItems = m_itemsSelector.SelectedItems.Cast<Item>();
            goToNextPage(new FromSelectItemsPageChangeParameters(m_pageValidationGuid, m_selectedUser, selectedItems, FakeItems));
        }
    }
}
