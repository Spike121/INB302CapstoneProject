using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Entities.Common
{
    public interface IPersistenceEntity
    {
        double diffFromAverageSquared(double average);
        double diffFromAverage(double average);

         long getId();
    }
}
