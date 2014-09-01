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

        public void fetchAllData(DatabaseInfos databaseInfos)
        {


            //Fetch list -> This takes forever, needs a background worker
            setUpBackgroundWorker();
            //m_inputOutputWorker.RunWorkerAsync(databaseInfos);
            loadUserItemRatingsFromDb(databaseInfos);
        }

        protected override void InputOutputWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var sessionManager = e.Argument as DatabaseInfos;
            loadUserItemRatingsFromDb(sessionManager);
        }

        protected override void InputOutputWorkerProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
           
        }

        protected override void InputOutputWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
           
        }

        public void saveUserItemRatingsToDb()
        {
            
        }

        public void loadUserItemRatingsFromDb(DatabaseInfos infos)
        {
            IsDataValid = false;

            IList<DBUserItemRating> ratingList = null;
            var sessionManager = new DatabaseSessionManager(infos);
            
            ratingList = fetchUserItemRatingsList(sessionManager);
            
           
          
            //Input into RatingsLookupTable
            long entriesProcessed = 0;
            entriesProcessed++;
            var completionPercentage = (int)( (float)entriesProcessed / ratingList.Count() * 100);
            long catchUpValue = ratingList.Count() / 1000;

            foreach(var userItemRating in ratingList)
                RatingsLookupTable.Instance.addEntry(new TableEntry(userItemRating));
            
            if (catchUpValue == 0 || entriesProcessed == 1 || (entriesProcessed % catchUpValue) == 0 || completionPercentage == 100)
            {
                System.Threading.Thread.Sleep(1);                     
            }

            IsDataValid = true;
        }

        private IList<DBUserItemRating> fetchUserItemRatingsList(DatabaseSessionManager sessionManager)
        {
            using (var session = sessionManager.setUpSession())
            {
                using (session.BeginTransaction())
                {
                    var query = String.Format("SELECT * FROM {0}", "ratings");
                    var ratingList = session.CreateSQLQuery(query).AddEntity(typeof(DBUserItemRating)).List<DBUserItemRating>();

                    return ratingList;
                }
            }
        }
    }
}
