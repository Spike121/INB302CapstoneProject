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
using System.ComponentModel;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for SelectUsersUC.xaml
    /// </summary>
    public partial class SelectUsersUC : AbstractAppPageUC
    {
        /*
        private ObservableCollection<User> m_unselectedUsers = new ObservableCollection<User>();
        private ObservableCollection<User> m_selectedUsers = new ObservableCollection<User>();

        public ObservableCollection<User> UnselectedUsers 
        { 
            get { return m_unselectedUsers; } 
            set { m_unselectedUsers = value; } 
        }
        public ObservableCollection<User> SelectedUsers 
        { 
            get { return m_selectedUsers; } 
            set { m_selectedUsers = value; } 
        }
        */

        public ObservableCollection<User> Users
        {
            get { return (ObservableCollection<User>)GetValue(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        
        public static readonly DependencyProperty UsersProperty =
            DependencyProperty.Register("Users", typeof(ObservableCollection<User>), typeof(SelectUsersUC), new UIPropertyMetadata(new ObservableCollection<User>()));

        public SelectUsersUC()
            : base(MainWindow.AppPage.SELECT_USERS_PAGE)
        {
            InitializeComponent();
        }

        public override void  activate(IPageChangeParameters parameters)
        {
            if (parameters.getPreviousPageValidationGuid() != this.PageValidationGuid)
            {
                Users = new ObservableCollection<User>(RatingsLookupTable.Instance.getUsers().OrderBy(x => x.getId()));
                this.PageValidationGuid = parameters.getPreviousPageValidationGuid();
            }
        }

        private void OnListItemDoubleClick(object sender, RoutedEventArgs args)
        {
            if (sender is ListBoxItem)
            {
                var listBoxItem = sender as ListBoxItem;
                goToNextPage(new FromSelectUsersPageChangeParameters(m_pageValidationGuid, listBoxItem.Content as User));
            }
        }

        protected override void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            goToNextPage(new FromSelectUsersPageChangeParameters(m_pageValidationGuid, m_leftUserSelector.SelectedItem as User));
        }
    }
}
