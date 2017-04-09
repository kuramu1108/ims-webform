using IMSDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class InterventionType
    {


        public Common.InterventionType Name { get; set; }
        public double Hours { get; set; }

        public decimal Cost { get; set; }

        public InterventionType() { }
        public InterventionType(Common.InterventionType name, double hours, decimal cost)
        {
            Name = name;
            Hours = hours;
            Cost = cost;
        }

    }
}
