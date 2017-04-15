using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;

namespace IMSLogicLayer.Services
{
    public class ReportService : BaseService, IReportService
    {
        public ReportService(string connstring) : base(connstring)
        {
        }

        public Report averageCostByEngineerReport()
        {
            throw new NotImplementedException();
        }

        public Report costByDistrictReport()
        {
            throw new NotImplementedException();
        }

        public Report MonthlyCostByDistrict()
        {
            throw new NotImplementedException();
        }

        public Report totalCostByEngineerReport()
        {
            throw new NotImplementedException();
        }
    }
}
