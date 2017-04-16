using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataModels
{
    public class ReportRow
    {
        private string firstProperty;

        private decimal costs;

        private decimal hours;

        public string FirstProperty { get => firstProperty; set => firstProperty = value; }
        public decimal Costs { get => costs; set => costs = value; }
        public decimal Hours { get => hours; set => hours = value; }
    }
}
