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
            SqlCommand command = new SqlCommand("Select Users.Name, avg(Interventions.Cost), avg(Interventions.Hour) " +
                @"From Users inner join Interventions On Users.Id = Interventions.CreatedBy Where Users.type = 'SiteEngineer' AND " +
                @"Interventions.State = '3' group by Users.Name Order By Users.Name asc");

            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> costByDistrict()
        {
            SqlCommand command = new SqlCommand("Select Districts.Name, sum(Interventions.Cost), sum(Interventions.Hour) " +
                @"From ((Clients inner join Districts on  Clients.DistrictId = Districts.Id)" +
                @" Inner join  Interventions On Clients.InterventionId = Interventions.Id )" +
                @"Where Interventions.State= '3' group by Districts.Name ");

            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> monthlyCostForDistrict(Guid districtId)
        {
            SqlCommand command = new SqlCommand(@"Select Interventions.DateFinish, sum(Interventions.Cost), sum(Interventions.Hour) " +
                @"From ((Clients inner join Districts on  Clients.DistrictId = @districtId) " +
                @"Inner join  Interventions On Clients.InterventionId = Interventions.Id )" +
                @"Where Interventions.State= '3' group by Interventions.DateFinish ");
            command.Parameters.AddWithValue("@districtId", districtId);
            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> totalCostByEngineer()
        {
            SqlCommand command = new SqlCommand("Select Users.Name, sum(Interventions.Cost), sum(Interventions.Hour)" +
                @" From Users inner join Interventions on Users.Id = Interventions.CreatedBy " +
                @"Where Users.type = 'SiteEngineer' AND Interventions.State = '3' " +
                @"group by Users.Name Order By Users.Name asc");

            return sqlExecuter.ExecuteReader(command);
        }
    }
}
