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
            SqlCommand command = new SqlCommand("Select Users.Name, avg(Interventions.Costs), avg(Interventions.Hours) " +
                @"From Users inner join Interventions On Users.Id = Interventions.CreatedBy Where Users.type = '1' AND " +
                @"Interventions.State = '2' group by Users.Name Order By Users.Name asc");

            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> costByDistrict()
        {
            SqlCommand command = new SqlCommand("Select Districts.Name, sum(Interventions.Costs), sum(Interventions.Hours) " +
                @"From ((Clients inner join Districts on  Clients.DistrictId = Districts.Id)" +
                @" Inner join  Interventions On Interventions.ClientId = Clients.Id )" +
                @"Where Interventions.State= '2' group by Districts.Name ");

            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> monthlyCostForDistrict(Guid districtId)
        {
            SqlCommand command = new SqlCommand(@"Select  Distinct convert(varchar(7), Interventions.DateFinish, 120), sum(Interventions.Costs), sum(Interventions.Hours) " +
                @"From (Clients "+
               
                @"Inner join  Interventions On Interventions.ClientId = Clients.Id )" +
                @"Where Interventions.State= '2' And  Clients.DistrictId = @districtId group by Interventions.DateFinish ");
            command.Parameters.AddWithValue("@districtId", districtId);
            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<ReportRow> totalCostByEngineer()
        {
            SqlCommand command = new SqlCommand("Select Users.Name, sum(Interventions.Costs), sum(Interventions.Hours)" +
                @" From Users inner join Interventions on Users.Id = Interventions.CreatedBy " +
                @"Where Users.type = '1' AND Interventions.State = '2' " +
                @"group by Users.Name Order By Users.Name asc");

            return sqlExecuter.ExecuteReader(command);
        }
    }
}
