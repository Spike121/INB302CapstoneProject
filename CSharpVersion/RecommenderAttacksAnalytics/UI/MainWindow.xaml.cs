using System;
using System.Windows;
using System.Windows.Input;
using RecommenderAttacksAnalytics.EventArguments;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;
using RecommenderAttacksAnalytics.Utility;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum AppPage { LOAD_DATA_PAGE, SELECT_USERS_PAGE, SELECT_ITEMS_PAGE, RESULTS_PAGE, GENERATE_PROMOTED_ITEMS_PAGE,TEST, NONE };
        private const AppPage FIRST_PAGE = AppPage.LOAD_DATA_PAGE;
        private const AppPage LAST_PAGE = AppPage.RESULTS_PAGE;


        // TODO: Combine these 3 parameters into one an put it in AbstractAppPageUc
        private AbstractAppPageUC m_currentAppPage;
        private AppPage m_currentPageAsEnum = AppPage.NONE;
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

        private ResultsUC m_resultsPage;
        private ResultsUC ResultsPage
        {
            get
            {
                if (m_resultsPage == null)
                    m_resultsPage = new ResultsUC();
                return m_resultsPage;
            }
        }

        private GeneratePromotedItemsUC m_promoteItemsGeneratePage;
        private GeneratePromotedItemsUC PromoteItemsGeneratePage
        {
            get
            {
                if (m_promoteItemsGeneratePage == null)
                    m_promoteItemsGeneratePage = new GeneratePromotedItemsUC();
                return m_promoteItemsGeneratePage;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            goDirectlyToPage(AppPage.LOAD_DATA_PAGE);
        }

        private int getPageIndex(AppPage pageAsEnum)
        {
            return (int)pageAsEnum;
        }

        private void loadUc(AbstractAppPageUC pageToLoad, BasePageChangeParameters parameters)
        {
            if (m_currentAppPage != null)
            {
                m_currentAppPage.PageChange -= OnCurrentUcChangePageEvent;
            }

            m_currentAppPage = pageToLoad;
            m_currentAppPage.PageChange += OnCurrentUcChangePageEvent;

            leftPanelContent.Content = m_currentAppPage;
            m_currentAppPage.activate(parameters);
        }

        private AbstractAppPageUC getAppPageFromEnum(AppPage pageAsEnum)
        {
            AbstractAppPageUC page = null;
            try
            {
                switch (pageAsEnum)
                {
                    case AppPage.LOAD_DATA_PAGE: page = LoadDataPage;
                        break;
                    case AppPage.SELECT_USERS_PAGE: page = SelectUsersPage;
                        break;
                    case AppPage.SELECT_ITEMS_PAGE: page = SelectItemsPage;
                        break;
                    case AppPage.RESULTS_PAGE: page = ResultsPage;
                        break;
                    case AppPage.TEST: page = new TestUC();
                        break;
                    case AppPage.GENERATE_PROMOTED_ITEMS_PAGE: page = PromoteItemsGeneratePage;
                        break;
                    
                    default: throw new MissingMethodException("Missing definition in function getAppPageFromEnum");
                }
            } 
            catch(Exception e)
            {
                Logger.logError(e.Message);
            }

            return page;
        }

        private void changeRightPanelContent(AppPage pageAsEnum, PageChangeEventArgs args)
        {
            if (m_currentPageAsEnum != AppPage.NONE && m_currentPageAsEnum == pageAsEnum)
                return;

            // This ensure that the user cannot move to following page containing outdated data
            //if (getAppPageFromEnum(pageAsEnum).PageValidationGuid == m_currentAppPage.PageValidationGuid || (int)pageAsEnum <= (m_pageIndex + 1))

            m_currentPageAsEnum = pageAsEnum;
            m_pageIndex = (int)m_currentPageAsEnum;

            var page = getAppPageFromEnum(pageAsEnum);
            //TODO: Maybe change that for a HasParams property inside PageChangeEventArgs
            //TODO: Or even maybe only keep Parameters object ?
            loadUc(page, args.Parameters);
        }

        private void goDirectlyToPage(AppPage destPageAsEnum)
        {
            changeRightPanelContent(destPageAsEnum, new PageChangeEventArgs(m_currentPageAsEnum, 
                                                                            destPageAsEnum,
                                                                            m_currentAppPage == null ? null : m_currentAppPage.PageValidationGuid));
        }

        private void goToNextPage()
        {
            if (m_pageIndex >= getPageIndex(LAST_PAGE))
                return;

            var destPage = (AppPage)(m_pageIndex + 1);
            goDirectlyToPage(destPage);
        }

        private void goToNextPage(PageChangeEventArgs args)
        {
            if (m_pageIndex >= getPageIndex(LAST_PAGE))
                return;

            var destPage = (AppPage)(m_pageIndex + 1);
            changeRightPanelContent(destPage, args);
        }

        private void goToPreviousPage()
        {
            if (m_pageIndex <= getPageIndex(FIRST_PAGE))
                return;

            var destPage = (AppPage)(m_pageIndex - 1);
            goDirectlyToPage(destPage);
        }

        private void goToPreviousPage(PageChangeEventArgs args)
        {
            if (m_pageIndex <= getPageIndex(FIRST_PAGE))
                return;

            var destPage = (AppPage)(m_pageIndex - 1);
            changeRightPanelContent(destPage, args);
        }

        private void OnCurrentUcChangePageEvent(object sender, RoutedEventArgs args) 
        {
            var pageChangeEventArgs = args as PageChangeEventArgs;
            
            if (pageChangeEventArgs.IsNextPageChangeType)
                goToNextPage(pageChangeEventArgs);
            else if (pageChangeEventArgs.IsPreviousPageChangeType)
                goToPreviousPage(pageChangeEventArgs);
            else
                changeRightPanelContent(pageChangeEventArgs.DestinationPage, pageChangeEventArgs);
        }

        private void testPageBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            goDirectlyToPage(AppPage.TEST);
        }

        private void getDataBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            goDirectlyToPage(AppPage.LOAD_DATA_PAGE);
        }

        private void m_selectUsersBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            goDirectlyToPage(AppPage.SELECT_USERS_PAGE);
        }
    }
}
