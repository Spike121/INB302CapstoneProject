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

        public override void  activate(PageChangeParameters.IPageChangeParameters p)
        {
            if (p is FromSelectUsersPageChangeParameters)
            {
                var parameters = p as FromSelectUsersPageChangeParameters;
                m_selectedUser = parameters.SelectedUser;
            }

            Items = new ObservableCollection<Item>(RatingsLookupTable.Instance.getItems());
        }

        protected override void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = m_itemsSelector.SelectedItems.Cast<Item>();
            goToNextPage(new FromSelectItemsPageChangeParameters(m_pageValidationGuid, m_selectedUser, selectedItems));
        }
    }
}
