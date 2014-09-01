using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using RecommenderAttacksAnalytics.Entities.Database;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utililty;

namespace RecommenderAttacksAnalytics.Database
{
    public class NHibernateUtil
    {

        public static void SaveTextfileToDatabase() {

            //var defaultConfig = new DatabaseInfos();

            //NHibernateConnect(defaultConfig);

            //if(ConnectionSetup) {

            //    //Clear table
            //    var clearTable = String.Format("TRUNCATE {0}", "ratings");
            //    session.CreateSQLQuery(clearTable).ExecuteUpdate();
            //    tx.Commit();

            //    //Fetch rating list
            //    var ratingList = RatingsLookupTable.Instance;
            //    IEnumerable<User> userList;
            //    try {
            //        userList = ratingList.getUsers();
            //    } catch (Exception) {
            //        throw new Exception("You have not imported data yet.");
            //    }
            //    string query = "INSERT INTO ratings (userId, itemId, rating) VALUES ";
            //    int counter = 0;
            //    foreach (User user in userList) {
            //        foreach(KeyValuePair<Item, int> itemRatingsForUser in ratingList.getAllItemRatingsForUser(user)) {
            //            //Append each user item rating
            //            query += "("+user.getId()+", "+itemRatingsForUser.Key.getId()+", "+itemRatingsForUser.Value+"),";  
            //            counter++;
            //            if(counter == 1000) {
            //                query = query.Remove(query.Length - 1);
            //                query += ";";
            //                //Execute query
            //                session.CreateSQLQuery(query).ExecuteUpdate();
            //                //Reset query to blank
            //                query = "INSERT INTO ratings (userId, itemId, rating) VALUES ";
            //                //Reset counter
            //                counter = 0;
            //            }
            //        }
            //    }
            //    query = query.Remove(query.Length - 1);
            //    query += ";"; 
            //    //Catch in case there's exactly multiples of 1000 records. 
            //    if(counter != 0) {
            //        session.CreateSQLQuery(query).ExecuteUpdate();
            //    }
            //} else {
            //    throw new Exception("Connection has not been set.");
            //}
        }

    }
}
