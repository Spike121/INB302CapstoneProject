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

        private AbstractAppUC currentUC;
        private RecommenderAttacksAnalytics.UI.AbstractAppUC.AppPage currentPage = AbstractAppUC.AppPage.NONE;

        public MainWindow()
        {
            InitializeComponent();
            changeLeftPanelContent(AbstractAppUC.AppPage.LOAD_DATA_PAGE);
            
        }

        private void loadUc(AbstractAppUC uc)
        {
            if(currentUC != null)
                currentUC.ChangePage -= OnCurrentUcChangePage;  
            
            currentUC = uc;
            currentUC.ChangePage += new AbstractAppUC.ChangePageHandler(OnCurrentUcChangePage);
            leftPanelContent.Content = currentUC;
        }

        private void changeLeftPanelContent(RecommenderAttacksAnalytics.UI.AbstractAppUC.AppPage page)
        {
            if (currentPage != AbstractAppUC.AppPage.NONE && currentPage == page)
                return;

            AbstractAppUC uc = null;

            switch (page)
            {

                case AbstractAppUC.AppPage.SELECT_USERS: uc = new SelectUsersUC();
                    break;
                case AbstractAppUC.AppPage.LOAD_DATA_PAGE: uc = new ReadTextFileUC();
                    break;
                case AbstractAppUC.AppPage.TEST: uc = new TestUC();
                    break;
            }

            currentPage = page;
            loadUc(uc);
        }

        private void OnCurrentUcChangePage(RecommenderAttacksAnalytics.UI.AbstractAppUC.AppPage page) 
        {
            changeLeftPanelContent(page);
        }

        private void testPageBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeLeftPanelContent(AbstractAppUC.AppPage.TEST);
        }

        private void uploadDataBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeLeftPanelContent(AbstractAppUC.AppPage.LOAD_DATA_PAGE);
        }
    }
}
