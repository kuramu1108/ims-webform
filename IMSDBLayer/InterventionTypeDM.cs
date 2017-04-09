using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer
{
    public class InterventionTypeDM
    {
        public Common.InterventionType Name { get; set; }
        public double Hours { get; set; }

        public decimal Cost { get; set; }

        public InterventionTypeDM() { }
        public InterventionTypeDM(Common.InterventionType name, double hours, decimal cost)
        {
            Name = name;
            Hours = hours;
            Cost = cost;
        }


    }
}
