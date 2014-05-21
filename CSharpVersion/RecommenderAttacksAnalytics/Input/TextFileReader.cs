using System;
using System.IO;
using NHibernate.Linq.Functions;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;
using System.ComponentModel;
using System.Windows;

namespace RecommenderAttacksAnalytics.Input
{
    public class TextFileReader : DependencyObject
    {
        private const int NUM_LINE_ARGS = 4;

        public delegate void LogStateHandler(TextFileReaderState state);
        public delegate void ReportProgressHandler(int percentage);

        public event LogStateHandler ReaderStateChangeEvent;
        public event ReportProgressHandler ReportProgressEvent;
        
        private readonly bool m_isReaderForFakeProfiles;
        private long m_entriesProcessed = 0;
        private BackgroundWorker m_fileReaderWorker;
        private long m_numberOfUserItemPairs;
        private TextFileReaderState m_readerState = new TextFileReaderState();

        public bool IsReaderProcessing
        {
            get { return (bool)GetValue(IsReaderProcessingProperty); }
            set { SetValue(IsReaderProcessingProperty, value); }
        }

        public bool IsReaderDataValid
        {
            get { return (bool)GetValue(IsReaderDataValidProperty); }
            set { SetValue(IsReaderDataValidProperty, value); }
        }

        public static readonly DependencyProperty IsReaderDataValidProperty =
            DependencyProperty.Register("IsReaderDataValid", typeof(bool), typeof(TextFileReader), new UIPropertyMetadata(false));

        public static readonly DependencyProperty IsReaderProcessingProperty =
            DependencyProperty.Register("IsReaderProcessing", typeof(bool), typeof(TextFileReader), new UIPropertyMetadata(false));


        private void ChangeState(TextFileReaderState.ReaderState state, string message)
        {
            m_readerState = new TextFileReaderState(state, message);
            IsReaderProcessing = m_readerState.IsProcessing;
            IsReaderDataValid = m_readerState.HasValidData;

            if (ReaderStateChangeEvent != null)
                ReaderStateChangeEvent(m_readerState);
        }

        public TextFileReader(bool isReaderForFakeProfiles)
        {
            m_isReaderForFakeProfiles = isReaderForFakeProfiles;
        }

        public int getCompletionPercentage()
        {
            return m_numberOfUserItemPairs == 0 ? 100 : (int) ((float)m_entriesProcessed / m_numberOfUserItemPairs * 100);
        }

        public bool readFromFile(string filePath)
        {
            RatingsLookupTable.Instance.clearAllData();
            IsReaderDataValid = false;

            StreamReader sr;
            string msg;
            m_entriesProcessed = 0;

            try
            {
                var fileInfo = new FileInfo(filePath);
                ChangeState(TextFileReaderState.ReaderState.PROCESSING, String.Format("Opening file {0}...", fileInfo.Name));
                sr = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                msg = "Could not find the file with the provided path.";
                Logger.logError(msg);
                ChangeState(TextFileReaderState.ReaderState.STOPPED_ERROR, msg);

                return false;
            }
            catch (Exception e)
            {
                msg = String.Format("Cannot open the file: {0}", e.Message);
                Logger.logError(msg);
                ChangeState(TextFileReaderState.ReaderState.STOPPED_ERROR, msg);

                return false;
            }

            m_numberOfUserItemPairs = getLineCount(filePath);            
 
            ChangeState(TextFileReaderState.ReaderState.PROCESSING, "File opened");
            ChangeState(TextFileReaderState.ReaderState.PROCESSING, "Reading file...");

            m_fileReaderWorker = new BackgroundWorker();
            m_fileReaderWorker.DoWork += fileReaderWorker_DoWork;
            m_fileReaderWorker.WorkerReportsProgress = true;
            m_fileReaderWorker.ProgressChanged += fileReaderWorker_ProgressChanged;
            m_fileReaderWorker.RunWorkerCompleted += fileReaderWorker_RunWorkerCompleted;
            m_fileReaderWorker.RunWorkerAsync(sr);
           
            return true;
        }

        private long getLineCount(string path)
        {
            long count = 0;
            using (var r = new StreamReader(path))
            {
                while ((r.ReadLine()) != null)
                    count++;
            }

            return count;
        }

        private void fileReaderWorker_DoWork(object sender, DoWorkEventArgs args)
        {
            var sr = args.Argument as StreamReader;
            string currentLine;
            m_entriesProcessed = 0;
            long catchUpValue = m_numberOfUserItemPairs / 1000;

            while (sr != null && (currentLine = sr.ReadLine()) != null)
            {
                var lineArgs = currentLine.Split(' ');

                m_entriesProcessed++;
                var completionPercentage = getCompletionPercentage();

                TableEntry currentEntry = null;

                if (isLineValid(lineArgs))
                {
                    currentEntry = addEntryToTable(lineArgs);          
                }

                m_fileReaderWorker.ReportProgress(completionPercentage, currentEntry);

                if (catchUpValue == 0 || m_entriesProcessed == 1 || (m_entriesProcessed % catchUpValue) == 0 || completionPercentage == 100)
                {
                    System.Threading.Thread.Sleep(1);                     
                }
            }
        }

        private TableEntry addEntryToTable(string[] args)
        {
            var entry = new TableEntry(args);
            
            if(m_isReaderForFakeProfiles)
                RatingsLookupTable.Instance.addFakeProfileEntry(entry);
            else
                RatingsLookupTable.Instance.addEntry(entry);
             
            return entry;
        }

        private void fileReaderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            ChangeState(TextFileReaderState.ReaderState.DONE_AND_VALID, "Done !" + Environment.NewLine);
        }

        private void fileReaderWorker_ProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            if (ReportProgressEvent != null)
                ReportProgressEvent(args.ProgressPercentage);
            
            var newEntry = args.UserState as TableEntry;

            //if (newEntry != null)
                //Logger.log(String.Format("New entry added: {0}", newEntry.ToString()));
        }

        private bool isLineValid(string[] args)
        {
            if (args.Length != NUM_LINE_ARGS || args[0].Equals("&"))
                return false;

            bool isValid = true;

            for (int i = 0; i < NUM_LINE_ARGS; i++ )
            {
                long n;
                isValid &= Int64.TryParse(args[i], out n);
            }

            return isValid;
        }

        public class TextFileReaderState
        {
            public enum ReaderState {STOPPED, STOPPED_ERROR, PROCESSING, DONE_AND_VALID};

            private readonly ReaderState m_state;
            public ReaderState State {  get { return m_state; } }

            public string Message { get; set; }
            
            public bool IsProcessing
            {
                get { return State == ReaderState.PROCESSING; }
            }

            public bool HasValidData
            {
                get { return State == ReaderState.DONE_AND_VALID;  }
            }

            public TextFileReaderState()
            {
                m_state = ReaderState.STOPPED;

            }

            public TextFileReaderState(ReaderState state, string message)
            {
                Message = message;
                m_state = state;
            }
        }

    }
}
