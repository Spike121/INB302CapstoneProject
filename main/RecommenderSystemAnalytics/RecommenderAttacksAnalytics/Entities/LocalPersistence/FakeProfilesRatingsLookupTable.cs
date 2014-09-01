using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class FakeProfilesRatingsLookupTable : RatingsLookupTable
    {
        private List<Item> promotedItems = new List<Item>();

        public List<Item> getPromotedItems()
        {
            return promotedItems;
        }

        public void addPromotedItem(Item promotedItem)
        {
            promotedItem.IsPromoted = true;
            promotedItems.Add(promotedItem);
        }

        public override UserItemPair addEntry(TableEntry entry)
        {
            return addEntry(entry.UserId, entry.ItemId, entry.Rating);
        }

        
    }
}
