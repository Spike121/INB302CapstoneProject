using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.Entities.Database
{
    public class DBUserItemRating : AbstractRating 
    {
        public virtual long itemId
        {
            get { return this.getItemId(); }
            set { setItemId(value);  }
        }

        public virtual void setItemId(long id)
        {
            this.m_itemId = id;
        }

        public virtual long userId
        {
            get { return this.getUserId(); }
            set { setUserId(value);  }
        }

        public virtual void setUserId(long id)
        {
            this.m_userId = id;
        }

        public virtual long rating
        {
            get { return this.getRating(); }
            set { setRating(value);  }
        }

        public virtual void setRating(long value)
        {
            this.m_rating = value;
        }
    }
}
