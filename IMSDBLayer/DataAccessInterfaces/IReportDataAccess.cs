using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessInterfaces
{
    public interface IReportDataAccess
    {
        IEnumerable<ReportRow> totalCostByEngineer();

        IEnumerable<ReportRow> averageCostByEngineer();
        IEnumerable<ReportRow> costByDistrict();
        IEnumerable<ReportRow> monthlyCostForDistrict(Guid districtId);

    }
}
