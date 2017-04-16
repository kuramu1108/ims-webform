using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataModels
{
    public class InterventionType
    {
        private Guid id;
        private string name;
        private decimal hours;
        private decimal costs;
        
        public Guid Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public decimal Hours
        {
            get { return this.hours; }
            set { this.hours = value; }
        }

        public decimal Costs
        {
            get { return this.costs; }
            set { this.costs = value; }
        }
    }
}
