using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace RecommenderAttacksAnalytics.UI
{
    public class AbstractAppUC : UserControl
    {
        public enum AppPage {LOAD_DATA_PAGE, SELECT_USERS, SELECT_ITEMS};
        public delegate void ChangePageHandler(AppPage page);

        public event ChangePageHandler ChangePage;
        protected static int pageIndex = 0;

        protected void ChangePageTo(AppPage page)
        {
            if (ChangePage != null)
            {
                ChangePage(page);
                pageIndex = (int)page;
            }
        }

        protected void GoToNextPage()
        {
            if (pageIndex >= (int) AppPage.SELECT_USERS)
                return;

            pageIndex++;
            ChangePageTo((AppPage)pageIndex);
        }

        protected void GoToPreviousPage()
        {
            if (pageIndex <= 0)
                return;

            pageIndex--;
            ChangePageTo((AppPage)pageIndex);
        }
    }
}
