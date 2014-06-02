using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.UI.PageChangeParameters
{
    public class FromSelectItemsPageChangeParameters : BasePageChangeParameters
    {
        public User SelectedUser { get; set; }
        public IEnumerable<Item> SelectedItems { get; set; }
        public IEnumerable<Item> SelectedPromotedItems { get; set; }
        
        public FromSelectItemsPageChangeParameters(string pageValidationGuid, User selectedUser, IEnumerable<Item> selectedItems, IEnumerable<Item> selectedPromotedItems)
            : base(pageValidationGuid)
        {
            SelectedUser = selectedUser;
            SelectedItems = selectedItems;
            SelectedPromotedItems = selectedPromotedItems;
        }
    }
}
