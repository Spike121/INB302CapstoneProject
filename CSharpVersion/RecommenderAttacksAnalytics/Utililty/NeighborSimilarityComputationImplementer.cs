using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;

namespace RecommenderAttacksAnalytics.Utililty
{
    public class NeighborSimilarityComputationImplementer
    {
        private readonly User m_user;
        private readonly User m_neighbor;

        public NeighborSimilarityComputationImplementer(User user, User neighbor)
        {
            m_user = user;
            m_neighbor = neighbor;
        }

        private static double getRatingAverageFromRatingsCollection(List<int> ratings)
        {
            double avg = 0.0f;
            foreach (var rating in ratings)
                avg += rating;

            return (avg < Double.Epsilon) ? Double.Epsilon : avg / ratings.Count;
        }

        private double diffFromAverage( Dictionary<Item, int> itemsInCommon, double avg)
        {
            return doDiffFromAverage(avg, false, itemsInCommon.Values.ToList());
        }


        public double diffFromAverageSquared( Dictionary<Item, int> itemsInCommon, double avg)
        {
            return doDiffFromAverage(avg, true, itemsInCommon.Values.ToList());
        }


        public double doDiffFromAverage(double average, bool isSquared, List<int> itemRatings )
        {
            long exp = isSquared ? 2 : 1;

            return itemRatings.Sum(rating => Math.Pow(rating - average, exp));
        }

        public double computeSimilarity()
        {



            // Find the common items between the user and the neighbor
            var commonRatedItemsForUser = m_user.findItemsInCommonWithNeighbor(m_neighbor);
            var commonRatedItemsForNeighbor = m_neighbor.findItemsInCommonWithNeighbor(m_user);

            //Debug.Assert(commonItemsWithRatingsForNeighbor.Count == commonItemsWithRatingsForUser.Count);

            // Get the average for each
            var userAverage = getRatingAverageFromRatingsCollection(commonRatedItemsForUser.Values.ToList());
            var neighborAverage = getRatingAverageFromRatingsCollection(commonRatedItemsForNeighbor.Values.ToList());

            // Do the pearsoncoefficient computation
            var top = diffFromAverage(commonRatedItemsForUser,userAverage) * diffFromAverage(commonRatedItemsForNeighbor, neighborAverage);
            var bottomLeft = Math.Sqrt(diffFromAverageSquared(commonRatedItemsForUser, userAverage));
            var bottomRight = Math.Sqrt(diffFromAverageSquared(commonRatedItemsForNeighbor, neighborAverage));

            var result = top / (bottomLeft * bottomRight);
            return result;

        }
    }
}
