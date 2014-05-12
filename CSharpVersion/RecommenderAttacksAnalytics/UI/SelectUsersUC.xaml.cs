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
    public partial class SelectUsersUC : AbstractAppPageUC, INotifyPropertyChanged
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

        public override void activate()
        {
            Users = new ObservableCollection<User>(RatingsLookupTable.Instance.getUsers());
        }

        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToNextPage(new FromSelectUsersPageParameters(m_leftUserSelector.SelectedItem as User));
        }

        private void previousPageBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToPreviousPage();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
