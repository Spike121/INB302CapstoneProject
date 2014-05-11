using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.Common
{
    public abstract class AbstractItem : AbstractPersistenceEntity
    {
        protected long m_itemId;

        public override long getId()
        {
            return m_itemId;
        }

    }
}
