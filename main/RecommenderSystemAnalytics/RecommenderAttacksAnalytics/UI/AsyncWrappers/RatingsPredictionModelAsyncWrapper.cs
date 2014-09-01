using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using RecommenderAttacksAnalytics.Models;
using RecommenderAttacksAnalytics.UI.Containers;

namespace RecommenderAttacksAnalytics.UI.AsyncWrappers
{
    public class RatingsPredictionModelAsyncWrapper : DependencyObject
    {
        public UserCentricModel Model { get; private set; }
        private  BackgroundWorker m_worker = new BackgroundWorker();

        public BackgroundWorker Worker
        {
            get { return m_worker; }
        }

        private string Name;
 
        public RatingsPredictionModelAsyncWrapper(string name)
        {
            Name = name;
        }

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        public static readonly DependencyProperty IsRunningProperty =
            DependencyProperty.Register("IsRunning", typeof(bool), typeof(RatingsPredictionModelAsyncWrapper), new UIPropertyMetadata(false));
        
        private void setUpWorker()
        {
            m_worker = new BackgroundWorker();
            m_worker.DoWork += m_worker_DoWork;
            m_worker.ProgressChanged += m_worker_ProgressChanged;
            m_worker.RunWorkerCompleted += m_worker_RunWorkerCompleted;
            m_worker.WorkerReportsProgress = true;
        }

        private void m_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsRunning = false;
        }

        private void m_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void m_worker_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                Model.computePredictions();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void getPredictionsAsync(UserCentricModel model)
        {
            setUpWorker();
            Model = model;
            IsRunning = true;
            m_worker.RunWorkerAsync();
        }
    }
}
