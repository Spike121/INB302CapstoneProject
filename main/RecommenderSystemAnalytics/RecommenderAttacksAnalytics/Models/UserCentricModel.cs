﻿using System;
using System.Collections.Generic;
using System.Linq;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;
using RecommenderAttacksAnalytics.Utililty;
using RecommenderAttacksAnalytics.Utility;

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

        public IEnumerable<User> Neighborhood
        {
            get { return m_neighborhood.Cast<User>(); }
            set { m_neighborhood = value; }
        }

        public UserCentricModel(User user, IEnumerable<User> neighborhood, IEnumerable<Item> selectedItems)
        {
            SelectedUser = user;
            SelectedItems = selectedItems;
            Neighborhood = neighborhood;
        }

        public UserCentricModel(User user, IEnumerable<User> neighborhood, IEnumerable<User> fakeUsersNeighborhood, IEnumerable<Item> selectedItems)
            : this(user, neighborhood.Concat(fakeUsersNeighborhood).ToList(), selectedItems.ToList() )
        {
        }

        public UserCentricModel(UserCentricModel baseModel, IEnumerable<User> fakeUserNeighborhood)
        {
            
        }

        private void mutateToFakeModel()
        {
            
        }

        /// <summary>
        /// Generates a mapping of all the selected item's neighbors and their 
        /// simmilarity (pearson coeff) to it
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<IPersistenceEntity, double> getPearsonCoefficients()
        {
            var pearsonCoefficients = new Dictionary<IPersistenceEntity, double>();

            foreach(var neighbor in Neighborhood )
            {
                if (!neighbor.Equals(SelectedUser))
                {
                    var value = computeSimilarityToNeighbor(SelectedUser, neighbor);
                    pearsonCoefficients.Add(neighbor, value);
                }
            }

            return pearsonCoefficients;
        }

        /// <summary>
        /// Computes the simmilarity bewtween 2 users
        /// </summary>
        /// <param name="selectedEntity">The selected user</param>
        /// <param name="neighborEntity">The neighboring user</param>
        /// <returns>The simmilarity between the two</returns>
        protected override double computeSimilarityToNeighbor(IPersistenceEntity selectedEntity, IPersistenceEntity neighborEntity)
        {
            var user = selectedEntity as User;
            var neighbor = neighborEntity as User;

            var computationImplementer = new NeighborSimilarityComputationImplementer(user, neighbor);

            return computationImplementer.computeSimilarity();
        }

        /// <summary>
        /// Computes the predictions of the recommendations based on the available datasets
        /// </summary>
        public override void computePredictions()
        {
            m_predictions.Clear();
            var pearsonCoefficients = getPearsonCoefficients();
            
            // TODO: Try with a threshold instead of a neighborhood size
            //pearsonCoefficients = pearsonCoefficients.OrderByDescending(x => x.Value).Take(NEIGHBORBOOD_K_SIZE).ToDictionary(x => x.Key, x => x.Value);
            pearsonCoefficients = pearsonCoefficients.Where(x => x.Value > 0.0d).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            
            var targetUserAverageRating = SelectedUser.getRatingAverageForUser();
            
            // Predict rating for every item
            foreach (var item in SelectedItems)
            {
                var top = 0.0d;
                var pearsonAbsSum = 0.0d;

                foreach (var userCoeffPair in pearsonCoefficients)
                {
                    var neighbor = userCoeffPair.Key as User;
                    var pearsonCoefficient = userCoeffPair.Value;

                    if (item.hasRatingFromUser(neighbor) )
                    {
                        pearsonAbsSum += Math.Abs(pearsonCoefficient);
                        top += pearsonCoefficient * (item.getRatingFromUser(neighbor) - neighbor.getRatingAverageForUser());
                    }
                }

                var prediction = pearsonAbsSum < Double.Epsilon ? targetUserAverageRating
                                                                : targetUserAverageRating + (top / pearsonAbsSum);
                if (!m_predictions.ContainsKey(item))
                    m_predictions.Add(item, prediction);
            }

            Logger.log("Done with computations.");
        }


   
    }
}
