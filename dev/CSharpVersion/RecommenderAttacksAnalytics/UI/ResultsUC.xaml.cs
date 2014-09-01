using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using RecommenderAttacksAnalytics.Converters;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Models;
using RecommenderAttacksAnalytics.UI.AsyncWrappers;
using RecommenderAttacksAnalytics.UI.Containers;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;
using RecommenderAttacksAnalytics.Utility;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for ResultsUC.xaml
    /// </summary>
    public partial class ResultsUC : AbstractAppPageUC
    {

        private readonly RatingsPredictionModelAsyncWrapper m_regularPredictionsAsyncWrapper = new RatingsPredictionModelAsyncWrapper("regular");
        private readonly RatingsPredictionModelAsyncWrapper m_postAttackPredictionsAsyncWrapper = new RatingsPredictionModelAsyncWrapper("attack");

        public bool IsProcessing
        {
            get { return (bool)GetValue(IsProcessingProperty); }
            set { SetValue(IsProcessingProperty, value); }
        }

        public static readonly DependencyProperty IsProcessingProperty =
            DependencyProperty.Register("IsProcessing", typeof(bool), typeof(ResultsUC), new PropertyMetadata(OnIsProcessingValueChange));

        private static void OnIsProcessingValueChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ResultsUC)
            {
                var r = d as ResultsUC;
                if ((bool)e.OldValue && !(bool)e.NewValue)
                    r.collectResultsFromWorkers();
            }
        }

        public ObservableCollection<PredictionResultContainer> PredictionsResults   {
            get { return (ObservableCollection<PredictionResultContainer>)GetValue(PredictionsResultsProperty); }
            set { SetValue(PredictionsResultsProperty, value); }
        }

        public static readonly DependencyProperty PredictionsResultsProperty =
            DependencyProperty.Register("PredictionsResults", typeof(ObservableCollection<PredictionResultContainer>), typeof(ResultsUC), new UIPropertyMetadata(new ObservableCollection<PredictionResultContainer>()));

        public ResultsUC()
            :base(MainWindow.AppPage.RESULTS_PAGE)
        {
            InitializeComponent();
            var isProcessingBinding = new MultiBinding()
            {
                Converter = new BooleanOrToBoolConverter(), 
                Bindings =
                {
                    new Binding{ Source = m_regularPredictionsAsyncWrapper, Path = new PropertyPath(RatingsPredictionModelAsyncWrapper.IsRunningProperty.Name)},
                    new Binding{ Source = m_postAttackPredictionsAsyncWrapper, Path = new PropertyPath(RatingsPredictionModelAsyncWrapper.IsRunningProperty.Name)}
                }
            };

            SetBinding(IsProcessingProperty, isProcessingBinding);
        }

        private void collectResultsFromWorkers()
        {

            Logger.log("Collecting...");
            PredictionsResults.Clear();

            var beforeAttackPredictionsMap = m_regularPredictionsAsyncWrapper.Model.Predictions;
            var afterAttackPredictionsMap = m_postAttackPredictionsAsyncWrapper.Model.Predictions;

            foreach (var itemPredictionPair in beforeAttackPredictionsMap)
            {
                var item = itemPredictionPair.Key as Item;
                var originalPrediction = itemPredictionPair.Value;
                var finalPrediction = afterAttackPredictionsMap.ContainsKey(item)   ? afterAttackPredictionsMap[item]
                                                                                    : 0.0f ;
                PredictionsResults.Add(new PredictionResultContainer(item, originalPrediction, finalPrediction, item.IsPromoted));
            } 
        }

        public override void activate(BasePageChangeParameters p)
        {
            if (p is FromSelectItemsPageChangeParameters)
            {
                var parameters = p as FromSelectItemsPageChangeParameters;
                
                var selectedRegularItems = parameters.SelectedItems;
                var selectedPromotedItems = parameters.SelectedPromotedItems;
                var allSelectedItems = selectedRegularItems.Concat(selectedPromotedItems).ToList();

                var regularPredictionsModel = new UserCentricModel(parameters.SelectedUser, RatingsLookupTable.Instance.getUsers(), allSelectedItems); 
                var postAttackPredictionsModel = new UserCentricModel(  parameters.SelectedUser, 
                                                                        RatingsLookupTable.Instance.getUsers(), 
                                                                        RatingsLookupTable.Instance.FakeProfilesTable.getUsers(),
                                                                        allSelectedItems); 
                
                //if (parameters.getPreviousPageValidationGuid() != PageValidationGuid)
                //{
                    PageValidationGuid = parameters.getPreviousPageValidationGuid();

                    m_regularPredictionsAsyncWrapper.getPredictionsAsync(regularPredictionsModel);
                    Thread.Sleep(1);
                    m_postAttackPredictionsAsyncWrapper.getPredictionsAsync(postAttackPredictionsModel);
                //}
            }
        }
    }
}
