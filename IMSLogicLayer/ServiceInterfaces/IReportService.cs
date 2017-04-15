using IMSLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.ServiceInterfaces
{
    public interface IReportService
    {
        Report totalCostByEngineerReport();

        Report averageCostByEngineerReport();

        Report costByDistrictReport();

        Report MonthlyCostByDistrict();
    }
}
