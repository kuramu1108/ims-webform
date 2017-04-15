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
        Report totalCostByEngineerReport();

        Report averageCostByEngineerReport();

        Report costByDistrictReport();

        Report MonthlyCostByDistrict();

    }
}
