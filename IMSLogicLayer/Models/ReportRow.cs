using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Models
{
    public class ReportRow: IMSDBLayer.DataModels.ReportRow
    {
        public ReportRow(string firstProperty, decimal costs, decimal hours)
        {
            base.FirstProperty = firstProperty;
            base.Costs = costs;
            base.Hours = hours;
        }

        public ReportRow(IMSDBLayer.DataModels.ReportRow reportRow)
        {
            base.FirstProperty = reportRow.FirstProperty;
            base.Costs = reportRow.Costs;
            base.Hours = reportRow.Hours;
        }
    }
}
