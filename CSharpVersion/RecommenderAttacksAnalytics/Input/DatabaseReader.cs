using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Database;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;
using RecommenderAttacksAnalytics.Entities.Database;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows;

namespace RecommenderAttacksAnalytics.Input {
    public class DatabaseReader {
        private static IList<DBUserItemRating> ratingList;
        public static void FetchEntities(string hostname, string username, string password, int port, string schema) {
            NHibernateUtil.NHibernateConnect(hostname, username, password, port, schema);
            ratingList = NHibernateUtil.FetchRatingsList();

            //Input into RatingsLookupTable -> see TextFileReader.cs for how this is done
        }

        public static void processInformation() {
            long entriesProcessed = 0;
            entriesProcessed++;
            var completionPercentage = (int)( (float)entriesProcessed / ratingList.Count() * 100);
            long catchUpValue = ratingList.Count() / 1000;

            TableEntry currentEntry = null;
            foreach(AbstractRating rating in ratingList) {
                string[] entry = new string[] { Convert.ToString(rating.getUserId()), Convert.ToString(rating.getItemId()), Convert.ToString(rating.getRating()) };
                currentEntry = addEntryToTable(entry);
            }       
            
            //Not sure how to change the progress bar
            if (catchUpValue == 0 || entriesProcessed == 1 || (entriesProcessed % catchUpValue) == 0 || completionPercentage == 100)
            {
                System.Threading.Thread.Sleep(1);                     
            }
        }

        private static TableEntry addEntryToTable(string[] args)
        {
            var entry = new TableEntry(args);
            RatingsLookupTable.Instance.addEntry(entry);
             
            return entry;
        }
        
        
    }
}
