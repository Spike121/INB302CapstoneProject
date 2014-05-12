using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Utility
{
    public class Util
    {
        public static double getRatingAverageFromRatingsCollection(List<int> ratings)
        {
            double avg = 0.0f;
            foreach (var rating in ratings)
                avg += rating;

            return (ratings.Count == 0) ? 0.0f : avg / ratings.Count;
        }

      
    }
}
