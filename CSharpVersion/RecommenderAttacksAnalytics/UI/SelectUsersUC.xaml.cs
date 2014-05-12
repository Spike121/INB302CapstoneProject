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

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for SelectUsersUC.xaml
    /// </summary>
    public partial class SelectUsersUC : AbstractAppPageUC
    {
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

        public SelectUsersUC()
        {
            InitializeComponent();

            m_leftUserSelector.ItemsSource = UnselectedUsers;
            UnselectedUsers = new ObservableCollection<User>(RatingsLookupTable.Instance.getUsers());
        }

        public override void activate()
        {
            UnselectedUsers = new ObservableCollection<User>(RatingsLookupTable.Instance.getUsers());
        }

        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToNextPage();
        }

        private void previousPageBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToPreviousPage();
        }
    }
}
