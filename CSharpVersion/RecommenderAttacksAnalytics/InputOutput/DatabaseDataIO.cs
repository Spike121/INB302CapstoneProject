using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using RecommenderAttacksAnalytics.Database;
using RecommenderAttacksAnalytics.Entities.Database;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utililty;

namespace RecommenderAttacksAnalytics.InputOutput 
{
    public class DatabaseDataIO : AbstractDataIO
    {
        public void FetchEntities(DatabaseInfos databaseInfos)
        {
            //Connect
            NHibernateUtil.NHibernateConnect(databaseInfos);

            //Fetch list -> This takes forever, needs a background worker
            setUpBackgroundWorker();
            m_inputOutputWorker.RunWorkerAsync();
        }

        protected override void InputOutputWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            readFromDb();
            NHibernateUtil.Disconnect();
        }

        protected override void InputOutputWorkerProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
           
        }

        protected override void InputOutputWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
           
        }

        public void readFromDb()
        {

            IList<DBUserItemRating> ratingList;
            try
            {
                ratingList = NHibernateUtil.FetchRatingsList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            //Input into RatingsLookupTable
            long entriesProcessed = 0;
            entriesProcessed++;
            var completionPercentage = (int)( (float)entriesProcessed / ratingList.Count() * 100);
            long catchUpValue = ratingList.Count() / 1000;

            foreach(var userItemRating in ratingList) 
            {
                addEntryToTable(userItemRating);
            }       
            
            if (catchUpValue == 0 || entriesProcessed == 1 || (entriesProcessed % catchUpValue) == 0 || completionPercentage == 100)
            {
                System.Threading.Thread.Sleep(1);                     
            }
        }

        private TableEntry addEntryToTable(DBUserItemRating userItemRating)
        {
            var entry = new TableEntry(userItemRating);
            RatingsLookupTable.Instance.addEntry(entry);
             
            return entry;
        }
    }
}
