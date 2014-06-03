using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class RatingsLookupTable : DependencyObject
    {

        private  Dictionary<long, Item> m_itemSet = new Dictionary<long, Item>();
        private  Dictionary<long, User> m_userSet = new Dictionary<long, User>();
        private  Dictionary<UserItemPair, int> m_ratingsLookup = new Dictionary<UserItemPair, int>();

        //Cache
        private Dictionary<long, Dictionary<Item, int>> m_itemRatingsForUserCache = new Dictionary<long, Dictionary<Item, int>>();
        private Dictionary<long, Dictionary<User, int>> m_userRatingsForItemCache = new Dictionary<long, Dictionary<User, int>>();

        private FakeProfilesRatingsLookupTable m_fakeProfilesTable;

        public FakeProfilesRatingsLookupTable FakeProfilesTable
        {
            get{ return m_fakeProfilesTable; }
        }

        public bool HasData
        {
            get { return (bool)GetValue(HasDataProperty); }
            set { SetValue(HasDataProperty, value); }
        }

        public bool IsTableForFakeProfiles { get; private set; }

        public static readonly DependencyProperty HasDataProperty =
            DependencyProperty.Register("HasData", typeof(bool), typeof(RatingsLookupTable), new UIPropertyMetadata(false));

        private static RatingsLookupTable m_instance;
        public static RatingsLookupTable Instance
        {
            get
            {
                
                 if(m_instance == null)
                 {
                     m_instance = new RatingsLookupTable()
                     {
                         m_fakeProfilesTable = new FakeProfilesRatingsLookupTable()
                     };
                 }

                return m_instance;
            }
        }

        protected RatingsLookupTable()
        {
            //IsTableForFakeProfiles = isTableForFakeProfiles;
        }

        /// <summary>
        /// Adds an entry to the table based on a TableEntry instance
        /// </summary>
        /// <param name="entry">The TableEntry instance containign the lements to add</param>
        public virtual UserItemPair addEntry(TableEntry entry)
        {
            return addEntry(entry.UserId, entry.ItemId, entry.Rating);
        }

        /// <summary>
        /// Adds an entry to the table, keeping a separate list of unique users and items.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="itemId"></param>
        /// <param name="rating"></param>
        public UserItemPair addEntry(long userId, long itemId, int rating)
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

            var key = new UserItemPair(user, item);
            m_ratingsLookup.Add(key, rating);

            //if (HasData)
            //{
            //}

            return key;

        }

        public UserItemPair addFakeProfileEntry(TableEntry entry)
        {
            if (!hasEntry(entry))
                return m_fakeProfilesTable.addEntry(entry);

            return null;
        }

        /// <summary>
        /// Clears all the users, items and ratings from the table
        /// </summary>
        public void clearAllData()
        {
            m_itemSet = new Dictionary<long, Item>();
            m_userSet = new Dictionary<long, User>();
            m_ratingsLookup = new Dictionary<UserItemPair, int>();
            m_itemRatingsForUserCache = new Dictionary<long, Dictionary<Item, int>>();
            m_userRatingsForItemCache = new Dictionary<long, Dictionary<User, int>>();
            m_fakeProfilesTable = new FakeProfilesRatingsLookupTable();
            HasData = false;
        }

        /// <summary>
        /// Shortcut method fro generating a UserItemPair object based on its containing values
        /// </summary>
        /// <param name="user">The user member of the pair</param>
        /// <param name="item">The item member of the pair</param>
        /// <returns></returns>
        private UserItemPair createUserItemPair(User user, Item item)
        {
            return new UserItemPair(user, item);
        }

        /// <summary>
        /// Returns if there exists a rating between this user and this item
        /// </summary>
        /// <param name="user"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool hasEntry(User user, Item item)
        {
            return hasEntry(createUserItemPair(user, item));
        }

        public bool hasEntry(UserItemPair pair)
        {
            return m_ratingsLookup.ContainsKey(pair);
        }

        public bool hasEntry(TableEntry entry)
        {
            return m_ratingsLookup.ContainsKey(entry.getUserItemPair());
        }

        public bool hasUser(long userId)
        {
            return m_userSet.ContainsKey(userId);
        }

        public bool hasItem(long itemId)
        {
            return m_itemSet.ContainsKey(itemId);
        }


        /// <summary>
        /// Returns the rating of an item by a particular user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public int getRatingForEntry(User user, Item item)
        {
            return m_ratingsLookup[createUserItemPair(user, item)];
        }

        /// <summary>
        /// Returns a map of all the rated items for a particular user and the associated rating value
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Map of the rated items for that user, along with the rating value</returns>
        public Dictionary<Item, int> getAllItemRatingsForUser(User user)
        {
            Dictionary<Item, int> itemRatings;
            if(m_itemRatingsForUserCache.ContainsKey(user.getId()))
            {
                itemRatings = m_itemRatingsForUserCache[user.getId()];
            }
            else
            {
                itemRatings = new Dictionary<Item, int>();

                foreach(var itemRatingPair in m_itemSet)
                {
                    var item = itemRatingPair.Value;
                    var itemUserPair = createUserItemPair(user, item);

                    if(m_ratingsLookup.ContainsKey(itemUserPair))
                        itemRatings.Add(item, m_ratingsLookup[itemUserPair]);
                }

                m_itemRatingsForUserCache.Add(user.getId(), itemRatings);
            }

            return itemRatings;
        }

        /// <summary>
        /// Returns a map of all the users having rated a particular item and the associated rating value
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Map of the raters for that item, along with the rating value</returns>
        public Dictionary<User, int> getAllUserRatingsForItem(Item item)
        {
            Dictionary<User, int> userRatings;
           
            if(m_userRatingsForItemCache.ContainsKey(item.getId()))
            {
                userRatings = m_userRatingsForItemCache[item.getId()];
            }
            else
            {
                userRatings = new Dictionary<User, int>();

                foreach (var userRatingPair in m_userSet)
                {
                    var user = userRatingPair.Value;
                    var itemUserPair = createUserItemPair(user, item);

                    if (m_ratingsLookup.ContainsKey(itemUserPair))
                        userRatings.Add(user, m_ratingsLookup[itemUserPair]);
                }
            }

            return userRatings;
        }

        /// <summary>
        /// Get all the unique users in the lookup table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> getUsers()
        {
            return m_userSet.Values;
        }

        /// <summary>
        /// Return a specified user
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns>The user object</returns>
        public User getUser(long userId)
        {
            return m_userSet[userId];
        }

        /// <summary>
        /// Get all the unique items in the lookup table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> getItems()
        {
            return m_itemSet.Values;
        }

        /// <summary>
        /// Return a specified item
        /// </summary>
        /// <param name="userId">The item's id</param>
        /// <returns>The item object</returns>
        public Item getItem(long itemId)
        {
            return m_itemSet[itemId];
        }
    }
}
