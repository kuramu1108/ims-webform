using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;
using System.Data.SqlClient;
using IMSDBLayer.DataAccessObjects.Helpers;

namespace IMSDBLayer.DataAccessObjects
{
    public class InterventionDataAccess : IInterventionDataAccess
    {
        private SqlExecuter<Intervention> sqlExecuter;

        public InterventionDataAccess(string connstring)
        {
            this.sqlExecuter = new SqlExecuter<Intervention>(connstring);
        }

        public Intervention create(Intervention intervention)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Interventions (Name, Type, MaxHoursCanApprove, 
                MaxCostsCanApprove, IdentityId, DistrictId) " + "VALUES(@Name, @Type, " +
                "@MaxHoursCanApprove, @MaxCostsCanApprove, @IdentityId, @DistrictId)");

            intervention.Id = (Guid)sqlExecuter.ExecuteScalar(command, intervention);
            if (intervention.Id != Guid.Empty)
                return intervention;
            return null;
        }

        public bool update(Intervention intervention)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Interventions Set Name = @Name, Type = @Type,
                MaxHoursCanApprove = @MaxHoursCanApprove, MaxCostsCanApprove = @MaxCostsCanApprove,
                IdentityId = @IdentityId, DistrictId = @DistrictId WHERE Id = @Id");

            return sqlExecuter.ExecuteNonQuery(command, intervention) > 0;
        }

        public IEnumerable<Intervention> Interventions
        {
            get
            {
                SqlCommand command = new SqlCommand("Select * From Interventions");
                return null;
            }
        }

        public Intervention fetchInterventionsById(Guid interventionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> fetchInterventionsByCreator(Guid creatorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> fetchInterventionsByDistrict(Guid districtId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> fetchInterventionsByState(int state)
        {
            throw new NotImplementedException();
        }

    }
}
