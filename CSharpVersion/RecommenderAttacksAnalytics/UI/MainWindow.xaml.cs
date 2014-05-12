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
using RecommenderAttacksAnalytics.EventArguments;

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
                currentUC.PageChange -= OnCurrentUcChangePageEvent;
            }

            currentUC = uc;
            currentUC.PageChange += new RoutedEventHandler(OnCurrentUcChangePageEvent);

            leftPanelContent.Content = currentUC;
            currentUC.activate();
        }

        private void changeLeftPanelContent(AppPage page)
        { 
            changeLeftPanelContent(page, null);
        }

        private void changeLeftPanelContent(AppPage page, PageChangeEventArgs args)
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
            
            //TODO: Maybe change that for a HasParams property inside PageChangeEventArgs
            //TODO: Or even maybe only keep Parameters object ?
            if(args != null)
                uc.loadPreviousPageParams(args.Parameters);

            loadUc(uc);
        }

        private void goToNextPage()
        {
            if (m_pageIndex >= (int)AppPage.SELECT_ITEMS_PAGE)
                return;

            m_pageIndex++;
            changeLeftPanelContent((AppPage)m_pageIndex);
        }

        private void goToPreviousPage(PageChangeEventArgs args)
        {
            if (m_pageIndex <= 0)
                return;

            m_pageIndex--;
            changeLeftPanelContent((AppPage)m_pageIndex, args);
        }


        private void goToNextPage(PageChangeEventArgs args)
        {
            if (m_pageIndex >= (int)AppPage.SELECT_ITEMS_PAGE)
                return;

            m_pageIndex++;
            changeLeftPanelContent((AppPage)m_pageIndex, args);
        }

        private void goToPreviousPage()
        {
            if (m_pageIndex <= 0)
                return;

            m_pageIndex--;
            changeLeftPanelContent((AppPage)m_pageIndex);
        }

        private void OnCurrentUcChangePageEvent(object sender, RoutedEventArgs args) 
        {
            var pageChangeEventArgs = args as PageChangeEventArgs;
            
            if (pageChangeEventArgs.IsNextPageChangeType)
                goToNextPage(pageChangeEventArgs);
            else if (pageChangeEventArgs.IsPreviousPageChangeType)
                goToPreviousPage(pageChangeEventArgs);
            else
                changeLeftPanelContent(pageChangeEventArgs.ToPage, pageChangeEventArgs);
        }

        private void testPageBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeLeftPanelContent(AppPage.TEST);
        }

        private void getDataBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeLeftPanelContent(AppPage.LOAD_DATA_PAGE);
        }
    }
}
