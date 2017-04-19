using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Models
{
    public class ReportRow: IMSDBLayer.DataModels.ReportRow
    {

        public ReportRow(string firstprop, decimal cost, decimal hour)
        {
            this.FirstProperty = firstprop;
            this.Costs = cost;
            this.Hours = hour;
        }



    }
}
