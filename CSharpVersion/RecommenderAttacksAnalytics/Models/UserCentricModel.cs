using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;
using System.Collections.Specialized;

namespace RecommenderAttacksAnalytics.Models
{
    public class UserCentricModel : AbstractModel
    {

        public UserCentricModel(long userId)
        {
            SelectedUser = RatingsLookupTable.Instance.getUser(userId);
        }

        private User SelectedUser {
            get { return m_selectedEntity as User;  }
            set { m_selectedEntity = value; }
        }

        protected override PearsonComputationResults getPearsonCoefficients()
        {
            var pearsonCoefficients = new Dictionary<IPersistenceEntity, double>();
            double absPearsonCoeffSum = 0.0f;

            foreach(var neighbor in RatingsLookupTable.Instance.getUsers() )
            {
                if (!neighbor.Equals(SelectedUser))
                {
                    var value = computeSimilarityToNeighbor(SelectedUser, neighbor);
                    pearsonCoefficients.Add(neighbor, value);
                    absPearsonCoeffSum += Math.Abs(value);
                }
            }

            return new PearsonComputationResults(pearsonCoefficients, absPearsonCoeffSum);
        }

        protected override double computeSimilarityToNeighbor(IPersistenceEntity selectedEntity, IPersistenceEntity neighborEntity)
        {
            var user = selectedEntity as User;
            var neighbor = neighborEntity as User;
            
            var commonItemsWithRatingsForUser = user.findItemsInCommonWithNeighbor(neighbor);
            var commonItemsWithRatingsForNeighbor = neighbor.findItemsInCommonWithNeighbor(user);

            var userAverage = Util.getRatingAverageFromRatingsCollection(commonItemsWithRatingsForUser.Values.ToList());
            var neighborAverage = Util.getRatingAverageFromRatingsCollection(commonItemsWithRatingsForNeighbor.Values.ToList());

            var top = user.diffFromAverage(userAverage) * neighbor.diffFromAverage(neighborAverage);
            var bottomLeft = Math.Sqrt(user.diffFromAverageSquared(userAverage));
            var bottomRight = Math.Sqrt(neighbor.diffFromAverageSquared(neighborAverage));

            return top / (bottomLeft + bottomRight);
        }

        public override void computePredictions()
        {
            var pearsonResults = getPearsonCoefficients();
            var pearsonCoefficients = pearsonResults.PearsonCoefficients.ToDictionary(x =>  x.Key as User, x => x.Value );
            //OrderedDictionary a = new OrderedDictionary(

            // TODO: Check sort order & cutoff
            pearsonCoefficients = pearsonCoefficients.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            pearsonCoefficients.Take(NEIGHBORBOOD_K_SIZE);
            var targetUserAverageRating = SelectedUser.getRatingAverageForUser();
            var predictions = new Dictionary<Item, double>();
            
            foreach (var item in RatingsLookupTable.Instance.getItems())
            {
                double top = 0.0;
                foreach (var v in pearsonCoefficients)
                {
                    var user = v.Key;
                    var pearsonCoefficient = v.Value;

                    if(item.hasRatingFromUser(user))
                        top += pearsonCoefficient * (item.getRatingFromUser(user) - targetUserAverageRating);
                }
                var prediction = pearsonResults.IsAbsolutePearsonCoefficientSumZero ? targetUserAverageRating :targetUserAverageRating + (top / pearsonResults.AbsolutePearsonsCoefficientSum);
                predictions.Add(item, prediction);
            }
        }

        
    }
}
