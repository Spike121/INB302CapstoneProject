using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using RecommenderAttacksAnalytics.EventArguments;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;

namespace RecommenderAttacksAnalytics.UI
{
    public class AbstractAppPageUC : UserControl
    {
        public event RoutedEventHandler PageChange;
        protected readonly MainWindow.AppPage m_currentPage;

        // Used to check if the content on a certain page is up to date compared to the latest data fetch and/or previous page data flow
        protected string m_pageValidationGuid = Guid.NewGuid().ToString();
        public string PageValidationGuid 
        {
            get { return m_pageValidationGuid; }
            set { m_pageValidationGuid = value; }
        }

        public AbstractAppPageUC() { }

        protected AbstractAppPageUC(MainWindow.AppPage page)
        {
            m_currentPage = page;
        }

        // TODO: Put this method and others as abstract when the XAML viewer is not needed anymore
        public virtual void activate(IPageChangeParameters parameters) { }

        protected void registerPageContentChange()
        {
            m_pageValidationGuid = Guid.NewGuid().ToString();
        }

        private void doPageChange(PageChangeEventArgs args)
        {
            if (PageChange != null)
                PageChange(this,args);
        }

        protected void changePageTo(MainWindow.AppPage toPage)
        {
            doPageChange(new PageChangeEventArgs(m_currentPage, toPage, m_pageValidationGuid));                
        }

        protected void changePageTo(MainWindow.AppPage toPage, IPageChangeParameters parameters)
        {
            doPageChange(new PageChangeEventArgs(m_currentPage, toPage,parameters));
        }

        protected void goToNextPage()
        {
            doPageChange(new NextPageChangeEventArgs(m_currentPage, m_pageValidationGuid));
        }

        protected void goToNextPage(IPageChangeParameters parameters)
        {
            doPageChange(new NextPageChangeEventArgs(m_currentPage, parameters));
        }

        protected void goToPreviousPage()
        {
            doPageChange(new PreviousPageChangeEventArgs(m_currentPage, m_pageValidationGuid));
        }

        protected void goToPreviousPage(IPageChangeParameters parameters)
        {
            doPageChange(new PreviousPageChangeEventArgs(m_currentPage, parameters));
        }

        protected virtual void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            goToNextPage();
        }

        protected virtual void previousPageBtn_Click(object sender, RoutedEventArgs e)
        {
            goToPreviousPage();
        } 
    }
}
