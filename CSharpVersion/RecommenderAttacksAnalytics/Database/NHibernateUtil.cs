using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.Database;

namespace RecommenderAttacksAnalytics.Database
{
    public class NHibernateUtil
    {
        private static Configuration Config = new NHibernate.Cfg.Configuration();
        private static bool ConnectionSetup = false;
        public static void NHibernateConnect(string hostname, string username, string password, int port, string schema) {
            Config.Properties.Add(NHibernate.Cfg.Environment.ConnectionProvider,typeof(NHibernate.Connection.DriverConnectionProvider).AssemblyQualifiedName);
            Config.Properties.Add(NHibernate.Cfg.Environment.Dialect,typeof(NHibernate.Dialect.MySQLDialect).AssemblyQualifiedName);
            Config.Properties.Add(NHibernate.Cfg.Environment.ConnectionDriver,typeof(NHibernate.Driver.MySqlDataDriver).AssemblyQualifiedName);
            string connection = "Server="+hostname+";Port="+port+";Database="+schema+";Uid="+username+";Pwd="+password;
            Config.Properties.Add(NHibernate.Cfg.Environment.ConnectionString, connection);
            Config.AddAssembly("RecommenderAttacksAnalytics");
            ConnectionSetup = true;
        }

        public static IList<DBUserItemRating> FetchRatingsList()
        {

            // ensure NHibernateConnect has been run
            if(ConnectionSetup) {

                ISessionFactory sessionFactory = Config.BuildSessionFactory();
                ISession session = sessionFactory.OpenSession();
                ITransaction tx = session.BeginTransaction();
            
                IList<DBUserItemRating> ratingList = session.CreateSQLQuery("SELECT * FROM ratings").AddEntity(typeof(DBUserItemRating)).List<DBUserItemRating>();

                return ratingList;
            } else {
                throw new Exception("Connection has not been set.");
            }
        }
    }
}
