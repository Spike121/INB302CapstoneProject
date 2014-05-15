using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace RecommenderAttacksAnalytics.UI
{
    public partial class AbstractDataUploadUC : UserControl
    {
        public delegate void DataValidityStateChangeHandler(bool isValid);
        public event DataValidityStateChangeHandler DataValidityStateChangeEvent;
        private bool m_isPageActive = false;
        
        protected virtual void setDataValidityState(bool isValid)
        {
            if (DataValidityStateChangeEvent != null)
                DataValidityStateChangeEvent(isValid);
        }
    }
}
