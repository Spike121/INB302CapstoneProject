using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class UserItemPair
    {
        private User m_user;
        private Item m_item;

        public UserItemPair(User user, Item item)
        {
            this.m_item = item;
            this.m_user = user;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UserItemPair))
                return false;

            var userItemPair = obj as UserItemPair;

            return userItemPair.m_item.Equals(this.m_item) && userItemPair.m_user.Equals(this.m_user);
        }

        public override int GetHashCode()
        {
            return m_item.GetHashCode() + m_user.GetHashCode();
        }
    }
}
