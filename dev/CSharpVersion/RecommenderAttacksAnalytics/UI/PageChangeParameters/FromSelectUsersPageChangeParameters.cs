using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.UI.PageChangeParameters
{
    public class FromSelectUsersPageChangeParameters : BasePageChangeParameters
    {
        public User SelectedUser { get; set; }

        public FromSelectUsersPageChangeParameters(string pageValidationGuid, User selectedUser)
            : base(pageValidationGuid)
        {
            SelectedUser = selectedUser;
        }
    }
}
