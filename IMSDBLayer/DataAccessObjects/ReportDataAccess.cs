using IMSDBLayer.DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataModels;
using System.Data.SqlClient;
using IMSDBLayer.DataAccessInterfaces.Helpers;

namespace IMSDBLayer.DataAccessObjects
{
    public class ReportDataAccess : IReportDataAccess
    {

        private ISqlExecuter<ReportRow> sqlExecuter;

        public ReportDataAccess(ISqlExecuter<ReportRow> sqlExecuter)
        {
            this.sqlExecuter = sqlExecuter;
        }

        public IEnumerable<ReportRow> averageCostByEngineer()
        {
            SqlCommand command = new SqlCommand("Select User.Name, avg(Intervention.Cost), avg(Intervention.Hour) " +
                @"From User inner join Intervention On User.Id = Intervention.CreatedBy Where User.type = 'SiteEngineer' AND " +
                @"Intervention.State = '3' group by User.Name Order By User.Name asc");

            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> costByDistrict()
        {
            SqlCommand command = new SqlCommand("Select District.Name, sum(Intervention.Cost), sum(Intervention.Hour) " +
                @"From ((Client inner join District on  Client.DistrictId = District.Id)" +
                @" Inner join  Intervention On Client.InterventionId = Intervention.Id )" +
                @"Where Intervention.State= '3' group by District.Name ");

            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> monthlyCostForDistrict(Guid districtId)
        {
            SqlCommand command = new SqlCommand(@"Select Intervention.DateFinish, sum(Intervention.Cost), sum(Intervention.Hour) " +
                @"From ((Client inner join District on  Client.DistrictId = @districtId) " +
                @"Inner join  Intervention On Client.InterventionId = Intervention.Id )" +
                @"Where Intervention.State= '3' group by Intervention.DateFinish ");
            command.Parameters.AddWithValue("@districtId", districtId);
            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> totalCostByEngineer()
        {
            SqlCommand command = new SqlCommand("Select User.Name, sum(Intervention.Cost), sum(Intervention.Hour)" +
                @" From User inner join Intervention on User.Id = Intervention.CreatedBy " +
                @"Where User.type = 'SiteEngineer' AND Intervention.State = '3' " +
                @"group by User.Name Order By User.Name asc");

            return sqlExecuter.ExecuteReader(command);
        }
    }
}
