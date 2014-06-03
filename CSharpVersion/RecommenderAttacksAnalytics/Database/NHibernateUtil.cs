using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.Database;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utililty;

namespace RecommenderAttacksAnalytics.Database
{
    public class NHibernateUtil
    {
        private static readonly Configuration Config = new Configuration();
        private static bool ConnectionSetup = false;
        private static DatabaseInfos m_databaseInfos;

        public static void NHibernateConnect(DatabaseInfos databaseInfos)
        {
            m_databaseInfos = databaseInfos;
            Config.Properties.Add(NHibernate.Cfg.Environment.ConnectionProvider, typeof(NHibernate.Connection.DriverConnectionProvider).AssemblyQualifiedName);
            Config.Properties.Add(NHibernate.Cfg.Environment.Dialect, typeof(NHibernate.Dialect.MySQLDialect).AssemblyQualifiedName);
            Config.Properties.Add(NHibernate.Cfg.Environment.ConnectionDriver, typeof(NHibernate.Driver.MySqlDataDriver).AssemblyQualifiedName);
            Config.Properties.Add(NHibernate.Cfg.Environment.ConnectionString, m_databaseInfos.getConnectionString());
            
            Config.AddAssembly("RecommenderAttacksAnalytics");
            ConnectionSetup = true;
        }

        public static void SaveTextfileToDatabase() {
            DatabaseInfos defaultConfig = new DatabaseInfos();
            defaultConfig.HostName = "localhost";
            defaultConfig.Username = "root";
            defaultConfig.Password = "CodeTrix";
            defaultConfig.Port = 3306;
            defaultConfig.Schema = "useritemratings";
            NHibernateConnect(defaultConfig);

            if(ConnectionSetup) {
                //Connect, begin transaction
                var sessionFactory = Config.BuildSessionFactory();
                var session = sessionFactory.OpenSession();
                var tx = session.BeginTransaction();

                //Clear table
                var clearTable = String.Format("TRUNCATE {0}", "ratings");
                session.CreateSQLQuery(clearTable).ExecuteUpdate();
                tx.Commit();
                //Fetch rating list
                var ratingList = RatingsLookupTable.Instance;
                IEnumerable<User> userList;
                try {
                    userList = ratingList.getUsers();
                } catch (Exception) {
                    throw new Exception("You have not imported data yet.");
                }
                string query = "INSERT INTO ratings (userId, itemId, rating) VALUES ";
                int counter = 0;
                foreach (User user in userList) {
                    foreach(KeyValuePair<Item, int> itemRatingsForUser in ratingList.getAllItemRatingsForUser(user)) {
                        //Append each user item rating
                        query += "("+user.getId()+", "+itemRatingsForUser.Key.getId()+", "+itemRatingsForUser.Value+"),";  
                        counter++;
                        if(counter == 1000) {
                            query = query.Remove(query.Length - 1);
                            query += ";";
                            //Execute query
                            session.CreateSQLQuery(query).ExecuteUpdate();
                            //Reset query to blank
                            query = "INSERT INTO ratings (userId, itemId, rating) VALUES ";
                            //Reset counter
                            counter = 0;
                        }
                    }
                }
                query = query.Remove(query.Length - 1);
                query += ";"; 
                //Catch in case there's exactly multiples of 1000 records. 
                if(counter != 0) {
                    session.CreateSQLQuery(query).ExecuteUpdate();
                }
            } else {
                throw new Exception("Connection has not been set.");
            }
        }

        public static IList<DBUserItemRating> FetchRatingsList()
        {
            // ensure NHibernateConnect has been run
            if(ConnectionSetup) {

                var sessionFactory = Config.BuildSessionFactory();
                var session = sessionFactory.OpenSession();
                var tx = session.BeginTransaction();
                
                var query = String.Format("SELECT * FROM {0}", "ratings");   
                var ratingList = session.CreateSQLQuery(query).AddEntity(typeof(DBUserItemRating)).List<DBUserItemRating>();
               
                return ratingList;
            }

            throw new Exception("Connection has not been set.");
        }

        public static void Disconnect()
        {

        }
    }
}
