using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.Common
{
    public abstract class AbstractUser : AbstractPersistenceEntity
    {
        protected long m_userId;

        public override long getId()
        {
            return m_userId;
        }
    }
}
