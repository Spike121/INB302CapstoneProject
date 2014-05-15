using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.UI.PageChangeParameters
{
    public class BasePageChangeParameters : IPageChangeParameters
    {
        protected string m_previousPageValidationGuid;
        public BasePageChangeParameters(string currentPageValidationGuid)
        {
            m_previousPageValidationGuid = currentPageValidationGuid;
        }

        public string getPreviousPageValidationGuid()
        {
            return m_previousPageValidationGuid; 
        }
    }
}
