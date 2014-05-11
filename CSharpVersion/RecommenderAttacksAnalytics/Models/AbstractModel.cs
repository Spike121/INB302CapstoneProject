using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.Models
{
    public abstract class AbstractModel
    {
        protected AbstractPersistenceEntity m_selectedEntity;

        protected abstract double computeSimilarityToNeighbor(IPersistenceEntity mainEntity, IPersistenceEntity neighborEntity);
        protected abstract Dictionary<IPersistenceEntity, double> getPearsonCoefficients();
        protected abstract void computePredictions();
        
    }
}
