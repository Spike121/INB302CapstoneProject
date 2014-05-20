using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using RecommenderAttacksAnalytics.Entities.Common;
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
        private readonly BackgroundWorker m_modelComputationsWorker = new BackgroundWorker();

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

            m_modelComputationsWorker.DoWork += (modelComputationsWorker_DoWork);
            m_modelComputationsWorker.ProgressChanged += modelComputationsWorker_ProgressChanged;
            m_modelComputationsWorker.RunWorkerCompleted += modelComputationsWorker_RunWorkerCompleted;
            m_modelComputationsWorker.WorkerReportsProgress = true;
            
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
                m_model = new UserCentricModel(parameters.SelectedUser.getId(), parameters.SelectedItems);
                
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
