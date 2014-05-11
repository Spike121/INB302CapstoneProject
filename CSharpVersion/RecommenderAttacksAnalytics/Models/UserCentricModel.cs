using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utility;

namespace RecommenderAttacksAnalytics.Models
{
    public class UserCentricModel : AbstractModel
    {

        private User SelectedUser {
            get { return m_selectedEntity as User;  }
            set { m_selectedEntity = value; }
        } 

        protected override Dictionary<IPersistenceEntity, double> getPearsonCoefficients()
        {
            var pearsonCoefficients = new Dictionary<IPersistenceEntity, double>();
            foreach(var neighbor in RatingsLookupTable.Instance.getUsers() )
            {
                if (!neighbor.Equals(SelectedUser))
                {
                    var value = computeSimilarityToNeighbor(SelectedUser, neighbor);
                    pearsonCoefficients.Add(neighbor, value);
                }
            }

            return pearsonCoefficients;
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

        protected override void computePredictions()
        {
            var pearsonCoefficients = getPearsonCoefficients().ToDictionary(x =>  x.Key as User, x => x.Value);
            // TODO: Check sort order
            //pearsonCoefficients = pearsonCoefficients.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


           /* for()
            {
                
            }*/
        }
    }
}
