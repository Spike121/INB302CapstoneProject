using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.Entities.Database
{
    public class DBItem : AbstractItem, IDatabasePersistenceEntity  
    {
        private ICollection<DBUserItemRating> m_userItemRatings;
        public virtual ICollection<DBUserItemRating> UserItemRatings
        {
            get { return m_userItemRatings; }
        }

        public virtual long ItemId
        {
            get { return this.getId(); }
            set { setId(value);  }
        }

        public void setId(long id)
        {
            this.m_itemId = id;
        }

    }
}
