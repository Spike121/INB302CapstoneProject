using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class User : AbstractUser
    {
        private List<Item> m_ratedItems = new List<Item>();

        public User(long userId)
        {
            this.m_userId = userId;
        }

        public void addRatedItem(Item item)
        {
            if (!m_ratedItems.Contains(item))
                m_ratedItems.Add(item);
        }

        public double getRatingAverageForUser()
        { 
            double avg = 0.0f;
            foreach (var item in m_ratedItems)
                avg += getRatingForItem(item);

            return avg / m_ratedItems.Count;
        }

        public bool hasRatingForItem(Item item)
        {
            return RatingsLookupTable.Instance.hasEntry(this, item);
        }

        public int getRatingForItem(Item item)
        {
            return RatingsLookupTable.Instance.getRatingForEntry(this, item);
        }

        public Dictionary<Item, int> getAllItemRatings()
        {
            return RatingsLookupTable.Instance.getAllItemRatingsForUser(this);
        }

        // Gives out a map containing the items that intersect with another user's rated items
        // Contains the value each matched item's rating as per the current user
        public Dictionary<Item, int> findItemsInCommonWithNeighbor(User neighbor)
        {
            var currentUserRatedItems = this.getAllItemRatings();
            var neighborsRatedItems = neighbor.getAllItemRatings();

            return currentUserRatedItems.Where(x => neighborsRatedItems.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
        }

        public override double diffFromAverageSquared(double average)
        {
            throw new NotImplementedException();
        }

        public override double diffFromAverage(double average)
        {
            double result = 0.0f;

            foreach(var itemScorePair in getAllItemRatings())
                result += itemScorePair.Value - average;

            return result;
        }

       
    }
}
