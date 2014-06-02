using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;

namespace RecommenderAttacksAnalytics.InputOutput
{
    public class TextFileDataIO : AbstractDataIO
    {
        private const int NUM_LINE_ARGS = 4;

        public delegate void LogStateHandler(TextFileReaderState state);
        public delegate void ReportProgressHandler(int percentage);

        public event LogStateHandler ReaderStateChangeEvent;
        public event ReportProgressHandler ReportProgressEvent;
        
        private TextFileReaderState m_readerState = new TextFileReaderState();

        private void ChangeState(TextFileReaderState.ReaderState state, string message)
        {
            m_readerState = new TextFileReaderState(state, message);
            IsProcessing = m_readerState.IsProcessing;
            IsDataValid = m_readerState.HasValidData;

            if (ReaderStateChangeEvent != null)
                ReaderStateChangeEvent(m_readerState);
        }

        public TextFileDataIO(bool isForFakeProfiles)
        {
            m_isForFakeProfiles = isForFakeProfiles;
        }

        public bool readFromFile(string filePath)
        {
            
            IsDataValid = false;

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

            setUpBackgroundWorker();
            m_inputOutputWorker.RunWorkerAsync(sr);
           
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

        protected override void InputOutputWorkerDoWork(object sender, DoWorkEventArgs args)
        {
            var sr = args.Argument as StreamReader;
            string currentLine;
            m_entriesProcessed = 0;
            long catchUpValue = m_numberOfUserItemPairs / 100;

            while (sr != null && (currentLine = sr.ReadLine()) != null)
            {
                var lineArgs = currentLine.Split(' ');

                m_entriesProcessed++;
                var completionPercentage = getCompletionPercentage();

                TableEntry currentEntry = null;

                if (isLineValid(lineArgs))
                {
                    //Dispatcher.Invoke(new Action(() => currentEntry = addEntryToTable(lineArgs)));
                    currentEntry = addEntryToTable(lineArgs);          
                }

                m_inputOutputWorker.ReportProgress(completionPercentage, currentEntry);

                if (catchUpValue == 0 || m_entriesProcessed == 1 || (m_entriesProcessed % catchUpValue) == 0 || completionPercentage == 100)
                {
                    System.Threading.Thread.Sleep(1);                     
                }
            }
        }

        protected override void InputOutputWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            ChangeState(TextFileReaderState.ReaderState.DONE_AND_VALID, "Done !" + Environment.NewLine);
        }

        protected override void InputOutputWorkerProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            if (ReportProgressEvent != null)
                ReportProgressEvent(args.ProgressPercentage);
            
            var newEntry = args.UserState as TableEntry;

            //if (newEntry != null)
            //Logger.log(String.Format("New entry added: {0}", newEntry.ToString()));
        }

        private TableEntry addEntryToTable(string[] args)
        {
            var entry = new TableEntry(args);
            
            if(m_isForFakeProfiles)
                RatingsLookupTable.Instance.addFakeProfileEntry(entry);
            else
                RatingsLookupTable.Instance.addEntry(entry);
             
            return entry;
        }

        private bool isLineValid(string[] args)
        {
            if (args.Length != NUM_LINE_ARGS || args[0].Equals("&"))
                return false;

            var isValid = true;

            // TODO: Switch to regex
            for (var i = 0; i < NUM_LINE_ARGS; i++ )
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
