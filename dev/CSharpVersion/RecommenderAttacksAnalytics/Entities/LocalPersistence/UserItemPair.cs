using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public class UserItemPair
    {
        public User User { get; private set; }
        public Item Item  { get; private set; }

        public UserItemPair(User user, Item item)
        {
            this.Item = item;
            this.User = user;
        }

        public override bool Equals(object obj)
        {
            //if (!(obj is UserItemPair))
               // return false;

            var userItemPair = obj as UserItemPair;

            return userItemPair.Item.Equals(this.Item) && userItemPair.User.Equals(this.User);
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode() + User.GetHashCode();
        }
    }
}
