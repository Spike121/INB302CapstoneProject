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
        private IEnumerable<Item> SelectedItems
        {
            get { return m_selectedCounterpartEntities.Cast<Item>(); }
            set { m_selectedCounterpartEntities = value; } 
        }

        private User SelectedUser
        {
            get { return m_selectedEntity as User; }
            set { m_selectedEntity = value; }
        }

        public UserCentricModel(long userId, IEnumerable<Item> selectedItems)
        {
            SelectedUser = RatingsLookupTable.Instance.getUser(userId);
            SelectedItems = selectedItems;
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
           
            var result = top / (bottomLeft * bottomRight);
            return result;
        }

        public override void computePredictions()
        {
            var pearsonResults = getPearsonCoefficients();
            var pearsonCoefficients = pearsonResults.PearsonCoefficients.ToDictionary(x =>  x.Key as User, x => x.Value );
            
            pearsonCoefficients = pearsonCoefficients.OrderByDescending(x => x.Value).Take(NEIGHBORBOOD_K_SIZE).ToDictionary(x => x.Key, x => x.Value);
            var targetUserAverageRating = SelectedUser.getRatingAverageForUser();
            var predictions = new Dictionary<Item, double>();

            foreach (var item in SelectedItems)
            {
                double top = 0.0;
                double pearsonAbsSum = 0.0f;

                foreach (var v in pearsonCoefficients)
                {

                    var user = v.Key;
                    var pearsonCoefficient = v.Value;
                    pearsonAbsSum += Math.Abs(pearsonCoefficient);

                    if(item.hasRatingFromUser(user))
                        top += pearsonCoefficient * (item.getRatingFromUser(user) - user.getRatingAverageForUser());
                }
                var prediction = pearsonResults.IsAbsolutePearsonCoefficientSumZero ? targetUserAverageRating : targetUserAverageRating + (top / pearsonAbsSum);
                predictions.Add(item, prediction);
            }
        }
    }
}
