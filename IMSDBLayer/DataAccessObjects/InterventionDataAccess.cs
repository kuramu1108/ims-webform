using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessInterfaces.Helpers;
using IMSDBLayer.DataModels;
using System.Data.SqlClient;

namespace IMSDBLayer.DataAccessObjects
{
    public class InterventionDataAccess : IInterventionDataAccess
    {
        private ISqlExecuter<Intervention> sqlExecuter;

        public InterventionDataAccess(ISqlExecuter<Intervention> sqlExecuter)
        {
            this.sqlExecuter = sqlExecuter;
        }

        public Intervention create(Intervention intervention)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Interventions (Hours, Costs, LifeRemaining, Comments, 
                State, DateCreate, DateFinish, DateRecentVisit, InterventionTypeId, ClientId, CreatedBy, ApprovedBy) " 
                + "VALUES(@Hours, @Costs, @LifeRemaining, @Comments, @State, @DateCreate, @DateFinish, @DateRecentVisit," +
                " @InterventionTypeId, @ClientId, @CreatedBy, @ApprovedBy)");

            intervention.Id = (Guid)sqlExecuter.ExecuteScalar(command, intervention);
            if (intervention.Id != Guid.Empty)
                return intervention;
            return null;
        }

        public bool update(Intervention intervention)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Interventions Set Hours = @Hours, Costs = @Costs, LifeRemaining = @LifeRemaining,
                Comments = @Comments, State = @State, DateCreate = @DateCreate, DateFinish = @DateFinish, DateRecentVisit = @DateRecentVisit,
                InterventionTypeId = @InterventionTypeId, ClientId = @ClientId, CreatedBy = @CreatedBy, ApprovedBy = @ApprovedBy WHERE Id = @Id");

            return sqlExecuter.ExecuteNonQuery(command, intervention) > 0;
        }

        public IEnumerable<Intervention> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From Interventions");
            return sqlExecuter.ExecuteReader(command);
        }

        public Intervention fetchInterventionsById(Guid interventionId)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where Id = @Id");
            command.Parameters.AddWithValue("@Id", interventionId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
        
        public IEnumerable<Intervention> fetchInterventionsByDistrict(Guid districtId)
        {
            SqlCommand command = new SqlCommand(@"Select (I.Id, I.Hours, I.Costs, I.LifeRemaining, I.Comments, I.State, 
                I.DateCreate, I.DateFinish, I.DateRecentVisit, I.InterventionTypeId, I.ClientId, I.CreatedBy, I.ApprovedBy) 
                From Interventions JOIN Clients C ON I.ClientId = C.Id where C.DistrictId = @DistrictId");

            command.Parameters.AddWithValue("@DistrictId", districtId);
            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<Intervention> fetchInterventionsByState(int state)
        {
            SqlCommand command = new SqlCommand(@"Select * where State = @State");

            command.Parameters.AddWithValue("@State", state);
            return sqlExecuter.ExecuteReader(command);
        }
        
        public IEnumerable<Intervention> fetchInterventionsByInterventionType(Guid interventionTypeId)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where InterventionTypeId = @InterventionTypeId");
            command.Parameters.AddWithValue("@InterventionTypeId", interventionTypeId);
            return sqlExecuter.ExecuteReader(command);
        }

        public IEnumerable<Intervention> fetchInterventionsByCreator(Guid createdBy)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where CreatedBy = @CreatedBy");
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            return sqlExecuter.ExecuteReader(command);
        }
    }
}
