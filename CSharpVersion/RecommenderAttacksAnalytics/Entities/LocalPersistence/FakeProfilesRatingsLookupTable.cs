using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class FakeProfilesRatingsLookupTable : RatingsLookupTable
    {
        private List<Item> promotedItems;
        
        public override UserItemPair addEntry(long userId, long itemId, int rating)
        {
            var userItemPair  = base.addEntry(userId,itemId,rating);
            promotedItems.Add(userItemPair.Item);
            return userItemPair;
        }
    }
}
