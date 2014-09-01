using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.Common
{
    public abstract class AbstractPersistenceEntity : IPersistenceEntity
    {
       
        public  abstract  long getId();
        
        public override bool Equals(object obj)
        {
            if (!(obj is AbstractPersistenceEntity))
                return false;

            return getId() == (obj as AbstractPersistenceEntity).getId();
        }

        public override int GetHashCode()
        {
            return getId().GetHashCode();
        }

       

    }
}
