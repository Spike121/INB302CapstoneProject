using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.Output {
    public class FakeProfilesToTextfile {
        public static void CreateFakeProfilesTextfile() {
            //Fetch rating list
            var ratingList = RatingsLookupTable.Instance.FakeProfilesTable;
            
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\FakeProfiles.txt");
            IEnumerable<User> userList;
            try {
                userList = ratingList.getUsers();
            } catch (Exception) {
                throw new Exception("You have not imported data yet.");
            }
            foreach (User user in userList) {
                foreach(KeyValuePair<Item, int> itemRatingsForUser in ratingList.getAllItemRatingsForUser(user)) {
                    //Append each user item rating
                    file.WriteLine(user.getId()+" "+itemRatingsForUser.Key.getId()+" "+itemRatingsForUser.Value);
                }
            }
            file.Close();
        }
    }
}
