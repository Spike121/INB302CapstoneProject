using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using RecommenderAttacksAnalytics.Utililty;

namespace RecommenderAttacksAnalytics.Database
{
    public class DatabaseSessionManager
    {
        private readonly DatabaseInfos m_currentDatabaseConnectionInfos;
        
        private ISessionFactory m_sessionFactory;
        private ISessionFactory SessionFactory
        {
            get
            {
                if (m_sessionFactory == null)
                {
                    var config = new Configuration();

                    config.Properties.Add(NHibernate.Cfg.Environment.ConnectionProvider, typeof(NHibernate.Connection.DriverConnectionProvider).AssemblyQualifiedName);
                    config.Properties.Add(NHibernate.Cfg.Environment.Dialect, typeof(NHibernate.Dialect.MySQLDialect).AssemblyQualifiedName);
                    config.Properties.Add(NHibernate.Cfg.Environment.ConnectionDriver, typeof(NHibernate.Driver.MySqlDataDriver).AssemblyQualifiedName);
                    config.Properties.Add(NHibernate.Cfg.Environment.ConnectionString, m_currentDatabaseConnectionInfos.getConnectionString());

                    var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                    config.AddAssembly(currentAssembly);
                    m_sessionFactory = config.BuildSessionFactory();
                }

                return m_sessionFactory;
            }
        }

        public DatabaseSessionManager(DatabaseInfos dbInfos)
        {
            m_currentDatabaseConnectionInfos = dbInfos;
        }

        public ISession setUpSession()
        {
            return SessionFactory.OpenSession();
        }



    }
}
