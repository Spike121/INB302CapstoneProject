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
    class TextFileReader : DependencyObject
    {
        private const int NUM_LINE_ARGS = 4;

        public delegate void LogMessageHandler(string message);
        public delegate void ReportProgressHandler(int percentage);

        public event LogMessageHandler LogMessage;
        public event ReportProgressHandler ReportProgress;

        private BackgroundWorker m_fileReaderWorker;
        private long m_numberOfUserItemPairs;



        public bool IsDataLoadedSuccessfully
        {
            get { return (bool)GetValue(IsDataLoadedSuccessfullyProperty); }
            set { SetValue(IsDataLoadedSuccessfullyProperty, value); }
        }

        public static readonly DependencyProperty IsDataLoadedSuccessfullyProperty =
            DependencyProperty.Register("IsDataLoadedSuccessfully", typeof(bool), typeof(TextFileReader), new UIPropertyMetadata(false));


        public TextFileReader() 
        {
        
        }

        public bool readFromFile(string filePath)
        {
            IsDataLoadedSuccessfully = false;
            RatingsLookupTable.Instance.clearAllData();

            StreamReader sr;
            string msg;

            LogMessage("Opening file...");

            try
            {
                sr = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                msg = "Could not find the file with the provided path";
                Logger.logError(msg);
                LogMessage(msg);

                return false;
            }
            catch (Exception e)
            {
                msg = String.Format("Error opening the file: {0}", e.Message);
                Logger.logError(msg);
                LogMessage(msg);

                return false;
            }

            m_numberOfUserItemPairs = getLineCount(filePath);            
 
            LogMessage("File opened");
            LogMessage("Reading file...");

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
                {
                    count++;
                }
            }

            return count;
        }

        private void fileReaderWorker_DoWork(object sender, DoWorkEventArgs args)
        {
            var sr = args.Argument as StreamReader;
            string currentLine;
            int entriesProcessed = 0;

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
            LogMessage("Done !" + Environment.NewLine);
            IsDataLoadedSuccessfully = true;
        }

        private void fileReaderWorker_ProgressChanged(object sender, ProgressChangedEventArgs args)
        {

            ReportProgress(args.ProgressPercentage);
            var newEntry = args.UserState as TableEntry;
            
            //if(newEntry != null)
                //LogMessage(String.Format("New entry added: {0}", newEntry.ToString()));

            
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

       
    }
}
