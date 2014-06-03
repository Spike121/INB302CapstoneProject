using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Database;

namespace RecommenderAttacksAnalytics.Output {
    class SaveToDB {
        public static void SaveToDatabase() {
            NHibernateUtil.SaveTextfileToDatabase();
        }
    }
}
