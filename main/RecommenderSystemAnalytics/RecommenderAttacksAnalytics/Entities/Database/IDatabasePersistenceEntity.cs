﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.Database
{
    public interface IDatabasePersistenceEntity
    {
        void setId(long id);
    }
}
