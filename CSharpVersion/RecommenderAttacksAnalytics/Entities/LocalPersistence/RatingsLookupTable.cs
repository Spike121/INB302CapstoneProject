using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class RatingsLookupTable
    {

        private  Dictionary<long, Item> m_itemSet = new Dictionary<long, Item>();
        private  Dictionary<long, User> m_userSet = new Dictionary<long, User>();
        private  Dictionary<UserItemPair, int> m_ratingsLookup = new Dictionary<UserItemPair, int>();

        private static RatingsLookupTable m_instance;
        public static RatingsLookupTable Instance
        {
            get 
            {
                if(m_instance == null)
                    m_instance = new RatingsLookupTable();
                
                return m_instance;
            }
        }

        private RatingsLookupTable(){}

        public void addEntry(TableEntry entry)
        {
            addEntry(entry.UserId, entry.ItemId, entry.Rating);
        }

        public void addEntry(long userId, long itemId, int rating)
        {
            User user;
            Item item;

            if (!m_userSet.ContainsKey(userId))
            {
                user = new User(userId);
                m_userSet.Add(userId, user);
            }
            else
                user = m_userSet[userId];


            if (!m_itemSet.ContainsKey(itemId))
            {
                item = new Item(itemId);
                m_itemSet.Add(itemId, item);
            }
            else
                item = m_itemSet[itemId];

            item.addRater(user);
            user.addRatedItem(item);

            m_ratingsLookup.Add(new UserItemPair(user, item), rating);
        }

        public void clearAllData()
        {
            m_itemSet = new Dictionary<long, Item>();
            m_userSet = new Dictionary<long, User>();
            m_ratingsLookup = new Dictionary<UserItemPair, int>();
        }

        private UserItemPair createUserItemPair(User user, Item item)
        {
            return new UserItemPair(user, item);
        }

        public bool hasEntry(User user, Item item)
        {
            return m_ratingsLookup.ContainsKey(createUserItemPair(user, item));
        }

        public int getRatingForEntry(User user, Item item)
        {
            return m_ratingsLookup[createUserItemPair(user, item)];
        }

        public Dictionary<Item, int> getAllItemRatingsForUser(User user)
        {
            var itemRatings = new Dictionary<Item, int>();

            foreach(var itemRatingPair in m_itemSet)
            {
                var item = itemRatingPair.Value;
                var itemUserPair = createUserItemPair(user, item);

                if(m_ratingsLookup.ContainsKey(itemUserPair))
                    itemRatings.Add(item, m_ratingsLookup[itemUserPair]);
            }

            return itemRatings;
        }

        public Dictionary<User, int> getAllUserRatingsForItem(Item item)
        {
            var userRatings = new Dictionary<User, int>();

            foreach (var userRatingPair in m_userSet)
            {
                var user = userRatingPair.Value;
                var itemUserPair = createUserItemPair(user, item);

                if (m_ratingsLookup.ContainsKey(itemUserPair))
                    userRatings.Add(user, m_ratingsLookup[itemUserPair]);
            }

            return userRatings;
        }

        public IEnumerable<User> getUsers()
        {
            return m_userSet.Values;
        }

        public IEnumerable<Item> getItems()
        {
            return m_itemSet.Values;
        }
    }
}
