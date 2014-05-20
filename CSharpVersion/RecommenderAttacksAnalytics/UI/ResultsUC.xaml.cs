using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Models;
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

            m_modelComputationsWorker.DoWork += (modelComputationsWorker_DoWork);
            m_modelComputationsWorker.ProgressChanged += modelComputationsWorker_ProgressChanged;
            m_modelComputationsWorker.RunWorkerCompleted += modelComputationsWorker_RunWorkerCompleted;
            m_modelComputationsWorker.WorkerReportsProgress = true;

        }

        private void modelComputationsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void modelComputationsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void modelComputationsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            m_model.computePredictions();
            PredictionsResults.Clear();

            foreach (var prediction in m_model.Predictions)
            {
                PredictionsResults.Add(new PredictionResultContainer(prediction.Key, prediction.Value));                           
            }


        }

        public override void activate(IPageChangeParameters p)
        {
            if (p is FromSelectItemsPageChangeParameters)
            {
                var parameters = p as FromSelectItemsPageChangeParameters;
                m_model = new UserCentricModel(parameters.SelectedUser.getId(), parameters.SelectedItems);
                
                if (parameters.getPreviousPageValidationGuid() != PageValidationGuid)
                {
                    PageValidationGuid = parameters.getPreviousPageValidationGuid();
                    m_modelComputationsWorker.RunWorkerAsync();
                }
            }
        }


        public class PredictionResultContainer
        {
            private AbstractPersistenceEntity m_entity;
            private double m_originalScore;
            public double OriginalScore {get { return m_originalScore; }}
            
            private double m_finalScore;

            public PredictionResultContainer(AbstractPersistenceEntity entity, double originalScore)
            {
                m_entity = entity;
                m_originalScore = originalScore;
            }

            public double FinalScore {get { return m_finalScore; }}
        }

    }
}
