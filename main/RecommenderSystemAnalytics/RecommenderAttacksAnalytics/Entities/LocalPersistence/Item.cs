using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class Item : AbstractItem, ILocalPersistenceEntity
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private List<User> m_raters = new List<User>();

        public Item(long itemId)
        {
            m_itemId = itemId;
        }

        public bool IsPromoted { get; set; }    



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

        public double diffFromAverageSquared(double average)
        {
            throw new NotImplementedException();
        }

        public double diffFromAverage(double average)
        {
            throw new NotImplementedException();
        }

        public double doDiffFromAverage(double average, bool isSquared)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("Item #{0}", getId());
        }

        
    }
}
