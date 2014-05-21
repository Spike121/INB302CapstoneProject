using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Loader;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.UI.Containers
{
    public class PredictionResultContainer
    {
        private AbstractPersistenceEntity m_entity;
        public AbstractPersistenceEntity EntityId
        {
            get { return m_entity; }
        }

        public double OriginalScore
        {
            get;
            private set;
        }

        public double FinalScore
        {
            get;
            set;
        }

        public PredictionResultContainer(AbstractPersistenceEntity entity, double originalScore)
        {
            m_entity = entity;
            OriginalScore = originalScore;
        }


    }
}
