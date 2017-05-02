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
        /// <summary>
        /// Create an intervention
        /// </summary>
        /// <param name="intervention">an intervention object</param>
        /// <returns>an intervention object created</returns>
        public Intervention create(Intervention intervention)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Interventions (Hours, Costs, LifeRemaining, Comments, 
                State, DateCreate, DateFinish, DateRecentVisit, InterventionTypeId, ClientId, CreatedBy) "
                + "OUTPUT INSERTED.Id "
                + "VALUES(@Hours, @Costs, @LifeRemaining, @Comments, @State, @DateCreate, @DateFinish, @DateRecentVisit," +
                " @InterventionTypeId, @ClientId, @CreatedBy)");

            intervention.Id = (Guid)sqlExecuter.ExecuteScalar(command, intervention);
            if (intervention.Id != Guid.Empty)
                return intervention;
            return null;
        }
        /// <summary>
        /// Update the intervention
        /// </summary>
        /// <param name="intervention">intervention object</param>
        /// <returns>intervention object</returns>
        public bool update(Intervention intervention)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Interventions Set Hours = @Hours, Costs = @Costs, LifeRemaining = @LifeRemaining,
                Comments = @Comments, State = @State, DateCreate = @DateCreate, DateFinish = @DateFinish, DateRecentVisit = @DateRecentVisit,
                InterventionTypeId = @InterventionTypeId, ClientId = @ClientId, CreatedBy = @CreatedBy, ApprovedBy = @ApprovedBy WHERE Id = @Id");

            return sqlExecuter.ExecuteNonQuery(command, intervention) > 0;
        }
        /// <summary>
        /// Get all interventions
        /// </summary>
        /// <returns>a list of interventions</returns>
        public IEnumerable<Intervention> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From Interventions");
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get an intervention by it's id
        /// </summary>
        /// <param name="interventionId">the guid of an intervention</param>
        /// <returns>intervention object</returns>
        public Intervention fetchInterventionsById(Guid interventionId)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where Id = @Id");
            command.Parameters.AddWithValue("@Id", interventionId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
        /// <summary>
        /// Get a list of intervention by it's district
        /// </summary>
        /// <param name="districtId">the guid of a district</param>
        /// <returns>a list of intervention</returns>
        public IEnumerable<Intervention> fetchInterventionsByDistrict(Guid districtId)
        {
            SqlCommand command = new SqlCommand(@"Select (I.Id, I.Hours, I.Costs, I.LifeRemaining, I.Comments, I.State, 
                I.DateCreate, I.DateFinish, I.DateRecentVisit, I.InterventionTypeId, I.ClientId, I.CreatedBy, I.ApprovedBy) 
                From Interventions JOIN Clients C ON I.ClientId = C.Id where C.DistrictId = @DistrictId");

            command.Parameters.AddWithValue("@DistrictId", districtId);
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get a list of intervention by it's state
        /// </summary>
        /// <param name="state">The state of the intervention</param>
        /// <returns>a list of intervention</returns>
        public IEnumerable<Intervention> fetchInterventionsByState(int state)
        {
            SqlCommand command = new SqlCommand(@"Select * From Interventions where State = @State");

            command.Parameters.AddWithValue("@State", state);
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        ///  Get a list of intervention by it's interventionTypeId
        /// </summary>
        /// <param name="interventionTypeId">the guid of interventionType</param>
        /// <returns> a list of intervention</returns>
        public IEnumerable<Intervention> fetchInterventionsByInterventionType(Guid interventionTypeId)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where InterventionTypeId = @InterventionTypeId");
            command.Parameters.AddWithValue("@InterventionTypeId", interventionTypeId);
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get a list of intervention by it's createdBy
        /// </summary>
        /// <param name="createdBy">the guid of the creator</param>
        /// <returns>a list of intervention</returns>
        public IEnumerable<Intervention> fetchInterventionsByCreator(Guid createdBy)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where CreatedBy = @CreatedBy");
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get a list of intervention by it's clientId
        /// </summary>
        /// <param name="clientId">the guid of the client</param>
        /// <returns>a list of intervention</returns>
        public IEnumerable<Intervention> fetchInterventionsByClientId(Guid clientId)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where ClientId = @clientId");
            command.Parameters.AddWithValue("@clientId", clientId);

            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get a list of intervention by it's approved userId
        /// </summary>
        /// <param name="userId">the guid of an user</param>
        /// <returnsa list of intervention></returns>

        public IEnumerable<Intervention> fetchInterventionsByApprovedUser(Guid userId)
        {
            SqlCommand command = new SqlCommand("Select * From Interventions Where ApprovedBy = @userId");
            command.Parameters.AddWithValue("@userId", userId);

            return sqlExecuter.ExecuteReader(command);
        }

       
    }
}
