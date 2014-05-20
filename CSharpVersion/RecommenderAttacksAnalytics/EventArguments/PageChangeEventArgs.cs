using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using RecommenderAttacksAnalytics.UI;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;

namespace RecommenderAttacksAnalytics.EventArguments
{
    public class PageChangeEventArgs : RoutedEventArgs
    {
        protected enum PageChangeType { NEXT_PAGE, PREVIOUS_PAGE, SPECIFIC_PAGE };
        protected PageChangeType m_changeType;

        public bool IsNextPageChangeType { get { return m_changeType == PageChangeType.NEXT_PAGE; } }
        public bool IsPreviousPageChangeType { get { return m_changeType == PageChangeType.PREVIOUS_PAGE; } }

        public MainWindow.AppPage SourcePage { get; set; }
        public MainWindow.AppPage DestinationPage { get; set; }
        public IPageChangeParameters Parameters { get; set; }

        protected PageChangeEventArgs(MainWindow.AppPage sourcePage, IPageChangeParameters parameters) 
        {
            SourcePage = sourcePage;
            Parameters = parameters;
            m_changeType = PageChangeType.SPECIFIC_PAGE;
        }

        public PageChangeEventArgs(MainWindow.AppPage sourcePage,
                                    MainWindow.AppPage destPage,
                                    IPageChangeParameters parameters)
            : this(sourcePage, parameters)
        {
            DestinationPage = destPage;
        }

        public PageChangeEventArgs(MainWindow.AppPage sourcePage,
                                    MainWindow.AppPage destPage,
                                    string sourcePageValidationGuid)
            : this(sourcePage, destPage, new BasePageChangeParameters(sourcePageValidationGuid))
        {

        }
    }

    public class NextPageChangeEventArgs : PageChangeEventArgs     
    {   
        
        public NextPageChangeEventArgs( MainWindow.AppPage sourcePage, IPageChangeParameters parameters)
            : base(sourcePage, parameters)
        {
            m_changeType = PageChangeType.NEXT_PAGE;
        }

        public NextPageChangeEventArgs(MainWindow.AppPage sourcePage, string sourcePageValidationGuid)
            : this(sourcePage, new BasePageChangeParameters(sourcePageValidationGuid))
        {
            
        }
    }

    public class PreviousPageChangeEventArgs : PageChangeEventArgs
    {
        public PreviousPageChangeEventArgs(MainWindow.AppPage sourcePage, IPageChangeParameters parameters)
            : base(sourcePage, parameters)
        {
            m_changeType = PageChangeType.PREVIOUS_PAGE;
        }

        public PreviousPageChangeEventArgs(MainWindow.AppPage sourcePage, string sourcePageValidationGuid)
            : this(sourcePage, new BasePageChangeParameters(sourcePageValidationGuid))
        {
            
        }

        
    }
}
