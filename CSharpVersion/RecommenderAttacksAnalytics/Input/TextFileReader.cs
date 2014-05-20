using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows;

namespace RecommenderAttacksAnalytics.Input
{
    class TextFileReader 
    {
        private const int NUM_LINE_ARGS = 4;

        public delegate void LogStateHandler(TextFileReaderState state);
        public delegate void ReportProgressHandler(int percentage);

        public event LogStateHandler LogStateEvent;
        public event ReportProgressHandler ReportProgressEvent;

        private BackgroundWorker m_fileReaderWorker;
        private long m_numberOfUserItemPairs;

        private void LogState(TextFileReaderState.ReaderState state, string message)
        {
            if (LogStateEvent != null)
                LogStateEvent(new TextFileReaderState(state, message));
        }

        public bool readFromFile(string filePath)
        {
            RatingsLookupTable.Instance.clearAllData();

            StreamReader sr;
            string msg;

            LogState(TextFileReaderState.ReaderState.PROCESSING, "Opening file...");

            try
            {
                sr = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                msg = "Could not find the file with the provided path.";
                Logger.logError(msg);
                LogState(TextFileReaderState.ReaderState.STOPPED_ERROR, msg);

                return false;
            }
            catch (Exception e)
            {
                msg = String.Format("Cannot open the file: {0}", e.Message);
                Logger.logError(msg);
                LogState(TextFileReaderState.ReaderState.STOPPED_ERROR, msg);

                return false;
            }

            m_numberOfUserItemPairs = getLineCount(filePath);            
 
            LogState(TextFileReaderState.ReaderState.PROCESSING, "File opened");
            LogState(TextFileReaderState.ReaderState.PROCESSING, "Reading file...");

            m_fileReaderWorker = new BackgroundWorker();
            m_fileReaderWorker.DoWork += new DoWorkEventHandler(fileReaderWorker_DoWork);
            m_fileReaderWorker.WorkerReportsProgress = true;
            m_fileReaderWorker.ProgressChanged += new ProgressChangedEventHandler(fileReaderWorker_ProgressChanged);
            m_fileReaderWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(fileReaderWorker_RunWorkerCompleted);
            m_fileReaderWorker.RunWorkerAsync(sr);
           
            
            return true;
        }

        private long getLineCount(string path)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                    count++;
            }

            return count;
        }

        private void fileReaderWorker_DoWork(object sender, DoWorkEventArgs args)
        {
            var sr = args.Argument as StreamReader;
            string currentLine;
            long entriesProcessed = 0;
            long catchUpValue = m_numberOfUserItemPairs / 1000;

            while ((currentLine = sr.ReadLine()) != null)
            {
                var lineArgs = currentLine.Split(' ');
                
                entriesProcessed++;
                var completionPercentage = (int)( (float)entriesProcessed / m_numberOfUserItemPairs * 100);

                TableEntry currentEntry = null;

                if (isLineValid(lineArgs))
                {
                    currentEntry = addEntryToTable(lineArgs);          
                }

                m_fileReaderWorker.ReportProgress(completionPercentage, currentEntry);

                if (catchUpValue == 0 || entriesProcessed == 1 || (entriesProcessed % catchUpValue) == 0 || completionPercentage == 100)
                {
                    System.Threading.Thread.Sleep(1);                     
                }
            }
        }

        private TableEntry addEntryToTable(string[] args)
        {
            var entry = new TableEntry(args);
            RatingsLookupTable.Instance.addEntry(entry);
             
            return entry;
        }

        private void fileReaderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            LogState(TextFileReaderState.ReaderState.DONE_AND_VALID, "Done !" + Environment.NewLine);
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
            long n;
            
            for (int i = 0; i < NUM_LINE_ARGS; i++ )
            {
                isValid &= Int64.TryParse(args[i], out n);
            }
            
            return isValid;
        }

        public class TextFileReaderState
        {
            public enum ReaderState {STOPPED, STOPPED_ERROR, PROCESSING, DONE_AND_VALID};
            public string Message { get; set; }
            public ReaderState State;

            public bool IsProcessing
            {
                get { return State == ReaderState.PROCESSING; }
            }

            public bool HasValidData
            {
                get { return State == ReaderState.DONE_AND_VALID;  }
            }

            public TextFileReaderState(ReaderState state, string message)
            {
                State = state;
                Message = message;
            }
        }

    }
}
