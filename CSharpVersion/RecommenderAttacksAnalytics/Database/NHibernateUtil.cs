using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace RecommenderAttacksAnalytics.Database
{
    public class NHibernateUtil
    {
        public NHibernateUtil()
        {
            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            using(var session = sessionFactory.OpenSession())
            {
                
            }
        }

    }
}
