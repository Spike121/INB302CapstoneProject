using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.Utililty {
    class GenerateFakeProfiles {
        private static List<Item> itemsToPromote;
        public static void GenFakeProfiles(int numOfProfiles, int numOfItems) {
            itemsToPromote = new List<Item>(); //Currently a fake, empty list. Needs to be taken from the selected items
            for(int i = 0; i < numOfProfiles; i++) {
                Random random = new Random();
                long randomUserID = random.Next(0, int.MaxValue);
                //Makes sure the userID is not taken
                while(RatingsLookupTable.Instance.hasUser(randomUserID)) {
                    randomUserID = random.Next(0, int.MaxValue);
                }
                //Create a user with this ID.
                User tempUser = new User(randomUserID);

                //Rate the items to promote with a 5
                for(int j = 0; j < itemsToPromote.Count(); j++) {
                    tempUser.addRatedItem(itemsToPromote[j]);
                    RatingsLookupTable.Instance.addFakeProfileEntry(randomUserID, itemsToPromote[j].getId(), 5);
                }

                //Rate a bunch of random items with a random rating
                for(int j = 0; j < numOfItems; j++) {
                    //Get a list of all items
                    IEnumerable<Item> allItems = RatingsLookupTable.Instance.getItems();
                    //Pick a random one
                    var itemsArray = allItems.ToArray();
                    Item randomItem = itemsArray[random.Next(0, itemsArray.Count())];
                    int attempts = 0;
                    while(tempUser.hasRatingForItem(randomItem) && attempts < 30)  { //While the user has a rating for the item, 
                        randomItem = itemsArray[random.Next(0, itemsArray.Count())]; //Find a new item to rate
                        attempts++;                                                  //Only try 30 times, else don't rate (implies all items are rated)
                    }
                    //Check we haven't already rated the item, and then rate it
                    //This is to make sure we don't randomly rate an item we're supposed to promote
                    if(!tempUser.hasRatingForItem(randomItem)) { //If true, user has not rated item (note !)
                        tempUser.addRatedItem(randomItem);
                        //Rate the item anywhere between 1 and 5, excluding 5. 
                        RatingsLookupTable.Instance.addFakeProfileEntry(randomUserID, randomItem.getId(), random.Next(1, 5));
                    }
                }
            }
        }


    }
}
