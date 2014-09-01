using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;
using RecommenderAttacksAnalytics.Entities.LocalPersistence;

namespace RecommenderAttacksAnalytics.Models
{
    public abstract class AbstractModel
    {
        protected const int NEIGHBORBOOD_K_SIZE = 20;
        protected AbstractPersistenceEntity m_selectedEntity;
        protected IEnumerable<AbstractPersistenceEntity> m_selectedCounterpartEntities;
        protected IEnumerable<AbstractPersistenceEntity> m_neighborhood;     
        protected Dictionary<AbstractPersistenceEntity, double> m_predictions = new Dictionary<AbstractPersistenceEntity, double>();
        public Dictionary<AbstractPersistenceEntity, double> Predictions
        {
            get { return m_predictions; }
        } 
        
        protected abstract double computeSimilarityToNeighbor(IPersistenceEntity mainEntity, IPersistenceEntity neighborEntity);
        protected abstract Dictionary<IPersistenceEntity, double> getPearsonCoefficients();
        public abstract void computePredictions();

    }
}
