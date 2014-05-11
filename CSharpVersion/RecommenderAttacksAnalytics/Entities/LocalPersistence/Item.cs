using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class Item : AbstractItem
    {
        private List<User> m_raters = new List<User>();

        public Item(long itemId)
        {
            this.m_itemId = itemId;
        }

        public void addRater(User user)
        {
            if (!m_raters.Contains(user))
                m_raters.Add(user);
        }

        public bool hasRatingFromUser(User user)
        {
            return RatingsLookupTable.Instance.hasEntry(user, this);
        }

        public int getRatingFromUser(User user)
        {
            return RatingsLookupTable.Instance.getRatingForEntry(user, this);
        }

        public override double diffFromAverageSquared(double average)
        {
            throw new NotImplementedException();
        }

        public override double diffFromAverage(double average)
        {
            throw new NotImplementedException();
        }
    }
}
