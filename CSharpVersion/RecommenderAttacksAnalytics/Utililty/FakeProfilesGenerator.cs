using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;

namespace RecommenderAttacksAnalytics.Utililty {
    
    
    public class FakeProfilesGenerator {
        
        private const int MAX_RATING = 5;
        private const int MIN_RATING = 1;

        public void generateFakeProfiles(int numOfFakeProfilesToCreate, List<Item> promotedItems, bool isUserRatingFillingRandom) {
            
            if(promotedItems.Count == 0)
                return;

            foreach (var promotedItem in promotedItems)
                RatingsLookupTable.Instance.FakeProfilesTable.addPromotedItem(promotedItem);   
            

            var allItems = RatingsLookupTable.Instance.getItems();
            var unPromotedItemsSubset = allItems.Where(x => !promotedItems.Contains(x)).ToList();

            for(var i = 0; i < numOfFakeProfilesToCreate; i++)
            {
                var randomUserID = generatedUnusedUserId();

                UserItemPair userItemPair = null;
                foreach (var promotedItem in promotedItems)
                    userItemPair = RatingsLookupTable.Instance.addFakeProfileEntry(new TableEntry(randomUserID, promotedItem.getId(), MAX_RATING));
                

                if (userItemPair == null) 
                    continue;
                
                var tempUser = userItemPair.User;
                var fillerTableEntries = isUserRatingFillingRandom  ? getRandomRatingFillingsForUser(tempUser, unPromotedItemsSubset) 
                                                                    : getTargetedRatingFillingsForUser(tempUser, unPromotedItemsSubset);
                
                foreach (var fillerTableEntry in fillerTableEntries)
                    RatingsLookupTable.Instance.addFakeProfileEntry(fillerTableEntry);

            }          
        }


        private long generatedUnusedUserId()
        {
            var random = new Random();
            long randomUserID = random.Next(0, int.MaxValue);

            while (RatingsLookupTable.Instance.FakeProfilesTable.hasUser(randomUserID))
                randomUserID = random.Next(0, int.MaxValue);

            return randomUserID;
        }

        private List<TableEntry> getTargetedRatingFillingsForUser(User fakeProfileUser, List<Item> unPromotedItems )
        {
            return new List<TableEntry>();
        }

        private List<TableEntry> getRandomRatingFillingsForUser(User fakeProfileUser, List<Item> unPromotedItems)
        {
            var range = unPromotedItems.Count;
            var minNbOfItemsToRate = (range / 10) != 0 ? (range / 10) : 1;
            var nbOfItemsToRate = Util.getRandomIntegerInRange(minNbOfItemsToRate, range);
            var ratedItems = unPromotedItems.OrderBy(x => new Random().Next()).Take(nbOfItemsToRate);

            return ratedItems.Select(ratedItem => new TableEntry
                (
                    fakeProfileUser.getId(), 
                    ratedItem.getId(), 
                    Util.getRandomIntegerInRange(MIN_RATING, MAX_RATING)
                )).ToList();
        }
    }
}
