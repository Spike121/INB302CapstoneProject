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
using RecommenderAttacksAnalytics.Models;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for TestUC.xaml
    /// </summary>
    public partial class TestUC : AbstractAppUC
    {

        AbstractModel currentModel;

        public TestUC()
        {
            InitializeComponent();
            Random r = new Random();
            var userId = (int)(r.NextDouble() * 999);

            if (RatingsLookupTable.Instance.hasUser(userId)) 
            {
                currentModel = new UserCentricModel(userId);
                currentModel.computePredictions();
            }


        }
    }
}
