using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Database;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class TableEntry
    {
        private long m_userId;
        private long m_itemId;
        private int m_rating;

        public long UserId { get { return m_userId;  } }
        public long ItemId { get { return m_itemId; } }
        public int Rating { get { return m_rating; } }


        public TableEntry(long user, long item, int rating)
        {
            m_userId = user;
            m_itemId = item;
            m_rating = rating;
        }

        public TableEntry(string[] args)
            : this(Int64.Parse(args[0]), Int64.Parse(args[1]), Int32.Parse(args[2]))
        {
           
        }

        public TableEntry(DBUserItemRating userItemRating)
            :this(userItemRating.userId, userItemRating.itemId, (int)userItemRating.rating)
        {
            //TODO: Fix the int cast
        }

        public override string ToString()
        {
            return String.Format("user {0}, rating item {1} with value {2}", m_userId, m_itemId, m_rating);
        }

        public UserItemPair getUserItemPair()
        {
            return new UserItemPair(new User(UserId), new Item(ItemId));
        }
    }
}
