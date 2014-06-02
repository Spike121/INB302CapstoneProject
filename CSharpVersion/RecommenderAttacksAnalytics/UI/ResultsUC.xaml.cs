using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Models;
using RecommenderAttacksAnalytics.UI.Containers;
using RecommenderAttacksAnalytics.UI.PageChangeParameters;

namespace RecommenderAttacksAnalytics.UI
{
    /// <summary>
    /// Interaction logic for ResultsUC.xaml
    /// </summary>
    public partial class ResultsUC : AbstractAppPageUC
    {

        private AbstractModel m_model;
        private AbstractModel m_promotedItemsModel;
        private readonly BackgroundWorker m_modelComputationsWorker = new BackgroundWorker();
        private readonly BackgroundWorker m_promotedItemsModelComputationsWorker = new BackgroundWorker();

        public bool IsWorkerRunning
        {
            get { return (bool)GetValue(IsWorkerRunningProperty); }
            private set { SetValue(IsWorkerRunningProperty, value); }
        }

        public static readonly DependencyProperty IsWorkerRunningProperty =
            DependencyProperty.Register("IsWorkerRunning", typeof(bool), typeof(ResultsUC), new UIPropertyMetadata(false));

        
        public ObservableCollection<PredictionResultContainer> PredictionsResults   {
            get { return (ObservableCollection<PredictionResultContainer>)GetValue(PredictionsResultsProperty); }
            set { SetValue(PredictionsResultsProperty, value); }
        }

        public static readonly DependencyProperty PredictionsResultsProperty =
            DependencyProperty.Register("PredictionsResults", typeof(ObservableCollection<PredictionResultContainer>), typeof(ResultsUC), new UIPropertyMetadata(new ObservableCollection<PredictionResultContainer>()));

        public ResultsUC()
            :base(MainWindow.AppPage.RESULTS_PAGE)
        {
            IsWorkerRunning = false;
            InitializeComponent();
                       
            setUpWorker(m_modelComputationsWorker);
            setUpWorker(m_promotedItemsModelComputationsWorker);
        }

        private void setUpWorker(BackgroundWorker worker)
        {
            worker.DoWork += modelComputationsWorker_DoWork;
            worker.ProgressChanged += modelComputationsWorker_ProgressChanged;
            worker.RunWorkerCompleted += modelComputationsWorker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
        }

        private void modelComputationsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsWorkerRunning = false;
            PredictionsResults.Clear();
            foreach (var prediction in m_model.Predictions)
            {
                PredictionsResults.Add(new PredictionResultContainer(prediction.Key, prediction.Value));
            }
        }

        private void modelComputationsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void modelComputationsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            m_model.computePredictions();
        }

        public override void activate(IPageChangeParameters p)
        {
            IsWorkerRunning = false;

            if (p is FromSelectItemsPageChangeParameters)
            {
                var parameters = p as FromSelectItemsPageChangeParameters;
                
                var selectedRegularItems = parameters.SelectedItems;
                var selectedPromotedItems = parameters.SelectedPromotedItems;

                m_model = new UserCentricModel(parameters.SelectedUser, RatingsLookupTable.Instance.getUsers(), selectedRegularItems);
                m_promotedItemsModel = new UserCentricModel(parameters.SelectedUser, RatingsLookupTable.Instance.getUsers(), RatingsLookupTable.Instance.FakeProfilesTable.getUsers(), selectedRegularItems, selectedPromotedItems);

                if (parameters.getPreviousPageValidationGuid() != PageValidationGuid)
                {
                    PageValidationGuid = parameters.getPreviousPageValidationGuid();
                    IsWorkerRunning = true;
                    m_modelComputationsWorker.RunWorkerAsync();
                }
            }
        }
    }
}
