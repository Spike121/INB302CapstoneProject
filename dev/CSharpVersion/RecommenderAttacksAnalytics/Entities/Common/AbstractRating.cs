using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.Common {
    public abstract class AbstractRating
    {
        protected long m_userId;
        protected long m_itemId;
        protected long m_rating;

        public virtual long getUserId()
        {
            return m_userId;
        }

        public virtual long getItemId() 
        {
            return m_itemId;
        }

        public virtual long getRating()
        {
            return m_rating;
        }

        public override int GetHashCode()
        {
            return getUserId().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(getUserId() == (obj as AbstractRating).getUserId() && getItemId() == (obj as AbstractRating).getItemId() && getRating() == (obj as AbstractRating).getRating()) {
                return true;
            } else {
                return false;
            }
        }
    }
}
