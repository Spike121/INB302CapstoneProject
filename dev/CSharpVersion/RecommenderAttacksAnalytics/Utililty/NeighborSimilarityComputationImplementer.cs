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
        private readonly User m_targetUser;
        private readonly User m_neighbor;

        public NeighborSimilarityComputationImplementer(User targetUser, User neighbor)
        {
            m_targetUser = targetUser;
            m_neighbor = neighbor;
        }

        /// <summary>
        /// Computes the average value of a list of ratings
        /// </summary>
        /// <param name="ratings">The list of ratings</param>
        /// <returns>The average</returns>
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

        
        
        /// <summary>
        /// Computes the simmilarity bewtween the selected targetUser and its neighbor
        /// </summary>
        /// <returns>The simmilarity (Pearson coefficient) between the two users</returns>
        public double computeSimilarity()
        {

            // Find the common items between the targetUser and the neighbor
            var commonRatedItemsForTargetUser = m_targetUser.findItemsInCommonWithNeighbor(m_neighbor);
            var commonRatedItemsForNeighbor = m_neighbor.findItemsInCommonWithNeighbor(m_targetUser);

            //Debug.Assert(commonItemsWithRatingsForNeighbor.Count == commonItemsWithRatingsForUser.Count);

            // Get the average for each
            var targetUserAverage = getRatingAverageFromRatingsCollection(commonRatedItemsForTargetUser.Values.ToList());
            var neighborAverage = getRatingAverageFromRatingsCollection(commonRatedItemsForNeighbor.Values.ToList());

            // Do the pearsoncoefficient computation
            var top = 0.0d;

            foreach (var targetUserPair in commonRatedItemsForTargetUser)
            {
                var targetUserRating = targetUserPair.Value;
                var neighborRating = commonRatedItemsForNeighbor[targetUserPair.Key];
                
                var targetUserDiff = targetUserRating - targetUserAverage;
                var neighborDiff = neighborRating - neighborAverage;

                top += targetUserDiff * neighborDiff;
            }


            var bottomLeft = Math.Sqrt(diffFromAverageSquared(commonRatedItemsForTargetUser, targetUserAverage));
            var bottomRight = Math.Sqrt(diffFromAverageSquared(commonRatedItemsForNeighbor, neighborAverage));

            var result = top / (bottomLeft * bottomRight);
            return result;

        }
    }
}
