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

        AbstractAppUC currentUC;
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
            AbstractAppUC uc = null;
            switch (page)
            {

                case AbstractAppUC.AppPage.SELECT_USERS: uc = new SelectUsersUC();
                    break;
                case AbstractAppUC.AppPage.LOAD_DATA_PAGE: uc = new ReadTextFileUC();
                    break;
            }

            loadUc(uc);
        }

        private void OnCurrentUcChangePage(RecommenderAttacksAnalytics.UI.AbstractAppUC.AppPage page) 
        {
            changeLeftPanelContent(page);
        }
    }
}
