using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Loader;
using RecommenderAttacksAnalytics.Entities.Common;

namespace RecommenderAttacksAnalytics.UI.Containers
{
    public class PredictionResultContainer
    {
       
        private AbstractPersistenceEntity m_entity;
        public long EntityId
        {
            get { return m_entity.getId(); }
        }

        public bool IsPromoted
        {
            get; private set;
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

        public PredictionResultContainer(AbstractPersistenceEntity entity, double originalScore, double finalScore, bool isPromoted)
        {
            m_entity = entity;
            OriginalScore = originalScore;
            FinalScore = finalScore;
            IsPromoted = isPromoted;
        }


    }
}
