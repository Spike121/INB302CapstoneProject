using System;
using System.Collections.Generic;
using System.IO;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.Output {
    public class FakeProfilesToTextfile {
        public static void CreateFakeProfilesTextfile(string filePath) {
            
            //Fetch rating list
            var ratingList = RatingsLookupTable.Instance.FakeProfilesTable;

            var fi = new FileInfo(filePath);
            if (!fi.Exists)
                return;

            StreamWriter file;
            IEnumerable<User> userList;
            
            try {
                file = new StreamWriter(filePath);
                userList = ratingList.getUsers();
            } catch (Exception) {
                return;
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
