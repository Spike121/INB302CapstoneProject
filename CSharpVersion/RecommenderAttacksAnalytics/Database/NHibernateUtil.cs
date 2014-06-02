using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.Database;
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

<<<<<<< HEAD
        public static void SaveTextfileToDatabase() {

        }
=======
>>>>>>> 4e15afde64938dcbfdfb1b853566dc3e24ca721e

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
