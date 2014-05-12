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
using RecommenderAttacksAnalytics.UI;

namespace RecommenderAttacksAnalytics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum AppPage { LOAD_DATA_PAGE, SELECT_USERS_PAGE, SELECT_ITEMS_PAGE, RESULTS_PAGE,TEST, NONE };
        private AbstractAppPageUC currentUC;
        private AppPage currentPage = AppPage.NONE;
        protected int m_pageIndex;

        private DataSourceUploadContainerUC m_loadDataPage;
        private AbstractAppPageUC LoadDataPage
        {
            get 
            {
                if (m_loadDataPage == null)
                    m_loadDataPage = new DataSourceUploadContainerUC();
                return m_loadDataPage;
            }
        }

        private SelectUsersUC m_selectUsersPage;
        private SelectUsersUC SelectUsersPage
        {
            get
            {
                if (m_selectUsersPage == null)
                    m_selectUsersPage = new SelectUsersUC();
                return m_selectUsersPage;
            }
        }

        private SelectItemsUC m_selectItemsPage;
        private SelectItemsUC SelectItemsPage
        {
            get
            {
                if (m_selectItemsPage == null)
                    m_selectItemsPage = new SelectItemsUC();
                return m_selectItemsPage;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            changeLeftPanelContent(AppPage.LOAD_DATA_PAGE);
            
        }

        private void loadUc(AbstractAppPageUC uc)
        {
            if (currentUC != null)
            {
                currentUC.ChangePage -= OnCurrentUcChangePageEvent;
                currentUC.NextPage -= OnNextPageEvent;
                currentUC.PreviousPage -= OnPreviousPageEvent;
            }

            currentUC = uc;
            currentUC.ChangePage += new AbstractAppPageUC.ChangePageHandler(OnCurrentUcChangePageEvent);
            currentUC.NextPage += new RoutedEventHandler(OnNextPageEvent);
            currentUC.PreviousPage += new RoutedEventHandler(OnPreviousPageEvent);

            leftPanelContent.Content = currentUC;
            currentUC.activate();
        }

        private void changeLeftPanelContent(AppPage page)
        {
            if (currentPage != AppPage.NONE && currentPage == page)
                return;

            AbstractAppPageUC uc = null;

            switch (page)
            {
                case AppPage.LOAD_DATA_PAGE: uc = LoadDataPage;
                    break;
                case AppPage.SELECT_USERS_PAGE: uc = SelectUsersPage;
                    break;
                case AppPage.SELECT_ITEMS_PAGE: uc = SelectItemsPage;
                    break;
                
                case AppPage.TEST: uc = new TestUC();
                    break;
            }

            currentPage = page;
            m_pageIndex = (int)currentPage;
            loadUc(uc);
        }

        private void OnNextPageEvent(object sender, RoutedEventArgs args)
        {
            if (m_pageIndex >= (int)AppPage.SELECT_ITEMS_PAGE)
                return;

            m_pageIndex++;
            changeLeftPanelContent((AppPage)m_pageIndex);
        }

        private void OnPreviousPageEvent(object sender, RoutedEventArgs args)
        {
            if (m_pageIndex <= 0)
                return;

            m_pageIndex--;
            changeLeftPanelContent((AppPage)m_pageIndex);
        }

        private void OnCurrentUcChangePageEvent(AppPage page) 
        {
            changeLeftPanelContent(page);
        }

        private void testPageBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeLeftPanelContent(AppPage.TEST);
        }

        private void uploadDataBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeLeftPanelContent(AppPage.LOAD_DATA_PAGE);
        }
    }
}
