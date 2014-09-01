using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace RecommenderAttacksAnalytics.InputOutput
{
    public abstract class AbstractDataIO : DependencyObject
    {
        protected bool m_isForFakeProfiles;
        protected long m_entriesProcessed = 0;
        protected BackgroundWorker m_inputOutputWorker;
        protected long m_numberOfUserItemPairs;


        public bool IsProcessing
        {
            get { return (bool)GetValue(IsProcessingProperty); }
            set { SetValue(IsProcessingProperty, value); }
        }

        public bool IsDataValid
        {
            get { return (bool)GetValue(IsDataValidProperty); }
            set { SetValue(IsDataValidProperty, value); }
        }

        public static readonly DependencyProperty IsDataValidProperty =
            DependencyProperty.Register("IsDataValid", typeof(bool), typeof(AbstractDataIO), new UIPropertyMetadata(false));

        public static readonly DependencyProperty IsProcessingProperty =
            DependencyProperty.Register("IsProcessing", typeof(bool), typeof(AbstractDataIO), new UIPropertyMetadata(false));

        public int getCompletionPercentage()
        {
            return m_numberOfUserItemPairs == 0 ? 100 : (int) ((float)m_entriesProcessed / m_numberOfUserItemPairs * 100);
        }

        protected void setUpBackgroundWorker()
        {
            m_inputOutputWorker = new BackgroundWorker();
            m_inputOutputWorker.DoWork += InputOutputWorkerDoWork;
            m_inputOutputWorker.WorkerReportsProgress = true;
            m_inputOutputWorker.ProgressChanged += InputOutputWorkerProgressChanged;
            m_inputOutputWorker.RunWorkerCompleted += InputOutputWorkerRunWorkerCompleted;
        }

        protected abstract void InputOutputWorkerDoWork(object sender, DoWorkEventArgs e);
        protected abstract void InputOutputWorkerProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs);
        protected abstract void InputOutputWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs);
    }
}
