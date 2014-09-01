using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RecommenderAttacksAnalytics.Entities.LocalPersistence
{
    public interface ILocalPersistenceEntity : INotifyPropertyChanged
    {
        double diffFromAverageSquared(double average);
        double diffFromAverage(double average);
        double doDiffFromAverage(double average, bool isSquared);
    }
}
