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
        public virtual void activate(BasePageChangeParameters parameters) { }

        protected bool isCurrentPageValidationDifferenFromPreviousPage(BasePageChangeParameters p)
        {
            return p.getPreviousPageValidationGuid() != PageValidationGuid;
        }

        protected void registerPageContentChange()
        {
            m_pageValidationGuid = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Call the page change event
        /// </summary>
        /// <param name="args"></param>
        private void doPageChange(PageChangeEventArgs args)
        {
            if (PageChange != null)
                PageChange(this,args);
        }

        /// <summary>
        /// Triggers a page change to a particular page
        /// </summary>
        /// <param name="destinationPage"></param>
        protected void changePageTo(MainWindow.AppPage destinationPage)
        {
            doPageChange(new PageChangeEventArgs(m_currentPage, destinationPage, m_pageValidationGuid));                
        }

        /// <summary>
        /// Triggers a page change to a particular page, along with data from the current page
        /// </summary>
        /// <param name="destinationPage"></param>
        /// <param name="parameters"></param>
        protected void changePageTo(MainWindow.AppPage destinationPage, BasePageChangeParameters parameters)
        {
            doPageChange(new PageChangeEventArgs(m_currentPage, destinationPage,parameters));
        }

        /// <summary>
        /// Triggers a page change to the next page (if any)
        /// </summary>
        protected void goToNextPage()
        {
            doPageChange(new NextPageChangeEventArgs(m_currentPage, m_pageValidationGuid));
        }

        /// <summary>
        /// Triggers a page change to the next page (if any), along with data from the current page
        /// </summary>
        /// <param name="parameters"></param>
        protected void goToNextPage(BasePageChangeParameters parameters)
        {
            doPageChange(new NextPageChangeEventArgs(m_currentPage, parameters));
        }

        /// <summary>
        /// Triggers a page change to the previous page (if any)
        /// </summary>
        protected void goToPreviousPage()
        {
            doPageChange(new PreviousPageChangeEventArgs(m_currentPage, m_pageValidationGuid));
        }

        /// <summary>
        /// Triggers a page change to the previous page (if any), along with data from the current page
        /// </summary>
        /// <param name="parameters"></param>
        protected void goToPreviousPage(BasePageChangeParameters parameters)
        {
            doPageChange(new PreviousPageChangeEventArgs(m_currentPage, parameters));
        }

        /// <summary>
        /// Handle a click on the next page button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            goToNextPage();
        }

        /// <summary>
        /// Handle a click on the previous page button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void previousPageBtn_Click(object sender, RoutedEventArgs e)
        {
            goToPreviousPage();
        } 
    }
}
