using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.Output {
    class FakeProfilesToTextfile {
        public static void CreateFakeProfilesTextfile() {
            List<string> OutputText = new List<string>();
            //Fetch rating list
            var ratingList = RatingsLookupTable.Instance.FakeProfilesTable;
            IEnumerable<User> userList;
            try {
                userList = ratingList.getUsers();
            } catch (Exception) {
                throw new Exception("You have not imported data yet.");
            }
            foreach (User user in userList) {
                foreach(KeyValuePair<Item, int> itemRatingsForUser in ratingList.getAllItemRatingsForUser(user)) {
                    //Append each user item rating
                    OutputText.Add(user.getId()+" "+itemRatingsForUser.Key.getId()+" "+itemRatingsForUser.Value);
                }
            }
            
            //Output to text file
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\WriteLines.txt");
            foreach(string line in OutputText) {
                file.WriteLine(line);
            }
        }
    }
}
