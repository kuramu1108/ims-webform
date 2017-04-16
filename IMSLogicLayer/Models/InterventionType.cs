using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Models
{
    public class InterventionType: IMSDBLayer.DataModels.InterventionType
    {
        public InterventionType(string name, decimal hours, decimal costs)
        {
            
            Name = name;
            Hours = hours;
            Costs = costs;
        }
    }
}
