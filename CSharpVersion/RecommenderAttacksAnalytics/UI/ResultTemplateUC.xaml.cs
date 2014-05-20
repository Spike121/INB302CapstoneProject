using System.Windows.Controls;
using RecommenderAttacksAnalytics.Models;
using System.Windows;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for ResultTemplateUC.xaml
    /// </summary>
    public partial class ResultTemplateUC : UserControl
    {
        public double OriginalPrediction
        {
            get { return (double)GetValue(OriginalPredictionProperty); }
            set { SetValue(OriginalPredictionProperty, value); }
        }

        public double FinalPrediction
        {
            get { return (double)GetValue(FinalPredictionProperty); }
            set { SetValue(FinalPredictionProperty, value); }
        }

        public int EntityId
        {
            get { return (int)GetValue(EntityIdProperty); }
            set { SetValue(EntityIdProperty, value); }
        }

        public static readonly DependencyProperty EntityIdProperty =
            DependencyProperty.Register("EntityId", typeof(int), typeof(ResultTemplateUC));

        public static readonly DependencyProperty FinalPredictionProperty =
            DependencyProperty.Register("FinalPrediction", typeof(double), typeof(ResultTemplateUC));

        public static readonly DependencyProperty OriginalPredictionProperty =
            DependencyProperty.Register("OriginalPrediction", typeof(double), typeof(ResultTemplateUC));

        public ResultTemplateUC()
        {
            InitializeComponent();
        }
    }
}
