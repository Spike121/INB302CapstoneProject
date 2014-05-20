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
        protected Dictionary<AbstractPersistenceEntity, double> m_predictions = new Dictionary<AbstractPersistenceEntity, double>();
        public Dictionary<AbstractPersistenceEntity, double> Predictions
        {
            get { return m_predictions; }
        } 
        
        protected abstract double computeSimilarityToNeighbor(IPersistenceEntity mainEntity, IPersistenceEntity neighborEntity);
        protected abstract PearsonComputationResults getPearsonCoefficients();
        public abstract void computePredictions();
        


        public class PearsonComputationResults
        {
            private Dictionary<IPersistenceEntity, double> m_pearsonCoefficients;
            public Dictionary<IPersistenceEntity, double> PearsonCoefficients
            {
                get { return m_pearsonCoefficients; }
            }

            private double m_absolutePearsonsCoeffSum;
            public double AbsolutePearsonsCoefficientSum
            {
                get { return m_absolutePearsonsCoeffSum; }
            }

            public bool IsAbsolutePearsonCoefficientSumZero
            { 
                get { return m_absolutePearsonsCoeffSum == 0; }
            }

            public PearsonComputationResults(Dictionary<IPersistenceEntity, double> coefficients, double absPearsonCoeffSum)
            {
                this.m_pearsonCoefficients = coefficients;
                this.m_absolutePearsonsCoeffSum = absPearsonCoeffSum;
            }
        }
    }
}
