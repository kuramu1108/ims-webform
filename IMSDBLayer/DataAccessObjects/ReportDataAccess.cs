using IMSDBLayer.DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataModels;
using IMSDBLayer.DataAccessInterfaces.Helpers;
using System.Data.SqlClient;

namespace IMSDBLayer.DataAccessObjects
{
    public class ReportDataAccess : IReportDataAccess
    {
        private ISqlExecuter<Report> sqlExecuter;

        public ReportDataAccess(ISqlExecuter<Report> sqlExecuter)
        {
            this.sqlExecuter = sqlExecuter;
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
